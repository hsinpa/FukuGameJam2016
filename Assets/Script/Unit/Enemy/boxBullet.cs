using UnityEngine;
using System.Collections;

public class boxBullet : MonoBehaviour
{
    Rigidbody2D obj;
    public float speed;
    public int Damage;
    public GameObject hit;

    // Update is called once per frame
    void Update() {

        transform.position += transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Player") {
            other.GetComponent<Player>().Damage();
//            other.GetComponent<Player>().hp_point -= Damage;
        }
		if (other.tag == "Tower") other.GetComponent<Tower>().UnderAttack( Damage );
		if (other.tag == "Hostage") other.GetComponent<NPC.Hostage>().hp -= Damage;

		Debug.Log(other.name);
		if (other.tag != "Bullet" && other.tag != "Monster") {
            Instantiate(hit, transform.position, transform.rotation);
            Destroy(this.gameObject);
        } 
    }
}