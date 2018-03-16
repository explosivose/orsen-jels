using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IControllable))]
public class PlayerController : MonoBehaviour {

  private IControllable _pawn;
	
  void Awake() {
    _pawn = GetComponent<IControllable>();
  }

	// Update is called once per frame
	void Update () {
		float v = Input.GetAxis("Vertical");
    float h = Input.GetAxis("Horizontal");
    Vector3 command = new Vector3(h, v).normalized;
    _pawn.Move(command);
	}
}
