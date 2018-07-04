using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class Minnow : MonoBehaviour {
  private Boid _boid;
  private Rigidbody2D _rb;
  private Collider2D _collider;
  private Transform _renderer;

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
    _renderer = transform.Find("Sprite");
    if (!_renderer) {
      Debug.LogError("Minnow requires Sprite child");
    }
  }

  void Update() {
    Vector3 velocity = _boid.boidDir;
    // float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
    Quaternion rotation = Quaternion.LookRotation(Vector3.forward, velocity);
    _renderer.rotation = Quaternion.Lerp(_renderer.rotation, rotation, 0.1f);
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