using UnityEngine;
using System.Collections;
using ZenFulcrum.Portal;

[RequireComponent(typeof(Portal))]
public class DisableTeleport : MonoBehaviour {
	public float disableHeight = 20;
	
	// Update is called once per frame
	void Update() {
		if (transform.position.y > disableHeight) {
			GetComponent<Portal>().physicsOptions.teleportOnTouch = false;
		}
	
	}
}
