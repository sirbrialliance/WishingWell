using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Wish heldWish = null;
	private int wishesGranted = 0;

	public UnityEngine.UI.Text realmTextUI;
	public UnityEngine.UI.Text secretsTextUI;
	public static bool preventFinalWish = true;

	public float moveSpeed = 15;

	private new Camera camera;
	private new Rigidbody rigidbody;

	// Use this for initialization
	protected void Start() {
		camera = GetComponentInChildren<Camera>();
		rigidbody = GetComponent<Rigidbody>();

	}
	
	
	protected void FixedUpdate() {
		var moveVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Input.GetAxis("Vertical"));

		moveVector = camera.transform.TransformVector(moveVector);
		moveVector.y = 0;
		moveVector = moveVector.normalized * moveSpeed * Time.fixedDeltaTime * 100;

		rigidbody.AddForce(moveVector);
	}

	public void OnTriggerEnter(Collider otherCollider)
	{
		//Debug.Log("OnTriggerEnter " + otherCollider.name);
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
		realmTextUI.text = "You have entered the " + u.type + " realm.";
		if( heldWish != null && u.type == heldWish.type )
		{
			secretsTextUI.text = "You have granted the wish by bringing it to the correct realm!";
			if (wishesGranted < 2)
			{
				wishesGranted++;
				if (wishesGranted == 2)
				{
					preventFinalWish = true;
				}
			}
			else
			{
				if( heldWish.secretText == Wish.winWish )
				{
					secretsTextUI.text = "You have finally granted your lover's wish and now you will be together forever. You win!";
					this.enabled = false;
				}
			}
			Object.Destroy(heldWish);
			heldWish = null;
		}
	}
}
