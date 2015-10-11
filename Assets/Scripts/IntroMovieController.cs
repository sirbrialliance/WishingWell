using UnityEngine;
using System.Collections;

public class IntroMovieController : MonoBehaviour {

	public Canvas menuCanvas;
	public MeshRenderer menuClickText;

	// Use this for initialization
	void Start () {
		menuCanvas.gameObject.SetActive(false);
		menuClickText.gameObject.SetActive(false);
		StartCoroutine("waitLoadMovie");
		StartCoroutine("waitShowClickText");
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
				break;
			}
		}
	}

	IEnumerator waitShowClickText()
	{
		yield return new WaitForSeconds(20);

		// after wait time is up, movie should be done, so show click text
		menuClickText.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetMouseButtonDown(0) )
		{
			MovieTexture mt = ((MovieTexture)GetComponent<Renderer>().material.mainTexture);
			Debug.Log("mt:" + mt);
			mt.Stop();
			menuCanvas.gameObject.SetActive(false);
			menuClickText.gameObject.SetActive(false);
			menuCanvas.gameObject.SetActive(true);
		}
	}
}
