using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
  Rigidbody rb;
  public PlayerControls playerControls;
  bool isGrounded;


  private InputAction move;
  private InputAction fire;

  private Transform cameraTransform;

  Vector2 moveDirection = Vector2.zero;

  [Header ("Player Variables")]
  public float speed = 5f;
  [SerializeField] float jumpForce;

  private void Awake() {
    PlayerUtility.SetPlayer(this.gameObject);
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    rb = GetComponent<Rigidbody>();
    playerControls = new PlayerControls();
    cameraTransform = Camera.main.transform;
  }

  // Update is called once per frame
  void Update() {
    moveDirection = move.ReadValue<Vector2>();
    if (Input.GetKey(KeyCode.Space) && isGrounded) {
      isGrounded = false;
      rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
  }

  private void FixedUpdate() {
    Vector3 temp = new Vector3(moveDirection.x, 0f, moveDirection.y);
    
    Vector3 camDirection2D = new Vector3(Mathf.Sin(Mathf.Deg2Rad * cameraTransform.eulerAngles.y), 0, Mathf.Cos(Mathf.Deg2Rad * cameraTransform.eulerAngles.y));
    temp = camDirection2D * temp.z + cameraTransform.right * temp.x;
    rb.velocity = new Vector3(temp.x * speed, rb.velocity.y, temp.z * speed);
  }

  private void OnEnable() {
    move = playerControls.Player.Movement;
    move.Enable();
  }

  private void OnDisable() {
    move.Disable();
  }
  void OnCollisionEnter(Collision other) {
    // Print how many points are colliding with this transform
    //Debug.Log("Points colliding: " + other.contacts.Length);

    // Print the normal of the first point in the collision.
    //Debug.Log("Normal of the first point: " + other.contacts[0].normal);

    // Draw a different colored ray for every normal in the collision
    /*
    foreach (var item in other.contacts) {
      Debug.DrawRay(item.point, item.normal * 100, Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 10f);
    }
    */
  }
  private void OnCollisionStay(Collision other) {
    if (other.gameObject.tag == "Environment") {
      if (other.contacts[0].normal.y > 0.5) {
        isGrounded = true;
      }
    }
  }
  private void OnCollisionExit(Collision other) {
    if (other.gameObject.tag == "Environment") {
      isGrounded = false;
    }
  }
}
