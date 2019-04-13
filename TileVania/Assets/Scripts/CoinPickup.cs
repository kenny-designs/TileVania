using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {
  [SerializeField] AudioClip coinPickUpSFX;
  [SerializeField] int pointsForCoinPickup = 100;

  bool isCollected = false;

  private void OnTriggerEnter2D(Collider2D other) {
    if (isCollected) { return; }

    isCollected = true;
    FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
    AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
    Destroy(gameObject);
  }
}
