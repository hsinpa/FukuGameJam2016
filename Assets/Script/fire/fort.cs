using UnityEngine;
using System.Collections;

public class fort : MonoBehaviour {


    public LockMonter LM;
    public Transform Target;
    public float range;

    public Transform Barrel;
    public GameObject B_bullet;
    public GameObject B_bulletFire;
    public Transform[] FireObjs;
    public float B_bulletSpeed;
    public float CD;
    float fire_CD_Time;
    // Use this for initialization
    void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {

        if (LM.monters.Length > 0)
        {
            JoeTool.LookAt2D(Barrel,LM.monters[0].transform.position);
            Fire();
        }
        
    }

    public void Fire()
    {
        if (Time.time > fire_CD_Time )
        {
           
            fire_CD_Time = Time.time + CD;
            foreach (Transform B_FireObj in FireObjs)
            {
                GameObject bulle = Instantiate(B_bullet, B_FireObj.transform.position, B_FireObj.transform.rotation) as GameObject;
            }
        }
        
    }

}
