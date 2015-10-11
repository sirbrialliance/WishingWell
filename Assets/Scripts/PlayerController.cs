using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Wish heldWish = null;
	private int wishesGranted = 0;

	public AudioSource wishGrabSound;
	public AudioSource successfulWishDropSound;

	public AudioSource currentWellMusic;
	public AudioSource gameEndMusic;

	public UnityEngine.UI.Text realmTextUI;
	public UnityEngine.UI.Text secretsTextUI;
	public static bool preventFinalWish = true;

	public float moveSpeed = 15;

	private float missedPortalAudioBlockTimeStart;
	private bool missedPortalAudioBlock = false;

	private new Camera camera;
	private new Rigidbody rigidbody;

	private bool gameEnded = false;

	private Vector3 lastPosition;

	// Use this for initialization
	protected void Start() {
		camera = GetComponentInChildren<Camera>();
		rigidbody = GetComponent<Rigidbody>();
		lastPosition = transform.position;
		currentWellMusic.Play();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	void Update()
	{
		if( Input.GetKeyDown(KeyCode.Escape) )
		{
			Application.Quit();
		}

		Vector3 p = transform.position;
		Vector3 movedVec = p - lastPosition;
		if( movedVec.magnitude > 500 )
		{
			// we teleported, find new realm/universe
			// get all Universes in the scene
			Universe[] universes = Object.FindObjectsOfType<Universe>();
			foreach( Universe u in universes )
			{
				GameObject ugo = u.gameObject;
				Vector3 up = ugo.transform.position;
				if( p.x >= up.x - 500 && p.x <= up.x + 500 && 
					p.z >= up.z - 500 && p.z <= up.z + 500 )
				{
					enteredRealm(u);
					break;
				}
			}
		}

		bool checkMissedPortalAudio = true;
		if (missedPortalAudioBlock)
		{
			if( Time.realtimeSinceStartup - missedPortalAudioBlockTimeStart > 2.0f )
			{
				missedPortalAudioBlock = false;
			}
			else
			{
				checkMissedPortalAudio = false;
			}
		}
		if (checkMissedPortalAudio)
		{
			// turn on any portal audio listeners that are now above us
			AudioSource[] audioSources = Object.FindObjectsOfType<AudioSource>();
			foreach (AudioSource audioSrc in audioSources)
			{
				if (!audioSrc.enabled && audioSrc.gameObject.name == "PairA")
					if (audioSrc.gameObject.transform.position.y > 20)
						audioSrc.enabled = true;
			}
		}
		
		if( heldWish != null )
		{
			heldWish.transform.position = p;
		}

		lastPosition = p;
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
		if (gameEnded)
			return;
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
			if (heldWish == newWish)
				return;
			heldWish.enabled = true;
		}

		heldWish = newWish;

		wishGrabSound.Play();
		secretsTextUI.text = newWish.secretText;
		newWish.enabled = false;
	}

	public void enteredRealm(Universe u)
	{
		realmTextUI.text = "You have entered the " + u.type + " well.";
		missedPortalAudioBlockTimeStart = Time.realtimeSinceStartup;
		missedPortalAudioBlock = true;
		if( heldWish != null && u.type == heldWish.type )
		{
			secretsTextUI.text = "You have granted the wish by bringing it to the correct well!";
			successfulWishDropSound.Play();
			if (wishesGranted < 2)
			{
				wishesGranted++;
				if (wishesGranted == 2)
				{
					preventFinalWish = false;
				}
			}
			else
			{
				if( heldWish.secretText == Wish.winWish )
				{
					secretsTextUI.text = "You have granted your lover's wish. You win!";
					this.enabled = false;
					gameEnded = true;
					currentWellMusic.Stop();
					gameEndMusic.Play();
				}
			}
			heldWish.enabled = true;
			heldWish = null;
		}

		if(!gameEnded)
		{
			StartCoroutine("ChangeMusic", u.wellMusic);
		}
	}

	private IEnumerator ChangeMusic(AudioSource newWellMusic)
	{
		float fadeTimePassed = 0;
		newWellMusic.volume = 0;
		newWellMusic.Play();

		while (!(Mathf.Approximately(fadeTimePassed, 1)))
		{
			fadeTimePassed = Mathf.Clamp01(fadeTimePassed + Time.deltaTime);
			currentWellMusic.volume = 1 - fadeTimePassed;
			newWellMusic.volume = fadeTimePassed;
			yield return new WaitForSeconds(0.02f);
		}

		newWellMusic.volume = 1;
		currentWellMusic.Stop();
		currentWellMusic = newWellMusic;
		StopCoroutine("ChangeMusic");
	}
}
