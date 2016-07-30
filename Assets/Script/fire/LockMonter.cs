using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class LockMonter : MonoBehaviour {
    public GameObject[] monters;
   
    public ArrayList mm = new ArrayList();
    // Use this for initialization

   

    void Start () {
        
       // mm.Add(gameObject);
        // monters = mm.ToArray()as GameObject[];
        
	}
	
	// Update is called once per frame
	void Update () {

        monters = new GameObject[mm.Count];
        mm.CopyTo(monters);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.tag == "Monter")
        {
            mm.Add(other.gameObject);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Monter")
        {
            mm.Remove(other.gameObject);
        }
        

    }

}
