using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Old : MonoBehaviour {

    public Image Bar;
    public GameObject OldMan;

	// Use this for initialization
	void Start () {
        //OldMan = GameObject.Find("hostage");
	}
	
	// Update is called once per frame
	void Update ()
    {
        Bar.fillAmount = OldMan.GetComponent<NPC.NPCUnit>().hp / 20f;
	}
}
