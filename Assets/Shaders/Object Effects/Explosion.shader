Shader "Custom/Explosion"
{

        Properties
        {
            _Color("Color", Color) = (1,1,1,1)
            _MainTex("Albedo (RGB)", 2D) = "white" {}
            _Glossiness("Smoothness", Range(0,1)) = 0.5
            _Metallic("Metallic", Range(0,1)) = 0.0
            _NormalMap("Normal Map", 2D) = "bump" {}
            _ExplosionSpeed("Rotation Speed", Float) = 2.0
            _ExplosionDegrees("Rotation Degrees", Float) = 0.0
            _Direction("Direction", Vector) = (1.0, 0.0, 0.0, 1.0)

        }
            SubShader
            {
                Tags { "RenderType" = "Opaque" }
                LOD 200

                CGPROGRAM
                #pragma surface surf Standard fullforwardshadows vertex:vert 

                #pragma target 3.0

                sampler2D _MainTex;

                struct Input
                {
                    float2 uv_MainTex;
                };

                half _Glossiness;
                half _Metallic;
                fixed4 _Color;
                float4 _ExplosionSpeed;
                float4 _ExplosionDegrees;
                float4 _Direction;


                UNITY_INSTANCING_BUFFER_START(Props)

                UNITY_INSTANCING_BUFFER_END(Props)

                void vert(inout appdata_full v) {
                    float3 pos = v.vertex.xyz;
                    float4 dir = normalize(_Direction);
                    pos.x += dir.x * (_ExplosionSpeed * cos(_ExplosionDegrees));
                    pos.y = _ExplosionSpeed * sin(_ExplosionDegrees);
                    pos.z += dir.y * (_ExplosionSpeed * cos(_ExplosionDegrees));
                    v.vertex.xyz = pos;
                }

                void surf(Input IN, inout SurfaceOutputStandard o)
                {

                    fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
                    o.Albedo = c.rgb;
                    o.Metallic = _Metallic;
                    o.Smoothness = _Glossiness;
                    o.Alpha = c.a;
                }
                ENDCG
            }
                FallBack "Diffuse"
}