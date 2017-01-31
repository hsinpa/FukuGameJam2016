using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NPC{

public class Hostage : NPCUnit {
		private int[] mvirusRange = new int[] { 2, 5, 6}; 

		// Use this for initialization
		public override void Start () {
			base.Start();
//			Grid c = _map.FindTileByPos(_position),
//				t = _map.FindTileByPos( new Vector2(15,-20) );
//
//			List<Tile> paths = _path.FindPath( c , t );
//			Vector3[] path = paths.ConvertAll<Vector3>(x => x.position).ToArray();
//			Debug.Log(path.Length);
//
//			Move(path);
		}

		public void SendToCenterPoint(Vector2 targetPoint) {
            transform.position = new Vector3(Mathf.RoundToInt(_position.x), Mathf.RoundToInt( _position.y) , 10);
            Grid c = _map.FindTileByPos(_position);
                if (c == null) return;
            Grid t = _map.FindTileByPos( targetPoint );
			List<Tile> paths = _path.FindPath( c , t );
			Vector3[] path = paths.ConvertAll<Vector3>(x => x.position).ToArray();

			Move(path, delegate() {

				if (t.name == "ENDING") StartCoroutine(_game.Victory());

			});
		}

        public GameObject wa;

		public void Infected (int p_radius, Player player) {
			if (_game.currentStatus == Game.Status.Explore && p_radius == mvirusRange[0]) {
				_game.currentStatus = Game.Status.SaveHostage;
				_game._map.rooms.ForEach(delegate(Room obj) {
					obj.r_state = Room.RoomState.UnExplore;	
 				});

				Debug.Log("To Hostage Mode");
			}

			if (_game.currentStatus == Game.Status.SaveHostage) {
				player.FireWallBreakPoint += p_radius * 0.02f;
                player.cRestoreDelay = Time.time + 3;
                wa.SetActive(true);
            }
		}

		public void VirusRangeDetect(int p_radius) {
            //Attack per second
            List<Collider2D> collides = Physics2D.OverlapCircleAll(_position, p_radius, GeneralSetting.unitLayer).ToList();
			if (collides != null && collides.Count(x=> x.tag == "Player") > 0 ) {
				Infected(p_radius, collides.Find(x => x.tag == "Player").GetComponent<Player>());
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
