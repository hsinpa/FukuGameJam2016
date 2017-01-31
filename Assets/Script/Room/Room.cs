using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : MonoBehaviour {
	public enum RoomState { UnExplore, Explored, Spawning, DoneSpawning }
	public enum RoomType { Room, Corridor }

	public RoomState r_state = RoomState.UnExplore;
	public RoomType r_type = RoomType.Room;

	Door[] door;
	public Grid CenterPoint;

	MonsterSpawnPoint[] spawnPoint;
	public int maxMonsterNum = 150;

	[HideInInspector]
	public int currentMonsterNum = 0;
	public List<GameObject> monsters = new List<GameObject>();
	Game _game;

	public void RoomActivate(Game p_game) {
		spawnPoint = GetComponentsInChildren<MonsterSpawnPoint>();
		_game = p_game;

		foreach (MonsterSpawnPoint m_point in spawnPoint) {
			m_point.PointActivate(this, p_game);
		}
	}

	//Spawn monster and attack intruder
	public void RaiseAlarm() {
		if (r_state == RoomState.UnExplore && r_type == RoomType.Room) {
			currentMonsterNum = (_game.currentStatus == Game.Status.SaveHostage) ? Mathf.RoundToInt( maxMonsterNum * 2f) : maxMonsterNum;
			//Spawn Now
			r_state = RoomState.Spawning;
			foreach (MonsterSpawnPoint m_point in spawnPoint) {
				StartCoroutine(m_point.SpawnMonster());
			}

		}
	}




}
