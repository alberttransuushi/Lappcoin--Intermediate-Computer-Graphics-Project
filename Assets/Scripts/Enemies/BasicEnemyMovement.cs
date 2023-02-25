using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BasicEnemyMovement : MonoBehaviour {
  NavMeshAgent agent;
  Transform playerTrans;
  public float baseSpeed;
  float contactDamage;
  Collider col;
  void Start() {
    agent = GetComponent<NavMeshAgent>();
    playerTrans = PlayerUtility.GetPlayer().transform;
    contactDamage = EnemyUtility.GetEnemyDamage();
    col = GetComponent<Collider>();
    
  }
  private void Update() {
    agent.destination = playerTrans.position;
    if (EnemyUtility.IsEnemyFrozen()) {
      col.enabled = false;
      agent.speed = 0;
    } else {
      col.enabled = true;
      agent.speed = baseSpeed;
    }
  }

  private void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.CompareTag("Player")) {
      //UnityEditor.EditorApplication.isPlaying = false;
      collision.gameObject.GetComponent<PlayerHealth>().Damage(contactDamage);
    }
  }

}
