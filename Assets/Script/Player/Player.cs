using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float Hp = 100;
	public float FireWallBreakPoint = 0;
    public float Resou = 2;

    public Image HpBar;
    public Image ManaBar;

    public GameObject[] towers;
    public GameObject towerset;
    //public GameObject player;
    public GameObject bullet;
    public GameObject gun;
    public GameObject Die;

    //public GameObject TI1;
    //public GameObject TI2;

    public Animator UIAni;

    bool Build = true;
    bool T1 = false;
    bool T2 = false;

    public bool pasued = false;

	public NPC.NPCUnit.UnitLocation currentLocation {
		get {
			return mCurrentLocation;
		}
		set {
			mCurrentLocation = value;
		}
	}
	private NPC.NPCUnit.UnitLocation mCurrentLocation = NPC.NPCUnit.UnitLocation.Room;

	public Map _map;
    // Use this for initialization
    void Start () {
		_map = GameObject.Find("Map").GetComponent<Map>();
	}

	
	// Update is called once per frame
	void Update ()
    {
       // HpBar.fillAmount = Hp / 100;
		//ManaBar.fillAmount = FireWallBreakPoint / 100;

		if (Hp <= 0 || FireWallBreakPoint >= 100)
        {
            Hp = 0;
			FireWallBreakPoint = 100;
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
        //int A = 0;

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
            //UIAni.SetTrigger("Back");
            T1 = false;
            T2 = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //UIAni.SetTrigger("Event1");
            T1 = true;
            T2 = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //UIAni.SetTrigger("Event2");
            T1 = false;
            T2 = true;
        }

        if (Input.GetKeyDown(KeyCode.Q) && T1 == true && Build == true)
        {
            Instantiate(towers[0], towerset.transform.position, towerset.transform.rotation);
            Resou--;
        }

        if (Input.GetKeyDown(KeyCode.Q) && T2 == true && Build == true)
        {
            Instantiate(towers[1], towerset.transform.position, towerset.transform.rotation);
            Resou--;
        }
    }

}
