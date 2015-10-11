using UnityEngine;
using System.Collections;

public class IntroMovieController : MonoBehaviour {

	public Canvas menuCanvas;

	// Use this for initialization
	void Start () {
		menuCanvas.gameObject.SetActive(false);
		StartCoroutine("waitLoadMovie");
	}

	IEnumerator waitLoadMovie()
	{
		while (true)
		{
			yield return new WaitForSeconds(1);

			MovieTexture mt = ((MovieTexture)GetComponent<Renderer>().material.mainTexture);
			if(mt.isReadyToPlay)
			{
				Debug.Log("mainTexture:" + mt);
				mt.Play();
				yield break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetMouseButtonDown(0) )
		{
			MovieTexture mt = ((MovieTexture)GetComponent<Renderer>().material.mainTexture);
			Debug.Log("mt:" + mt);
			mt.Stop();
			this.gameObject.SetActive(false);
			menuCanvas.gameObject.SetActive(true);
		}
	}
}
