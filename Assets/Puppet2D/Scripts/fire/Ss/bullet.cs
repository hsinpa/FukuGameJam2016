using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
	Rigidbody2D obj;
	public float speed;
	public float m_RotaSmooth;
   // public float m_AngleSpeed=135;
    Transform playertran;
	// Use this for initialization
	void Start () {
		obj = GetComponent<Rigidbody2D> ();
//		playertran = GameObject.FindGameObjectWithTag ("Gost");
	}
	
	// Update is called once per frame
	float yVelocity = 0.0F;
	void Update () {
		
		transform.position += transform.forward*speed;       
		//transform.eulerAngles = new Vector2(0, Mathf.SmoothDampAngle(transform.eulerAngles.y,transform.eulerAngles.y +m_AngleSpeed, ref yVelocity, m_RotaSmooth));
	}
}
