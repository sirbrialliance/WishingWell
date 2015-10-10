using UnityEngine;
using System.Collections;


public class Wish : MonoBehaviour {

    public string secretText;

    public GUIText secretsTextUI;

    PlayerController player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter ()
    {
        this.enabled = false;
        Debug.Log("hit wish:" + this + " secretText:" + secretText);
        secretsTextUI.text = secretText;
        player.hitWish(this);
    }
}
