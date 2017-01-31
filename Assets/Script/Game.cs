using UnityEngine;
using System.Collections;
using NPC;

public class Game : MonoBehaviour {
	public Map _map;
    public GameObject DieUI;
    public GameObject VVUI;
	public enum Status { Explore, SaveHostage } 
	public Status currentStatus = Status.Explore;

	// Use this for initialization
	void Awake () {
		_map = GameObject.Find("Map").GetComponent<Map>();
		_map.PreSet(this);
	}


	public IEnumerator GameOver() {

        DieUI.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Gameover");
        yield return new WaitForSeconds(1);

	}

    public IEnumerator Victory()
    {

        VVUI.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Victory");
        yield return new WaitForSeconds(1);

    }


}
