using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Universe))]
public class StuffSpawner : MonoBehaviour {
	public Vector3 size = new Vector3(500, 500, 500);

	public GameObject wishTemplate;
	public GameObject portalTemplate;

	public float wishFrequency = .2f;
	public float portalFrequency = .2f;

	public Collider destructionBlock;

	protected void Start() {
		StartCoroutine(PortalSpawnner());
		StartCoroutine(WishSpawnner());
	}

	protected void Update() {
		
	}

	private IEnumerator PortalSpawnner() {
		while (true) {
			yield return new WaitForSeconds(portalFrequency);

			var pObj = GameObject.Instantiate(portalTemplate);
			pObj.transform.position = new Vector3(Random.Range(-size.x, size.x), -size.y, Random.Range(-size.z, size.z));
		}
	}

	private IEnumerator WishSpawnner() {
		while (true) {
			yield return new WaitForSeconds(wishFrequency);

			var pObj = GameObject.Instantiate(wishTemplate);
			pObj.transform.position = new Vector3(Random.Range(-size.x, size.x), -size.y, Random.Range(-size.z, size.z));
		}
	}
}
