using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEditor;

public class EditorMapGeneration : Editor {
	static Sprite[] MapSprite;
	
	[MenuItem ("Editor/Generate Map")]
	static void DoSomethingWithAShortcutKey () {

		MapSprite = Resources.LoadAll<Sprite>("Room/room_demo");
		TextAsset[] mapData = Resources.LoadAll<TextAsset>("Room");

		foreach (TextAsset textAsset in mapData) {
			JSONObject mapJson = new JSONObject(textAsset.ToString());
			int height = (int) mapJson.GetField("height").n, width = (int)mapJson.GetField("width").n;
			DrawMap( mapJson.GetField("layers").list, height, width );


		}


	}

	static public void DrawMap(List<JSONObject> layers, int height, int width) {
		GameObject prefab = Resources.Load<GameObject>("Prefab/EmptyGround");
		GameObject roomPrefab = Resources.Load<GameObject>("Prefab/EmptyRoom");

		GameObject gameBoard =  GameObject.Find("Map");
//		GameObject roomBoard = Instantiate(roomPrefab, new Vector3(width/2, height/2, 0), prefab.transform.rotation) as GameObject;
//		roomBoard.transform.SetParent( gameBoard.transform );
		for (int order = 0; order < layers.Count; order++ ) {
			int i = 0;
			
			for (int y = height; y > 0; y-- ) {
				for (int x = 1; x <= width; x++ ) {
					if (layers[order].GetField("type").str == "tilelayer") {
						DrawLayer(layers[order], gameBoard, prefab, new Vector2(x,y), i, order);
					}

					i++;
					}
			}	
		}
	}

	static public void DrawLayer( JSONObject layer, GameObject gameBoard, GameObject prefab, Vector2 pos, int imageIndex, int orderIndex ) {
		
		//string layerTitle = layer.GetField("name").str;

					List<JSONObject> json = layer.GetField("data").list;
					int index =(int) json[imageIndex].n - 1;
					if (json[imageIndex].n != 0) {
							GameObject mapMaster;
							mapMaster = Instantiate(prefab, pos, prefab.transform.rotation) as GameObject;
							mapMaster.transform.parent =  gameBoard.transform;
							mapMaster.layer = 9;
							Grid gridScript = mapMaster.GetComponent<Grid>();
							gridScript.tile = new Tile(gridScript.gridPosition, (int)pos.x, (int)pos.y, layer.GetField("properties"));

							//mapMaster.GetComponent<BoxCollider2D>().enabled = true;
							mapMaster.name = pos.ToString();

//							gridScript.tile.UpdateInfo(layer.GetField("properties"));
							mapMaster.transform.parent = mapMaster.transform;
							mapMaster.GetComponent<SpriteRenderer>().sprite = MapSprite[ index ];
							mapMaster.GetComponent<SpriteRenderer>().sortingOrder = orderIndex;
							mapMaster.transform.localScale = new Vector2(0.8f, 0.8f);
					}
		}

}
