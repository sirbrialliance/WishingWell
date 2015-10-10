using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Wish heldWish = null;

	public UnityEngine.UI.Text secretsTextUI;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter(Collider otherCollider)
	{
		Debug.Log("OnTriggerEnter " + otherCollider.name);
		if( otherCollider.name == "Wish(Clone)" )
		{
			hitWish((Wish)otherCollider.gameObject.GetComponent("Wish"));
		}
	}

	public void hitWish(Wish newWish)
	{
		if (heldWish != null)
		{
			Object.Destroy(heldWish);
		}

		heldWish = newWish;

		secretsTextUI.text = newWish.secretText;
		newWish.enabled = false;
	}

	public void enteredRealm(Universe u)
	{
		if( heldWish != null && u.type == heldWish.type )
		{
			secretsTextUI.text = "You have granted the wish by bringing it to the correct realm!";
		}
	}
}
