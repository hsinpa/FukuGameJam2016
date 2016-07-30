using UnityEngine;
using System.Collections;

public class lookk : MonoBehaviour {
    public Transform target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        JoeTool.LookAt2D(transform, target.position);
	}
}
