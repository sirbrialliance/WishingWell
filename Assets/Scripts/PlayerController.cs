using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Wish heldWish;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void hitWish(Wish newWish)
    {
        if( heldWish != null )
        {
            // put heldWish back in the world
        }

        heldWish = newWish;
    }
}
