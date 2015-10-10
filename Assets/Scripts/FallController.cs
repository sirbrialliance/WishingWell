using UnityEngine;
using System.Collections;

public class FallController : MonoBehaviour {

    public int wellTop = 0;
    public int wellBottom = -5000;
    public Transform[] fallers;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    foreach( Transform t in fallers )
        {
            if( t.position.y < wellBottom )
            {
                t.position = new Vector3(t.position.x, wellTop, t.position.z);
            }
        }
	}
}
