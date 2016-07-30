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

		public List<Vector2> paths = new List<Vector2>();
		public float speed = 0.1f;
		public int hp = 100;

		protected Pathfinding _path;
		protected Map _map; 

		public virtual void Start() {
			_map = GameObject.Find("Map").GetComponent<Map>();
			_path = new Pathfinding(_map );
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