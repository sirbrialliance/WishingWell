using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class LinkToISR : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                var pd = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
                var results = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pd, results);
                foreach (var result in results)
                {
                    if (result.gameObject.name == "ISRLink")
                    {
                        Application.OpenURL("http://www.indiespeedrun.com");
                    }
                }
            }
        }
    }

    void OnMouseDown ()
    {
        Debug.Log("reall?");
    }
}
