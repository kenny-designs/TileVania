using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {
  // Config
  [SerializeField] float loadLevelDelay = 1f;
  [SerializeField] float floatSpeed = 5f;
  [SerializeField] float rotateSpeed = 360f;
  [SerializeField] float levelExitSloMoFactor = 0.2f;

  // State
  bool isLevelComplete = false;

  // Cached component references
  Rigidbody2D myRigidbody;

  private void Start() {
    myRigidbody = GetComponent<Rigidbody2D>();
  }

  private void Update() {
    if (isLevelComplete) {
      Spin();
    }
  }

  private void OnTriggerEnter2D(Collider2D other) {
    LevelWon();
    StartCoroutine(LoadNextLevel());
  }

  IEnumerator LoadNextLevel() {
    Time.timeScale = levelExitSloMoFactor;
    yield return new WaitForSeconds(loadLevelDelay);
    Time.timeScale = 1f;

    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex + 1);
  }

  private void LevelWon() {
    isLevelComplete = true;
    myRigidbody.velocity = new Vector2(0f, floatSpeed);
  }

  private void Spin() {
    myRigidbody.rotation += rotateSpeed * Time.deltaTime;
  }
}
