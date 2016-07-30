using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
	public GameObject Player;

	// Update is called once per frame
	void Update () {
		GetComponent<UnityEngine.Camera>().transform.position = new Vector3( Player.transform.position.x, Player.transform.position.y, -10);
	}
}
