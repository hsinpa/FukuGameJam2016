#pragma strict
var SHOWING_FX : boolean = true;
var fx_explotion : GameObject;
var trail : ParticleSystem;
var speed : float = 1.5;
var initial_speed : float = 0;
var max_speed : float = 25;
var accel : float = 3;
var distance_to_live : float = 10;

var GO : boolean = false;
var EXPLOSIVE : boolean = false;
var OSCILATE : boolean = false;
var owner : GameObject;
var sr : SpriteRenderer;

var traveled_distance : float = 0;
//oscilation parameters..
private var A : float;
private var W : float;
private var phi : float;


function Awake () {
	sr = GetComponent(SpriteRenderer);
	if(transform.parent != null)
		transform.parent = null;
	if(trail != null)
		trail.enableEmission = false;
}


function Update () {
	if(GO){
		if(speed < max_speed)
			speed += accel * Time.deltaTime;
		if (OSCILATE){
			if(A >= 0.001)
				A -= 0.2 * Time.deltaTime;
			transform.Translate( A*Mathf.Sin(W*Time.time + phi), Time.deltaTime * speed + 0.75*A*Mathf.Sin(W*Time.time + phi), 0);
		}else{
			transform.Translate(0, Time.deltaTime * speed, 0);
		}		
		traveled_distance += Time.deltaTime * speed;
		if (traveled_distance >= distance_to_live){
			Stop();
		}			
	}
}


function Go (pos_x, pos_y, rot){	
	transform.position = Vector3(pos_x, pos_y, 0);
	transform.rotation.eulerAngles.z = rot;
	speed = initial_speed;
	if (OSCILATE){
		A = Random.Range(0.125, 0.2);
		W = Random.Range(5.0, 12.5);
		phi = Random.Range(-155.0, 155.0);
	}
	GO = true;
	if(trail != null && SHOWING_FX){
		yield WaitForSeconds(0.135);
		trail.enableEmission = true;
	}
}



function Stop (){	
	GO = false;
	
	if(fx_explotion != null && SHOWING_FX)
		Instantiate(fx_explotion, Vector3(transform.position.x, transform.position.y, -5), transform.rotation);
	if(EXPLOSIVE)
		M_Sound.sm.Sound("explotion");	
					
	transform.position.z = 10;
	traveled_distance = 0;
	if(trail != null)
		trail.enableEmission = false;
}


function OnTriggerEnter2D(other: Collider2D) {
	if(other.tag == "ship"){
		if(other.gameObject != owner){
			Stop();			
		}					
	}	
}