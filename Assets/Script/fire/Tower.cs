using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NPC;

public class Tower : MonoBehaviour {


    public Transform Target;
    public float range = 4;

    public Transform Barrel;
    public GameObject B_bullet;
    public GameObject B_bulletFire;
    public ParticleSystem fx_muzzleshot;
    public Transform[] FireObjs;
    public float B_bulletSpeed;
    public float CD;
    float fire_CD_Time;

    public float hp= 100;
	private Collider2D targetCollider;

    void Start() {
		InvokeRepeating("FindAvailableTarget", 0 , 1);
    }

	// Update is called once per frame
	void Update () {
		if (targetCollider != null) {
			JoeTool.LookAt2D(Barrel, targetCollider.transform.position);
                Fire();
            
        }
    }

    public void FindAvailableTarget() {
		List<Collider2D> colliders = Physics2D.OverlapCircleAll(transform.position, range, GeneralSetting.unitLayer).ToList();
		List<Collider2D> findTarget = colliders.FindAll(x => x.tag == "Monster").ToList();
		targetCollider = (findTarget.Count > 0) ? findTarget[0] : null;
    }

    public void UnderAttack(int damage) {
		hp -= damage;
		if (hp <= 0) GameObject.Destroy(gameObject);
    }

    public void Fire()
    {
        if (Time.time > fire_CD_Time )
        {
           
            fire_CD_Time = Time.time + CD;
            foreach (Transform B_FireObj in FireObjs)
            {
                GameObject bulle = Instantiate(B_bullet, B_FireObj.transform.position, B_FireObj.transform.rotation) as GameObject;
              //  fx_muzzleshot.transform.position.x = fire_point[fire_point_index].position.x;
               // fx_muzzleshot.transform.position.y = fire_point[fire_point_index].position.y;
               // if (SHOWING_FX)
                    fx_muzzleshot.Emit(2);
            }
        }
        
    }

}
