using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float Hp = 100;
    public float FireWallBreakPoint = 0;
    public float Resou = 5;

    public GameObject[] towers;
    public GameObject towerset;
    //public GameObject player;
    public GameObject bullet;
    public GameObject gun;
    public GameObject Die;

    bool Build = true;
    bool T1 = false;
    bool T2 = false;

    public bool pasued = false;
	public NPC.NPCUnit.UnitLocation currentLocation = NPC.NPCUnit.UnitLocation.Room;
	Map _map;
    // Use this for initialization
    void Start () {
		_map = GameObject.Find("Map").GetComponent<Map>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Hp <= 0 || FireWallBreakPoint >= 100)
        {
            Die.SetActive(true);                                   
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        }

        TowerM();

	}

    void TowerM()
    {
        int A = 0;
		Grid grid = _map.FindTileByPos(new Vector2( Mathf.RoundToInt(towerset.transform.position.x), Mathf.RoundToInt(towerset.transform.position.y) ) );

        if (Resou <= 0)
        {
            Build = false;
        }
        else
        {
            Build = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && T1 == false && T2 == false && pasued == false)
        {
            Die.SetActive(true);
            pasued = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && T1 == false && T2 == false && pasued == true)
        {
            Die.SetActive(false);
            pasued = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            T1 = false;
            T2 = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            T1 = true;
            T2 = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            T1 = false;
            T2 = true;
        }

        if (Input.GetKeyDown(KeyCode.Q) && T1 == true && Build == true)
        {
			Instantiate(towers[0], grid.gridPosition, towerset.transform.rotation);
            Resou--;
        }

        if (Input.GetKeyDown(KeyCode.Q) && T2 == true && Build == true)
        {
			Instantiate(towers[1], grid.gridPosition, towerset.transform.rotation);
            Resou--;
        }
    }

}
