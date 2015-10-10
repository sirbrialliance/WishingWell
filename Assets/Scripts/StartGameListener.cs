using UnityEngine;
using System.Collections;

public class StartGameListener : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey && e.keyCode == KeyCode.W)
        {
            Application.LoadLevel("Main");
        }
    }
}
