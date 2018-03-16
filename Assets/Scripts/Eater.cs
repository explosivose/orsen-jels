using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Collider2D))]
public class Eater : MonoBehaviour {

  public float eatTime = 2f;

  private bool _eating = false;
  private Transform _food;

  private Collider2D _collider;

  void Awake() {
    _collider = GetComponent<Collider2D>();
  }

  void OnTriggerEnter2D(Collider2D other) {
    if (!_eating && other.transform != transform) {
      _food = other.transform;
      StartCoroutine(Eat());
    }
  }

  void OnTriggerExit2D(Collider2D other) {

  }

  IEnumerator Eat() {
    _eating = true;
    _food.BroadcastMessage("StartEaten", SendMessageOptions.DontRequireReceiver);
    _food.position = _collider.bounds.center;
    _food.parent = transform;
    yield return new WaitForSeconds(eatTime);
    _food.parent = null;
    _food.BroadcastMessage("StopEaten", SendMessageOptions.DontRequireReceiver);
    _food = null;
    _eating = false;
  }
}