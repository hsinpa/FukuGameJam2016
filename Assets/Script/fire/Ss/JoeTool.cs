﻿using UnityEngine;
using System.Collections;

public class JoeTool : MonoBehaviour {
    public static void LookAt2D(Transform obj , Vector3 target)
    {
        //Vector3 pos = new Vector2(obj.position.x, obj.position.y);
        //Vector3 p = pos - target;
        Vector3 relativePos = target - obj.position;
        obj.up = relativePos;
        //Quaternion rotation = Quaternion.LookRotation(relativePos,obj.up);
        //obj.rotation = new Quaternion(0, 0, rotation.z, 0); ;
        
    }
	
}
