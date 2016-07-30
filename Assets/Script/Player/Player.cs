using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float Hp = 100;
    public float Mona = 0;

    public GameObject bullet;
    public GameObject gun;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        }

	}
}
