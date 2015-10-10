using UnityEngine;
using System.Collections;

/** Erases stuff that touches it. */
public class StuffEraser : MonoBehaviour {

	protected void OnTriggerEnter(Collider other) {
		var rb = other.GetComponentInParent<Rigidbody>();
		if (rb) Object.Destroy(rb.gameObject, .1f);
		else Object.Destroy(other.gameObject, .1f);
	}
}
