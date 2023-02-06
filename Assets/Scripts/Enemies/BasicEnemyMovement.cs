using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BasicEnemyMovement : MonoBehaviour {
  NavMeshAgent agent;
  Transform playerTrans;
  void Start() {
    agent = GetComponent<NavMeshAgent>();
    playerTrans = GameObject.FindWithTag("Player").transform;
  }
  private void Update() {
    agent.destination = playerTrans.position;
  }

  private void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.CompareTag("Player")) {
      //UnityEditor.EditorApplication.isPlaying = false;
      Application.Quit();
    }
  }
  private void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Player")) {
      //UnityEditor.EditorApplication.isPlaying = false;
      Application.Quit();
    }
  }
}
