using UnityEngine;
using System.Collections;

public class MonsterSpawnPoint : MonoBehaviour {
    //public Room room;
    public GameObject[] monsters;
    public float cd = 1.5f;
    public int maxMonster = 10;
    private Game _game;

  	void Start() {
		_game = GameObject.Find("Map").GetComponent<Game>();
		monsters = Resources.LoadAll<GameObject>("Prefab/Enemy");
    }

    IEnumerator MonsterIE(float waitTime) {
        yield return new WaitForSeconds(waitTime);
		GameObject monster = monsters[ Random.Range(0, monsters.Length) ];
		GameObject effect = Instantiate(monster, transform.position, transform.rotation)as GameObject;
		if ( true && maxMonster > 0) {
        	maxMonster--;
            StartCoroutine(MonsterIE(cd));
        }
    }

    public void open()
    {	
		if (_game.currentStatus == Game.Status.SaveHostage) maxMonster = maxMonster * 2;
        StartCoroutine(MonsterIE(cd));
    }


}
