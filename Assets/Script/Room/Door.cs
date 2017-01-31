using UnityEngine;
using System.Collections;
using Utility;

public class Door : MonoBehaviour {

	    
    public MonsterSpawnPoint[] cms;
    public Transform centerPoint;
	// Use this for initialization

	public void CloseDoor(bool isOpen) {
		Transform childTransform = transform.FindChild("door");
		SpriteRenderer spriteRender = childTransform.GetComponent<SpriteRenderer>();
		BoxCollider2D boxCollider2d = childTransform.GetComponent<BoxCollider2D>();

		spriteRender.enabled =isOpen;
		boxCollider2d.enabled =isOpen;
	}

    void OnTriggerEnter2D(Collider2D other) {

     if (other.tag == "Player" && other.GetComponent<Player>().currentLocation == NPC.NPCUnit.UnitLocation.Corridor )
        {
			Debug.Log("Leave room, activate monster");
			Player player = other.GetComponent<Player>();
			player.currentLocation = NPC.NPCUnit.UnitLocation.Room;
			StartCoroutine(player._map.DoorSwitch(true) );

			if (player.currentLocation == NPC.NPCUnit.UnitLocation.Room && player._map._game.currentStatus == Game.Status.SaveHostage) {
				player._map._hostage.SendToCenterPoint( new Vector2(centerPoint.position.x, centerPoint.position.y) );
			}

            foreach(MonsterSpawnPoint cm in cms)
            {
                //cm.open(); 
            }

		} else if (other.tag == "Player" && other.GetComponent<Player>().currentLocation == NPC.NPCUnit.UnitLocation.Room) {
			other.GetComponent<Player>().currentLocation = NPC.NPCUnit.UnitLocation.Corridor;
			Debug.Log("Enter Corridor");
        }
    }

}
