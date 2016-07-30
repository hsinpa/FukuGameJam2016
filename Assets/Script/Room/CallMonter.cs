using UnityEngine;
using System.Collections;

public class CallMonter : MonoBehaviour {
    //public Room room;
    public bool opendoor;
    public Transform here;
    public GameObject monters;
    public int v;
    public float cd;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	 
	}
    IEnumerator MonsterIE(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);


        GameObject effect = Instantiate(monters, here.position, here.rotation)as GameObject;
        if (opendoor == true)
        {
            StartCoroutine(MonsterIE(cd));
        }
    }

    public void open()
    {
        StartCoroutine(MonsterIE(cd));
        opendoor = true;
    }

    public void Exit()
    {
        opendoor = false;
    }
}
