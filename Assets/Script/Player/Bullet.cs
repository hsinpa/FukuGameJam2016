using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float speed;
    public int damage;
    public GameObject hit; 

	
	// Update is called once per frame
	void Update ()
    {
//        if (Vector3.Distance(gameObject.transform.position, player.transform.position) >= 2)
//        {
//            Destroy(gameObject);
//        }
        transform.Translate(Vector2.up * speed);
	}

	void OnTriggerEnter2D(Collider2D other)
	{    

        if (other.tag == "Monster")
        {
            other.GetComponent<NPC.Enemy>().hp -= damage;
            Instantiate(hit, transform.position, transform.rotation);
        }
		if (other.tag != "Player" && (other.tag != "Bullet" ) ){
			Debug.Log(other.name);
			Destroy(gameObject);
		} 
    }
}
