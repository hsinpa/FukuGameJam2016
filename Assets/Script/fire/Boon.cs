using UnityEngine;
using System.Collections;

public class Boon : MonoBehaviour {

    public int Damage;

    void Start()
    {
        Destroy(gameObject,0.2f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Monter")
        {
            other.GetComponent<NPC.NPCUnit>().hp -= Damage;

        }
        
    }
}
