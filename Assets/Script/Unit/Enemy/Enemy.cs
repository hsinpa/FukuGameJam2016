using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NPC{
		public class Enemy : NPCUnit {
		public string selectTarget = "Hostage";
		private Transform mTarget;
		public int _speed = 1; 
		public float attackRange = 4;
        
		private float _attackPeriod = 0.5f; 
		private float currentAttackTime = 0; 

		public GameObject bulletPrefab;
        public ParticleSystem[] fx_muzzleshot;
        public Transform[] gun; 

		public override void Start () {
			base.Start();
			FindTarget();
		}

		public override void Update() {
			base.Update();
			Pursue();
		}

		public void FindTarget() {			
			switch (selectTarget) {
				case "Player" :
					mTarget =  _map._player.transform;
				break;

				case "Hostage" :
					mTarget =  _map._hostage.transform;
				break;

				case "Tower" :
					mTarget = FindNearestTower();
					if (mTarget == null && _map._game.currentStatus == Game.Status.SaveHostage) mTarget = _map._hostage.transform;
					if (mTarget == null && _map._game.currentStatus == Game.Status.Explore) mTarget = _map._player.transform;

				break;
			}
		}

		public Transform FindNearestTower() {
			int radius = 9;
			List<Collider2D> collides = Physics2D.OverlapCircleAll(transform.position, radius, GeneralSetting.towerLayer).ToList();
			if (collides.Count <= 0) return null;
			return collides.OrderBy(x=> Vector3.Distance( transform.position , x.transform.position )).First().transform;
		}

		public void  Attack() {
			int layer = GeneralSetting.unitLayer + GeneralSetting.towerLayer;

			List<RaycastHit2D> collides = Physics2D.LinecastAll(transform.position, transform.position + (transform.up * attackRange), layer).ToList();
			Collider2D collide = collides.Find(x=>x.collider.name == mTarget.name).collider;
			if (collide != null && collide != null && currentAttackTime < Time.time) {
				currentAttackTime = Time.time + _attackPeriod;
                int r = Random.Range(0, gun.Length);
                GameObject bullet = Instantiate(bulletPrefab, gun[r].position, gun[r].rotation) as GameObject;
                //fx_muzzleshot[r].Emit(2);
            }
		}

		public void UpdateMove(Vector3 direction) {
			transform.position += ( direction * _speed * Time.deltaTime);
		}

		private void Pursue() {
			FindTarget();

			Vector3 desired_velocity = mTarget.position - transform.position;
			Vector3 direction = Vector3.Normalize(desired_velocity);
			float distance = Vector3.Distance(mTarget.position, transform.position);

			transform.up = desired_velocity;

//			Quaternion rotation = Quaternion.LookRotation(new Vector3(0, 0, Mathf.Abs( direction.y )));
//			transform.rotation = rotation;

//			float angle = Mathf.Atan2(desired_velocity.y, desired_velocity.x) * Mathf.Rad2Deg;
//			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
//			transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 100);


			if (distance < attackRange) {
				desired_velocity = Vector3.zero;
				Attack();
			} else {
				UpdateMove(direction);
			}
		}

	}
}
