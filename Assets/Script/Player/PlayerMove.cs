using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float Speed;
    public float RotSpeed;
    public Transform Camera;
    //public float MaxSpeed;
    //private Rigidbody2D Rb2d;

	// Use this for initialization
	void Start () {
        //Rb2d = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        float h = 1 * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.up * Time.deltaTime * Speed);
            transform.eulerAngles = new Vector3(0, 0, Camera.eulerAngles.z +90);
            //gameObject.transform.position = new Vector2(gameObject.transform.position.x * h, transform.position.y);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.up * Time.deltaTime * Speed);
            transform.eulerAngles = new Vector3(0, 0, Camera.eulerAngles.z - 90);
            //gameObject.transform.Rotate(0, 0, -RotSpeed);
            //gameObject.transform.position = new Vector2(gameObject.transform.position.x * -h, transform.position.y);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * Time.deltaTime * Speed);
            transform.eulerAngles = new Vector3(0, 0, Camera.eulerAngles.z + 0);
            //gameObject.transform.Rotate(0, 0, RotSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.up * Time.deltaTime * Speed);
            transform.eulerAngles = new Vector3(0, 0, Camera.eulerAngles.z - 180);
            //gameObject.transform.Rotate(0, 0, -RotSpeed);
        }

        /*
        float h = Input.GetAxis("Horizontal");
        Rb2d.AddForce((Vector2.right * Speed) * h);
        if (Rb2d.velocity.x > MaxSpeed) {
            Rb2d.velocity = new Vector2(MaxSpeed, Rb2d.velocity.y);
        }

        float v = Input.GetAxis("Vertical");
        Rb2d.AddForce((Vector2.up * Speed) * v);
        if (Rb2d.velocity.y > MaxSpeed) {
            Rb2d.velocity = new Vector2(Rb2d.velocity.x, MaxSpeed);
        }
        */

	}
}
