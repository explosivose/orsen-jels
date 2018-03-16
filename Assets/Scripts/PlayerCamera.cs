using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

  public float moveSpeed = 10f;

  private GameObject _player;

  void Start() {
    _player = GameObject.FindWithTag("Player");
    if (!_player) {
      Debug.LogError("No player object found!");
    }
  }

  void FixedUpdate() {
    Vector3 target = _player.transform.position + Vector3.back * 10f;
    transform.position = Vector3.Lerp(transform.position, target, moveSpeed * Time.fixedDeltaTime);
  }

}
