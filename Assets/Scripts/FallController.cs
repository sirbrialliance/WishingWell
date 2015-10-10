using UnityEngine;
using System.Collections;

public class FallController : MonoBehaviour {

    public int wellTop = 0;
    public int wellBottom = -5000;
    public Rigidbody[] fallers;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    foreach( Rigidbody r in fallers )
        {
            if( r.position.y < wellBottom )
            {
                r.MovePosition(new Vector3(r.position.x, wellTop, r.position.z));
            }
        }
	}
}
