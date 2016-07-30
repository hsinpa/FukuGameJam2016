using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NPC{

public class Hostage : NPCUnit {
		private int[] mvirusRange = new int[] { 3, 6, 9}; 

		// Use this for initialization
		public override void Start () {
			base.Start();
//			Grid c = _map.FindTileByPos(_position),
//				t = _map.FindTileByPos( new Vector2(2,2) );
//			List<Tile> paths = _path.FindPath( c , t );
//			Vector3[] path = paths.ConvertAll<Vector3>(x => x.position).ToArray();
//
//			Move(path);
		}


		public void Infected (int p_radius, Player player) {
			player.Mana -= p_radius * 0.001f;
		}

		public void VirusRangeDetect(int p_radius) {
			//Attack per second
			Collider2D collides = Physics2D.OverlapCircle( _position, p_radius, GeneralSetting.unitLayer );

			if (collides != null && collides.tag == "Player") {
				Infected(p_radius, collides.GetComponent<Player>());
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