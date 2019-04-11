using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
  [SerializeField] float runSpeed = 5f;

  Rigidbody2D myRigidBody;

  private void Start() {
    myRigidBody = GetComponent<Rigidbody2D>();
  }

  private void Update() {
    Run();
  }

  private void Run() {
    // value between -1 and 1
    float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
    Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
    myRigidBody.velocity = playerVelocity;
  }

}
