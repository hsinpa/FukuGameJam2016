using UnityEngine;
using System.Collections;

public class CallMonter : MonoBehaviour {
    //public Room room;
    public GameObject monters;
    public float cd = 1.5f;
    public float maxMonster = 20;

    IEnumerator MonsterIE(float waitTime) {
        yield return new WaitForSeconds(waitTime);

		GameObject effect = Instantiate(monters, transform.position, transform.rotation)as GameObject;
		if ( true && maxMonster > 0) {	
        	maxMonster--;
            StartCoroutine(MonsterIE(cd));
        }
    }

    public void open()
    {
        StartCoroutine(MonsterIE(cd));
    }


}
