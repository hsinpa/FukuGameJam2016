using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System.Linq;
using NPC;

public class Map : MonoBehaviour {
	
	public List<Grid> grids = new List<Grid>();

	public Player _player;
	public Hostage _hostage;

	public Game _game;
	public List<Room> rooms = new List<Room>();
	public List<GameObject> enemyList = new List<GameObject>();

	public void PreSet(Game game) {
		_game = game;
		grids = GetComponentsInChildren<Grid>().ToList();

		grids.ForEach(delegate(Grid obj) {
			obj.tile = new Tile(obj.transform.position, Mathf.RoundToInt( obj.gridPosition.x), Mathf.RoundToInt( obj.gridPosition.y), new JSONObject() );	
		});

		rooms = GetComponentsInChildren<Room>().ToList();

		rooms.ForEach(delegate(Room obj) {
			obj.RoomActivate(_game);
		});

	}


	public void DefeatEnemy( ) {
		if(enemyList.Count >  0) {
			enemyList.RemoveAt( enemyList.Count - 1);
			if (enemyList.Count <= 0) {
				StartCoroutine(DoorSwitch( false) );
			}
		}
	} 

	public Grid FindTileByPos(Vector2 p_grid) {
		return grids.Find( x=> x.gridPosition  == p_grid);
	}

	public IEnumerator DoorSwitch(bool isClose) {
		yield return new WaitForSeconds(1);

		Door[] doors = 	GetComponentsInChildren<Door>();
		foreach (Door door in doors) {
			door.CloseDoor(isClose);
		}
	}



}
