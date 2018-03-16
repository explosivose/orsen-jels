using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class Minnow : MonoBehaviour {
  private Boid _boid;
  private Rigidbody2D _rb;
  private Collider2D _collider;

  void Awake() {
    _rb = GetComponent<Rigidbody2D>();
    _collider = GetComponent<Collider2D>();
    Transform boidChild = transform.Find("Boid");
    if (!boidChild) {
      Debug.LogError("Minnow requires Boid child");
    }
    _boid = boidChild.GetComponent<Boid>();
    if (!_boid) {
      Debug.LogError("Minnow Boid child requires Boid component");
    }
  }

  void StartEaten() {
    _boid.controlEnabled = false;
    _rb.isKinematic = true;
    _collider.enabled = false;
    Debug.Log("I'm about to be eaten!");
  }

  void StopEaten() {
    Debug.Log("I'm eaten!");
    Destroy(gameObject);
  }
}