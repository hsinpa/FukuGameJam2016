using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float speed;
    public int dam;
    public GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) >= 2)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.up * speed);
	}

	void OnTriggerEnter2D(Collider2D other)
	{        Debug.Log(other.tag);

        if (other.tag == "Monster")
        {
            other.GetComponent<NPC.Enemy>().hp -= dam;
        }
    }
}
