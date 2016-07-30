using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	    
    public MonsterSpawnPoint[] cms;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) {

     if (other.tag == "Player" && other.GetComponent<Player>().currentLocation == NPC.NPCUnit.UnitLocation.Corridor )
        {
			Debug.Log("Leave room, activate monster");
			other.GetComponent<Player>().currentLocation = NPC.NPCUnit.UnitLocation.Room;
            foreach(MonsterSpawnPoint cm in cms)
            {
                cm.open(); 
            }
		} else if (other.tag == "Player" && other.GetComponent<Player>().currentLocation == NPC.NPCUnit.UnitLocation.Room) {
			other.GetComponent<Player>().currentLocation = NPC.NPCUnit.UnitLocation.Corridor;
			Debug.Log("Enter Corridor");
        }
    }

}
