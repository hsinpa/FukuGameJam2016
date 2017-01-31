using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int hp_point;
	public float FireWallBreakPoint = 0;
    public float Resou = 2;

    private Grid currentGrid;
	private Room currentRoom;

    public GameObject[] HpObj;
    //public Image HpBar;
    public Image ManaBar;
    public Text ResT;

    public GameObject[] towers;
    public GameObject towerset;
    //public GameObject player;
    public float cd=0.5f;
    float tt =0;
    public GameObject bullet;
    public GameObject bulletFire;
    public ParticleSystem fx_muzzleshot;
    public GameObject Die;

    public GameObject DieUI;
    public GameObject PasUI;

    public AudioSource TowerAs;
    public AudioClip[] TowerSo;

    private float restoreDelay = 0.5f;
    public float cRestoreDelay;
    private float restorePoint = 1f;

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
        Time.timeScale = 1f;
        _map = GameObject.Find("Map").GetComponent<Map>();

		hp_point = HpObj.Length;
	}

	
	// Update is called once per frame
	void Update ()
    {
        ManaBar.fillAmount = FireWallBreakPoint / 100;

        ResT.text = Resou.ToString();

		if (hp_point <= 0 || FireWallBreakPoint >= 100)
        {
            hp_point = 0;
            //FireWallBreakPoint = 100;
            Die.SetActive(true);
            StartCoroutine(_map._game.GameOver());
            //Destroy(PasUI);
        }
        
		if ( Input.GetMouseButton(0) && Time.time>tt)
        {
            Instantiate(bullet, transform.position+ (transform.up), transform.rotation);
            fx_muzzleshot.Emit(1);
            tt = Time.time + cd;
           // Instantiate(bulletFire, gun.transform.position, gun.transform.rotation);
        }

        TowerM();
        RestoreBreakPoint();

        //Check Location
		Grid mGrid = _map.FindTileByPos( new Vector2( Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y)) );
		if (mGrid != null) {
			if (mGrid.mRoom != currentRoom && mGrid.mRoom.r_type == Room.RoomType.Room) {
				mGrid.mRoom.RaiseAlarm();
				if (_map._game.currentStatus == Game.Status.SaveHostage) _map._hostage.SendToCenterPoint(mGrid.mRoom.CenterPoint.tile.position);
			}
			currentRoom = mGrid.mRoom;
		}


    }

	public void Damage() {
		if (hp_point > 0) {
			HpObj[hp_point - 1].SetActive(false);
        	hp_point--;
		}
    }


    public GameObject was;

    public void RestoreBreakPoint() {
        if (cRestoreDelay > Time.time) return;
        cRestoreDelay = Time.time + restoreDelay;

        if (FireWallBreakPoint > 0)
        {
            was.SetActive(false);
            FireWallBreakPoint -= restorePoint;
        }

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
            Time.timeScale = 0f;
            PasUI.SetActive(true);
            //Die.SetActive(true);
            pasued = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && T1 == false && T2 == false && pasued == true)
        {
            //Die.SetActive(false);
            Time.timeScale = 1f;
            PasUI.SetActive(false);
            pasued = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIAni.SetTrigger("Back");
            AudioSource SF = TowerAs.GetComponent<AudioSource>();
            SF.PlayOneShot(TowerSo[1]);
            T1 = false;
            T2 = false;
        }

        if (Resou >= 1)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                UIAni.SetTrigger("T1");
//                AudioSource SF = TowerAs.GetComponent<AudioSource>();
//                SF.PlayOneShot(TowerSo[0]);
                Instantiate(towers[0], towerset.transform.position, towerset.transform.rotation);
                Resou--;
                T1 = true;
                T2 = false;
            }
        }

        if (Resou >= 2)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                UIAni.SetTrigger("T2");
//                AudioSource SF = TowerAs.GetComponent<AudioSource>();
//                SF.PlayOneShot(TowerSo[0]);

                Instantiate(towers[1], towerset.transform.position, towerset.transform.rotation);
                Resou -= 2;

                T1 = false;
                T2 = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && T1 == true && Build == true)
        {

        }

        if (Input.GetKeyDown(KeyCode.Q) && T2 == true && Build == true)
        {

        }
    }

}
