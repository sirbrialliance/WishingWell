using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ZenFulcrum.Portal;


[RequireComponent(typeof(Universe))]
public class StuffSpawner : MonoBehaviour {
	public Vector3 size = new Vector3(500, 500, 500);

	public GameObject wishTemplate;
	public GameObject portalTemplate;

	public float wishFrequency = .2f;
	public float portalFrequency = .2f;


	protected void Start() {
		StartCoroutine(PortalSpawnner());
		StartCoroutine(WishSpawnner());
	}

	private IEnumerator PortalSpawnner() {
		var myUniverse = GetComponent<Universe>().type;
		List<StuffSpawner> otherSpawners = new List<StuffSpawner>();
		foreach (var spawner in FindObjectsOfType<StuffSpawner>()) {
			if (spawner.GetComponent<Universe>().type == myUniverse) continue;

			otherSpawners.Add(spawner);
		}

		while (true) {
			yield return new WaitForSeconds(portalFrequency);

			var otherSideSpawner = otherSpawners[Random.Range(0, otherSpawners.Count)];

			var basePos = new Vector3(Random.Range(-size.x / 2f, size.x / 2f), -size.y / 2f, Random.Range(-size.z / 2f, size.z / 2f));
		
			var portalPair = GameObject.Instantiate(portalTemplate);
			var pObjA = portalPair.transform.Find("PairA");
			var pObjB = portalPair.transform.Find("PairB");

			//var pA = pObjA.GetComponentInChildren<Portal>();
			//var pB = pObjB.GetComponentInChildren<Portal>();

			pObjA.transform.position = transform.position + basePos;
			pObjB.transform.position = otherSideSpawner.transform.position + basePos;
		}
	}

	private IEnumerator WishSpawnner() {
		while (true) {
			yield return new WaitForSeconds(wishFrequency);

			var pObj = GameObject.Instantiate(wishTemplate);
			pObj.transform.position = transform.position + new Vector3(Random.Range(-size.x / 2f, size.x / 2f), -size.y / 2f, Random.Range(-size.z / 2f, size.z / 2f));
		}
	}
}
