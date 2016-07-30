using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NPC{

public class Hostage : NPCUnit {
		private int[] mvirusRange = new int[] { 1 ,3 ,5}; 
		float attackDelay = 1;
		float currentTime = 0;

		// Use this for initialization
		public override void Start () {
			base.Start();
			Grid c = _map.FindTileByPos(_position),
				t = _map.FindTileByPos( new Vector2(2,2) );
			List<Tile> paths = _path.FindPath( c , t );
			Vector3[] path = paths.ConvertAll<Vector3>(x => x.position).ToArray();

			Move(path);
			
			paths.ForEach(delegate(Tile obj) {
				Debug.Log(obj.position);	
			});
		}


		public void Infected (int p_radius, NPCUnit player) {
			currentTime = Time.time + attackDelay;
			player.hp = p_radius;
		}

		public void VirusRangeDetect(int p_radius) {
			//Attack per second
			if (currentTime < currentTime + attackDelay) return;

			Collider2D collides = Physics2D.OverlapCircle( _position, p_radius );
			if (collides != null) {
				Infected(p_radius, collides.GetComponent<NPCUnit>());
			}
		}

		public override void Update() {
			base.Update();
			foreach (int radius in mvirusRange) {
				VirusRangeDetect(radius);
			}
		}

	}
}