using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearestNeighbor : MonoBehaviour {

  public float sightDistance = 3f;
  public LayerMask sightMask;

  private Transform _nearestNeighbor;
  
  public Transform GetNearestNeighbor() {
    ScanNeighbors();
    return _nearestNeighbor;
  }
  
  void ScanNeighbors() {
    _nearestNeighbor = null;
    Collider2D[] rawNeighbors = Physics2D.OverlapCircleAll(
        transform.position,
        sightDistance,
        sightMask
    );
    // make a list not including this fish
    List<Collider2D> neighbors = new List<Collider2D>();
    foreach(Collider2D collider in rawNeighbors) {
      if (collider.transform != transform) {
        neighbors.Add(collider);
      }
    }
    // find the closest one in the list
    if (neighbors.Count > 0) {
      Transform nearestNeighbor = neighbors[0].transform;
      foreach(Collider2D collider in neighbors) {
        Debug.DrawLine(transform.position, collider.transform.position);
        float nnDistance = Vector3.Distance(transform.position, nearestNeighbor.position);
        float cDistance = Vector3.Distance(transform.position, collider.transform.position);
        if (cDistance < nnDistance) {
          nearestNeighbor = collider.transform;
        }
      }
      _nearestNeighbor = nearestNeighbor;
      Debug.DrawLine(transform.position, _nearestNeighbor.position, Color.green);
    }
  }
}