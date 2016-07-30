using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	    
    public MonsterSpawnPoint[] cms;
    public Transform centerPoint;
	// Use this for initialization


    void OnTriggerEnter2D(Collider2D other) {

     if (other.tag == "Player" && other.GetComponent<Player>().currentLocation == NPC.NPCUnit.UnitLocation.Corridor )
        {	
			Debug.Log("Leave room, activate monster");
			Player player = other.GetComponent<Player>();
			player.currentLocation = NPC.NPCUnit.UnitLocation.Room;

			if (player.currentLocation == NPC.NPCUnit.UnitLocation.Room && player._map._game.currentStatus == Game.Status.SaveHostage) {
				player._map._hostage.SendToCenterPoint( new Vector2(centerPoint.position.x, centerPoint.position.y) );
			}

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
