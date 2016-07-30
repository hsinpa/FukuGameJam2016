using UnityEngine;
using System.Collections;


[System.Serializable]
public class Tile {
	public JSONObject jsonType;
	public bool walkable;
	public Vector2 position;
	public int gridX;
	public int gridY;
	public int gCost;
	public int hCost;


	public Tile parent;

	public Tile(Vector3 _pos, int _gridX, int _gridY, JSONObject _type) {
		//walkable = _walkable;
		position = _pos;
		gridX = _gridX;
		gridY = _gridY;

		jsonType = _type;
	}
	
	public int fCost {
		get {
			return gCost + hCost;
		}
	}
}
