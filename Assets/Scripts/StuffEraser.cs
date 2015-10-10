using UnityEngine;
using System.Collections;

/** Erases stuff that touches it. */
public class StuffEraser : MonoBehaviour {

	protected void OnTriggerEnter(Collider other) {
		Object.Destroy(other.gameObject);
	}
}
