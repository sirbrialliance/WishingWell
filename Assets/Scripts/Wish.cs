﻿using UnityEngine;
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FPSController")
        {
            this.enabled = false;
            Debug.Log("hit wish:" + this + " secretText:" + secretText);
            secretsTextUI.text = secretText;
            player.hitWish(this);
        }
    }
}
