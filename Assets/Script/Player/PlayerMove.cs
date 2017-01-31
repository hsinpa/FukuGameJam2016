using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float walkSpeed = 3;
	//public float maxSpeed;

	private Rigidbody2D mRigidBody;
	private Camera mCamera;

	void Start() {
		mRigidBody = GetComponent<Rigidbody2D>();	
		mCamera = GameObject.Find("Camera").GetComponent<Camera>();
	}

     void FixedUpdate() {
     	//Rotate
		Vector3 mousePos = mCamera.ScreenToWorldPoint(Input.mousePosition);
    	transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

         // Move senteces
		transform.Translate( new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal")* walkSpeed, 0.8f),
									Mathf.Lerp(0, Input.GetAxis("Vertical")* walkSpeed, 0.8f)) );
	 }
}
