using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
namespace NPC{

public class NPCUnit : MonoBehaviour {
		public Vector2 _position { get {
				return new Vector2( transform.position.x, transform.position.y );
			}
		}

		public enum UnitLocation { Corridor, Room } 
		public UnitLocation currentLocation = UnitLocation.Room;

		public List<Vector2> paths = new List<Vector2>();
		public float speed = 0.1f;
		public int hp {
			get {
				return mHP;
			}
			set {
				mHP = value;
				if (mHP <= 0 ) GameObject.Destroy(this.gameObject, 0.1f);
			}
		}

		private int mHP = 100;

		protected Pathfinding _path;
		protected Map _map; 
		protected Game _game; 

		public virtual void Start() {
			_map = GameObject.Find("Map").GetComponent<Map>();
			_path = new Pathfinding(_map );
			_game = _map.GetComponent<Game>();
		}


		public void Move(Vector3[] _path, System.Action callback=null) {
			float time = _path.Length * speed;
			Debug.Log(_path.Length);
			transform.DOPath(_path, time, PathType.Linear, PathMode.TopDown2D).SetEase(Ease.Linear).OnComplete(delegate() {
				Debug.Log("DONE");
				if (callback != null) callback();			
			});
		}

		public virtual void Update() {

		}
	}
}