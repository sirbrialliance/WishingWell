using UnityEngine;
using System.Collections;

public class MaterialAnimator : MonoBehaviour {

	public Material animMaterial;
	public float animSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2(animSpeed*Time.realtimeSinceStartup, 0);
		animMaterial.SetTextureOffset("_BumpMap", offset);
		animMaterial.SetTextureOffset("_MainTex", offset);
	}
}
