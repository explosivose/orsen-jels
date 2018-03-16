using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IControllable))]
[RequireComponent(typeof(NearestNeighbor))]
public class JellyfishController : MonoBehaviour {

  private IControllable _pawn;
  private NearestNeighbor _nearestNeighbor;

  void Awake() {
    _pawn = GetComponent<IControllable>();
    _nearestNeighbor = GetComponent<NearestNeighbor>();
  }

  void Update() {
    Vector3 command;
    Transform neighbor = _nearestNeighbor.GetNearestNeighbor();
    if (neighbor) {
      Debug.DrawLine(transform.position, neighbor.position, Color.green);
      command = (neighbor.position - transform.position).normalized;
    } else {
      command = Random.onUnitSphere;
    }
    _pawn.Move(command);
  }


}
