using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
namespace NPC{

public class NPCUnit : MonoBehaviour {
		public Vector2 _position { get {
				return new Vector2(Mathf.RoundToInt( transform.position.x), Mathf.RoundToInt( transform.position.y ) );
			}
		}

		public enum UnitLocation { Corridor, Room } 
		public UnitLocation currentLocation = UnitLocation.Room;

		public List<Vector2> paths = new List<Vector2>();
		public float speed = 0.1f;
        public GameObject DieEffect;
		public int hp {
			get {
				return mHP;
			}
			set {
				mHP = value;
				if (mHP <= 0 ) {
                    Instantiate(DieEffect, transform.position, transform.rotation);
                    
                    //GameObject.Destroy(this);
                    
                    GameObject.Destroy(this.gameObject, 0.5f); 
					if (transform.tag == "Monster") {
						_map.DefeatEnemy();
                        gameObject.tag = "Untagged";
                        if (_map._player.Resou <= 5) _map._player.Resou++;
					} else {
                        Debug.Log("OLDＭＡＮＤEAD0");
						StartCoroutine(_game.GameOver());
					}
				}
			}
		}

		public int mHP = 100;

		protected Pathfinding _path;
		protected Map _map; 
		protected Game _game; 

		public virtual void Start() {
			_map = GameObject.Find("Map").GetComponent<Map>();
			_path = new Pathfinding(_map );
			_game = GameObject.Find("Game").GetComponent<Game>();
		}


		public void Move(Vector3[] _path, System.Action callback=null) {
			if (_path.Length <= 0) return;
			float time = _path.Length * speed;
			transform.DOPath(_path, time, PathType.Linear, PathMode.TopDown2D).SetEase(Ease.Linear).OnComplete(delegate() {
				Debug.Log("DONE");
				if (callback != null) callback();			
			});
		}

		public virtual void Update() {

		}
	}
}