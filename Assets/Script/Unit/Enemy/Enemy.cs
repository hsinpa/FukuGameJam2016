using UnityEngine;
using System.Collections;

namespace NPC{
		public class Enemy : NPCUnit {
		public string selectTarget = "Hostage";
		private Transform mTarget;
		public int _speed = 1; 


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

				break;
			}
		}

		public void  Attack() {

		}

		public void UpdateMove(Vector3 direction) {
			transform.Translate( direction * _speed * Time.deltaTime);
		}

		private void Pursue() {
			Vector3 desired_velocity = mTarget.position - transform.position;
			Vector3 direction = Vector3.Normalize(desired_velocity);
			float distance = Vector3.Distance(mTarget.position, transform.position);

//			Quaternion rotation = Quaternion.LookRotation(new Vector3(0, 0, Mathf.Abs( direction.y )));
//			transform.rotation = rotation;

//			float angle = Mathf.Atan2(desired_velocity.y, desired_velocity.x) * Mathf.Rad2Deg;
//			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
//			transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 100);


			if (distance < 1f) {
				desired_velocity = Vector3.zero;
				Attack();
			} else {
				UpdateMove(direction);
			}
		}

	}
}
