Shader "Particles/ParticleShader" {
    Properties{
        _TintColor("Tint Color", Color) = (0.5,0.5,0.5,0.5)
        _MainTex("Particle Texture", 2D) = "white" {}
        _InvFade("Soft Particles Factor", Range(0.01,3.0)) = 1.0
        _RotationSpeed("Rotation Speed", Float) = 2.0
        _RotationDegrees("Rotation Degrees", Float) = 0.0
        _DisplacementMap("DisMapInYouMouth", 2D) = "black" {}
        _DisplacmentStrength("DisStronkness", Range(0,100)) = 0.5
    }

        Category{
            Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" "PreviewType" = "Plane" }
            Blend SrcAlpha OneMinusSrcAlpha
            ColorMask RGB
            Cull Off Lighting Off ZWrite Off

            SubShader {
                Pass {

                    CGPROGRAM
                    #pragma vertex vert
                    #pragma fragment frag
                    #pragma target 2.0
                    #pragma multi_compile_particles
                    #pragma multi_compile_fog

                    #include "UnityCG.cginc"

                    sampler2D _MainTex;
                    sampler2D _DisplacementMap;
                    fixed4 _TintColor;

                    struct appdata_t {
                        float4 vertex : POSITION;
                        fixed4 color : COLOR;
                        float4 texcoords : TEXCOORD0;
                        float texcoordBlend : TEXCOORD1;
                        float3 normal : NORMAL;
                        UNITY_VERTEX_INPUT_INSTANCE_ID

                    };

                    struct v2f {
                        float4 vertex : SV_POSITION;
                        fixed4 color : COLOR;
                        float2 texcoord : TEXCOORD0;
                        float2 texcoord2 : TEXCOORD1;
                        fixed blend : TEXCOORD2;
                        UNITY_FOG_COORDS(3)
                        #ifdef SOFTPARTICLES_ON
                        float4 projPos : TEXCOORD4;
                        #endif
                        UNITY_VERTEX_OUTPUT_STEREO
                    };

                    half _DisplacmentStrength;
                    float _RotationSpeed;
                    float4 _MainTex_ST;
                    float4 _DisplacmentMap_ST;

                    v2f vert(appdata_t v)
                    {
                        v2f o;
                        UNITY_SETUP_INSTANCE_ID(v);
                        UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
                        o.vertex = UnityObjectToClipPos(v.vertex);
                        #ifdef SOFTPARTICLES_ON
                        o.projPos = ComputeScreenPos(o.vertex);
                        COMPUTE_EYEDEPTH(o.projPos.z);
                        #endif
                        o.color = v.color * _TintColor;
                        o.texcoord = TRANSFORM_TEX(v.texcoords, _MainTex);

                        o.texcoord.xy -= 0.5;
                        float s = sin(_RotationSpeed * _Time) * 0.4;
                        float c = cos(_RotationSpeed * _Time);
                        float2x2 rotationMatrix = float2x2(c, -s, s, c);
                        rotationMatrix *= 0.5;
                        rotationMatrix += 0.5;
                        rotationMatrix = rotationMatrix * 2 - 1;
                        o.texcoord.xy = mul(v.vertex.xy, rotationMatrix);
                        v.texcoords.xy = mul(v.vertex.xy, rotationMatrix);
                        o.texcoord.xy += 0.5;

                        float displacement = tex2Dlod(_DisplacementMap, float4(o.texcoord, 0, 0)).r;
                        //float displacement = 0;
                        float4 temp = float4(v.vertex.x, v.vertex.y, v.vertex.z, 1.0);
                        temp.xyz += displacement * v.normal * _DisplacmentStrength;

                        //temp.xyz += displacement * 1.0 * 1.0;

                        o.vertex = UnityObjectToClipPos(temp);

                        o.blend = v.texcoordBlend;
                        UNITY_TRANSFER_FOG(o,o.vertex);
                        return o;
                    }

                    sampler2D_float _CameraDepthTexture;
                    float _InvFade;

                    fixed4 frag(v2f i) : SV_Target
                    {
                        #ifdef SOFTPARTICLES_ON
                        float sceneZ = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)));
                        float partZ = i.projPos.z;
                        float fade = saturate(_InvFade * (sceneZ - partZ));
                        i.color.a *= fade;
                        #endif

                        fixed4 colA = tex2D(_MainTex, i.texcoord);
                        fixed4 colB = tex2D(_MainTex, i.texcoord2);
                        fixed4 col = 2.0f * i.color * lerp(colA, colB, i.blend);
                        UNITY_APPLY_FOG(i.fogCoord, col);
                        return col;
                    }
                    ENDCG
                }
            }
        }
}