using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
  // Config
  [SerializeField] float moveSpeed = 1f;

  // State

  // Cached component references
  Rigidbody2D myRigidBody;
  BoxCollider2D myBoxCollider;

  void Start() {
    myRigidBody = GetComponent<Rigidbody2D>();
    myBoxCollider = GetComponent<BoxCollider2D>();
  }

  void Update() {
    if (IsFacingRight()) {
      myRigidBody.velocity = new Vector2(moveSpeed, 0f);
    }
    else {
      myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
    }
  }

  private void OnTriggerExit2D() {
    transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
  }
  
  private bool IsFacingRight() {
    return transform.localScale.x > 0;
  }
}
