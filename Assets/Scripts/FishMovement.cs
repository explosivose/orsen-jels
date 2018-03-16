using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FishMovement : MonoBehaviour, IControllable {

  public float hopStrength = 100;
  public float timeBetweenHops = 0.5f;

  private Vector3 _moveCommand = Vector3.zero;
  private float _lastHop = 0f;
  private Rigidbody2D _rb;
  private bool _canHop {
    get {
      return Time.time > _lastHop + timeBetweenHops;
    }
  }

  public void Move(Vector3 command) {
    _moveCommand = command.normalized;
  }

  void Awake() {
    _rb = GetComponent<Rigidbody2D>();
  }

	// Update is called once per frame
	void Update () {
		if (_canHop) {
      DoHop();
    }
	}

  void DoHop() {
    _rb.AddForce(_moveCommand * hopStrength);
    _lastHop = Time.time;
  }

}
