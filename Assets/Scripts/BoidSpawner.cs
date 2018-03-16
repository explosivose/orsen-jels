using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(BoxCollider2D))]
public class BoidSpawner : MonoBehaviour {

	public int flockSize = 20;
	public GameObject prefab;
	public bool setTarget;
	public GameObject target;
	
	void Start()
	{
    BoxCollider2D collider = GetComponent<BoxCollider2D>();
		for (var i=0; i<flockSize; i++)
		{
			Vector3 position = new Vector3 (
				Random.value * collider.bounds.size.x,
				Random.value * collider.bounds.size.y
				) - collider.bounds.extents;
			
			GameObject b = Instantiate(prefab, transform.position + position, Random.rotation) as GameObject;
			if (setTarget)
				b.BroadcastMessage("SetTarget2", target.transform);
		}
	}

	
}