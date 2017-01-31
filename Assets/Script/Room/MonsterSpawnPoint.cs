using UnityEngine;
using System.Collections;

public class MonsterSpawnPoint : MonoBehaviour {
    //public Room room;
    private GameObject[] monsters;
    private float cd = 0.2f;

    private Game _game;
	private Room _room;

    public void PointActivate(Room p_room, Game p_game ) {
		monsters = Resources.LoadAll<GameObject>("Prefab/Enemy");
		_game = p_game;
		_room = p_room;
    }

    public IEnumerator SpawnMonster() {
        yield return new WaitForSeconds(cd);
		GameObject monsterPrefab = monsters[ Random.Range(0, monsters.Length) ];
		GameObject effect = Instantiate(monsterPrefab, transform.position, transform.rotation)as GameObject;
		effect.transform.SetParent( _game.transform.FindChild("Unit/Enemies") );

		_game._map.enemyList.Add(effect);
		if (_room.currentMonsterNum > 0) {
			_room.currentMonsterNum--;
            StartCoroutine(SpawnMonster());
        } 
        else {
            //StartCoroutine(_game._map.DoorSwitch(false));
            _room.r_state = Room.RoomState.Explored;
        }
    }

}
