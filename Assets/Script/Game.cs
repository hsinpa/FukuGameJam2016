using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	public Map _map; 

	// Use this for initialization
	void Awake () {
		_map = GameObject.Find("Map").GetComponent<Map>();
		_map.PreSet();
	}
}
