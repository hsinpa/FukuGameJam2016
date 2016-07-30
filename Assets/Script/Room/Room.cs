using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {

    
    public CallMonter[] cms;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            foreach(CallMonter cm in cms)
            {
                cm.open(); 
            }
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            foreach (CallMonter cm in cms)
            {
                cm.Exit();
            }
        }

    }
}
