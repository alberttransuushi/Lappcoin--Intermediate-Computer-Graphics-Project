using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
  Rigidbody body;
  public PlayerControls playerControls;
  public float speed = 5f;

  private InputAction move;
  private InputAction fire;

  private Transform cameraTransform;

  Vector2 moveDirection = Vector2.zero;

  private void Awake() {
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    body = GetComponent<Rigidbody>();
    playerControls = new PlayerControls();
    cameraTransform = Camera.main.transform;
  }

  // Update is called once per frame
  void Update() {
    moveDirection = move.ReadValue<Vector2>();
  }

  private void FixedUpdate() {
    Vector3 temp = new Vector3(moveDirection.x, 0f, moveDirection.y);
    
    Vector3 camDirection2D = new Vector3(Mathf.Sin(Mathf.Deg2Rad * cameraTransform.eulerAngles.y), 0, Mathf.Cos(Mathf.Deg2Rad * cameraTransform.eulerAngles.y));
    temp = camDirection2D * temp.z + cameraTransform.right * temp.x;
    body.velocity = new Vector3(temp.x * speed, body.velocity.y, temp.z * speed);
  }

  private void OnEnable() {
    move = playerControls.Player.Movement;
    move.Enable();
  }

  private void OnDisable() {
    move.Disable();
  }
}
