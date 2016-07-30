using UnityEngine;
using System.Collections;
using NPC;

public class Game : MonoBehaviour {
	public Map _map; 

	public enum Status { Explore, SaveHostage } 
	public Status currentStatus = Status.Explore;

	// Use this for initialization
	void Awake () {
		_map = GetComponent<Map>();
		_map.PreSet();
	}


}
