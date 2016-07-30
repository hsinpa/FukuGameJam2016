﻿using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System.Linq;

public class Map : MonoBehaviour {
	public static int width =10, height = 10;
	
	public List<Grid> grids = new List<Grid>();

	public Grid FindTileByPos(Vector2 p_grid) {

		return grids.Find( x=> x.gridPosition  == p_grid);
	}

	public void PreSet() {
		grids = GetComponentsInChildren<Grid>().ToList();
		grids.ForEach(delegate(Grid obj) {
			obj.tile = new Tile(obj.transform.position, (int)obj.gridPosition.x, (int)obj.gridPosition.y, new JSONObject() );	
		});

	}
}