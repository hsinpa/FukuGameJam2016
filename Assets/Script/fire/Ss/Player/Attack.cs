using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
	public float P =300;
	public float G =0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
       
        if (other.tag == "Player") {
			other.GetComponent <PlayerMoveppp> ().hp -= P;
		}

		if (other.tag == "Gost") {
            Destroy(gameObject);
            //other.GetComponent <PlayerMoveppp> ().hp -= G;
		}
        
	}
	void ms(){
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);////(1)
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit,1000f,1)){////(2)
			if (Input.GetMouseButtonDown (0) ){
				
			}
		}
	
	}

}
