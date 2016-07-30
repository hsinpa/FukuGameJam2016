#pragma strict
static var _player : _Player;

var backgorund_sr : SpriteRenderer;
var enemy_demo : _Enemy;
var highlight : ParticleSystem[];
var fx_thruster1 : ParticleSystem;
var fx_thruster2 : ParticleSystem;
var fx_starfield : Transform;
var fx_itempickup : GameObject;
var fx_muzzleshot : ParticleSystem;
var text_ui_explosion : TextMesh;
var text_ui_bullet : TextMesh;

var ammo_primary : Ammo[];
var ammo_secondary : Ammo[];
private var AP_index : int = 0;
private var AS_index : int = 0;
var aspd : float = 0.5;
var max_speed : float = 10;
var turn_speed : float = 12.5;
var secondary_fire_cooldown : float = 1.5;

var fire_point : Transform[];

private var fire_point_index : int = 0;
var FIRING : boolean = false;

private var secondary_fire_time : float = -0.5;
private var my_rb2d : Rigidbody2D;
private var move_to_x : float = 0;
private var move_to_y : float = 0;
private var turn_to_x : float = 0;
private var turn_to_y : float = 0;
private var ray : Ray;
private var ray_cast_hit : RaycastHit2D;
private var MOVE : boolean = false;
private var TURN : boolean = false;

private var SHOWING_BG : boolean = true;
private var SHOWING_ITEMS : boolean = true;

var showing_fx_name1 : String[];
var showing_fx_1 : GameObject[];
private var i_showing_fx_name1 : int = 0;
var showing_fx_name2 : String[];
var showing_fx_2 : GameObject[];
var showing_bullet : Sprite[];
var showing_muzzler : ParticleSystem[];
var SHOWING_FX : boolean = true;
private var i_showing_fx_name2 : int = 0;


function Awake () {
	_player = this;
	INIT();	
}

function Update () {

	if(MOVE) Move();
	Turn();
	
	if(Input.GetMouseButtonDown(0)){
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		ray_cast_hit = Physics2D.Raycast(Vector2(ray.origin.x, ray.origin.y), Vector2.zero);
		if(	ray_cast_hit ){
			switch(ray_cast_hit.transform.name){
				case "UI ticket - BG":
					M_Sound.sm.Sound("click");
					SHOWING_BG = !SHOWING_BG;
					if(SHOWING_BG){
						backgorund_sr.color.a = 1;
						ray_cast_hit.transform.GetComponent(SpriteRenderer).color.a = 1;
					}else{
						backgorund_sr.color.a = 0;
						ray_cast_hit.transform.GetComponent(SpriteRenderer).color.a = 0;
					}
					break;
				case "UI ticket - item":
					M_Sound.sm.Sound("click");
					SHOWING_ITEMS = !SHOWING_ITEMS;
					if(SHOWING_ITEMS){
						ray_cast_hit.transform.GetComponent(SpriteRenderer).color.a = 1;
						SHOWING_FX = true;
						M_FX.fxm.SHOWING_FX = true;
					}else{
						ray_cast_hit.transform.GetComponent(SpriteRenderer).color.a = 0;
						SHOWING_FX = false;
						M_FX.fxm.SHOWING_FX = false;
					}
					UpdateFX();
					break;
				case "UI ticket - sound":
					M_Sound.sm.ToggleMute();
					M_Sound.sm.Sound("click");
					if(M_Sound.sm.MUTE){
						ray_cast_hit.transform.GetComponent(SpriteRenderer).color.a = 0;
					}else{
						ray_cast_hit.transform.GetComponent(SpriteRenderer).color.a = 1;
					}
					break;
				case "UI arrow":
					ray_cast_hit.transform.GetComponent(Pressed_Button_Anim).Go();
					M_Sound.sm.Sound("click");
					UIArrows(ray_cast_hit.transform.tag);
					break;
				case "__BG":
					move_to_x = ray.origin.x;
					move_to_y = ray.origin.y;
					MOVE = true;
					
					TURN = true;
					turn_to_x = ray.origin.x;
					turn_to_y = ray.origin.y;
					break;
				case "Item-Demo":
					move_to_x = ray.origin.x;
					move_to_y = ray.origin.y;
					MOVE = true;
					
					TURN = true;
					turn_to_x = ray.origin.x;
					turn_to_y = ray.origin.y;
					break;
				default:				
					//Do nothing..					
					break;
			}
		}				
	}
	
	//Star firing
	if ( Input.GetKeyDown("space") ){
		InvokeRepeating("Fire", 0, aspd);		
	}
	
	//Stop firing
	if ( Input.GetKeyUp("space") ){
		CancelInvoke();
		FIRING = false;		
	}

}


function UpdateFX(){
	
	var i = 0;
	//Stop fxs from primary ammo (bullets-lasers)
	for(i = 0; i < ammo_primary.Length; i++){
		ammo_primary[i].SHOWING_FX = SHOWING_FX;
	}
	//Stop fxs from secondary ammo (missiles)
	for(i = 0; i < ammo_secondary.Length; i++){
		ammo_secondary[i].SHOWING_FX = SHOWING_FX;
		if(!SHOWING_FX)
			ammo_secondary[i].trail.enableEmission = false;
	}
	if(SHOWING_FX){
		fx_thruster1.Play();
		fx_thruster2.Play();
		highlight[0].Play();
		highlight[1].Play();
		highlight[2].Play();
		fx_starfield.position.z = 0.85;		
	}else{
		fx_thruster1.Stop();
		fx_thruster2.Stop();
		highlight[0].Stop();
		highlight[1].Stop();
		highlight[2].Stop();
		fx_starfield.position.z = 10;
	}
	enemy_demo.SHOWING_FX =	SHOWING_FX;
	
}


function UIArrows(tag : String){

	var i = 0;
	if(tag == "arrow-e-L"){
		i_showing_fx_name1--;
		if(i_showing_fx_name1 < 0)
			i_showing_fx_name1 = showing_fx_name1.Length - 1;
		text_ui_explosion.text = showing_fx_name1[ i_showing_fx_name1 ];
		for(i = 0; i < ammo_secondary.Length; i++)
			ammo_secondary[i].fx_explotion = showing_fx_1[ i_showing_fx_name1 ];
				
	}
	if(tag == "arrow-e-R"){
		i_showing_fx_name1++;
		if(i_showing_fx_name1 >= showing_fx_name1.Length)
			i_showing_fx_name1 = 0;
		text_ui_explosion.text = showing_fx_name1[ i_showing_fx_name1 ];
		for(i = 0; i < ammo_secondary.Length; i++)
			ammo_secondary[i].fx_explotion = showing_fx_1[ i_showing_fx_name1 ];
	}
	if(tag == "arrow-b-L"){
		i_showing_fx_name2--;
		if(i_showing_fx_name2 < 0)
			i_showing_fx_name2 = showing_fx_name2.Length - 1;
		text_ui_bullet.text = showing_fx_name2[ i_showing_fx_name2 ];
		for(i = 0; i < ammo_primary.Length; i++){
			ammo_primary[i].sr.sprite = showing_bullet[ i_showing_fx_name2 ];
			ammo_primary[i].fx_explotion = showing_fx_2[ i_showing_fx_name2 ];
		}
		fx_muzzleshot = showing_muzzler[ i_showing_fx_name2 ];
	}
	if(tag == "arrow-b-R"){
		i_showing_fx_name2++;
		if(i_showing_fx_name2 >= showing_fx_name2.Length)
			i_showing_fx_name2 = 0;
		text_ui_bullet.text = showing_fx_name2[ i_showing_fx_name2 ];
		for(i = 0; i < ammo_primary.Length; i++){
			ammo_primary[i].sr.sprite = showing_bullet[ i_showing_fx_name2 ];
			ammo_primary[i].fx_explotion = showing_fx_2[ i_showing_fx_name2 ];
		}
		fx_muzzleshot = showing_muzzler[ i_showing_fx_name2 ];
	}
		
}


function Fire (){

	ammo_primary[AP_index].Go(fire_point[fire_point_index].position.x, fire_point[fire_point_index].position.y, transform.rotation.eulerAngles.z);
	fx_muzzleshot.transform.position.x = fire_point[fire_point_index].position.x;
	fx_muzzleshot.transform.position.y = fire_point[fire_point_index].position.y;
	if(SHOWING_FX)
		fx_muzzleshot.Emit(2);
	
	turn_to_x = ray.origin.x;
	turn_to_y = ray.origin.y;
	
	AP_index++;
	if(AP_index >= ammo_primary.Length)
		AP_index = 0;
	
	fire_point_index++;
	if (fire_point_index >= fire_point.Length)
		fire_point_index = 0;
	FIRING = true;
	
	//SOUND!
	if( i_showing_fx_name2 == 3)
		M_Sound.sm.Sound("firing_bullet");
	else
		M_Sound.sm.Sound("firing_laser");			
	
	//SECONDARY FIRE
	if(Time.time >= secondary_fire_cooldown + secondary_fire_time)
		SecondaryFire();

}



function SecondaryFire (){
	secondary_fire_time = Time.time;
	
	for(AS_index = 0; AS_index < 5; AS_index++){
		ammo_secondary[AS_index].Go(transform.position.x, transform.position.y, transform.rotation.eulerAngles.z);
		M_FX.fxm.FX("glow_red", 1, Vector2(transform.position.x, transform.position.y));
		M_Sound.sm.Sound("firing_missile");
		yield WaitForSeconds(0.15);
	}
	if(AS_index >= ammo_secondary.Length)
		AS_index = 0;
}



function Move (){
	var deltaX : float = move_to_x - transform.position.x;
	var deltaY : float = move_to_y - transform.position.y;
	var dist = Vector2.Distance(Vector2(move_to_x, move_to_y), Vector2(transform.position.x, transform.position.y));
		
	my_rb2d.velocity.x = deltaX*max_speed;
	my_rb2d.velocity.y = deltaY*max_speed;
	
	if (my_rb2d.velocity.magnitude >= max_speed){
		var vec : Vector3 = my_rb2d.velocity.normalized;
		my_rb2d.velocity = vec*max_speed;
	}
	if (dist <= 0.25){
		my_rb2d.velocity = Vector2.zero;
		MOVE = false;
		if(!FIRING)
			TURN = false;	
	}
}



function Turn (){
	if(FIRING){
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		TURN = true;
	}
			
	var deltaX : float = turn_to_x - transform.position.x;
	var deltaY : float = turn_to_y - transform.position.y;	
	var angle : float = Mathf.Atan(deltaY/deltaX)*Mathf.Rad2Deg;
		
	if (deltaX < 0)
		angle += 180;
	if (angle < 0)
		angle += 360;
	transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, angle - 90), turn_speed * Time.deltaTime);
}



function INIT (){
	my_rb2d = GetComponent(Rigidbody2D);
	move_to_x = transform.position.x;
	move_to_y = transform.position.y;
	//Initalization primary ammo
	for(AP_index = 0; AP_index < ammo_primary.Length; AP_index++)
		ammo_primary[AP_index].owner = this.gameObject;
	//Initalization secondary ammo
	for(AS_index = 0; AS_index < ammo_secondary.Length; AS_index++)
		ammo_secondary[AS_index].owner = this.gameObject;
	AP_index = 0;
	AS_index = 0;
}


function OnTriggerEnter2D(other: Collider2D) {
	// Picking up items
	if(other.name == "Item-Demo"){
		if(SHOWING_FX)
			Instantiate(fx_itempickup, other.transform.position, other.transform.rotation);
		other.transform.position.x = Random.Range(-4.5, 5.5);
		other.transform.position.y = Random.Range(-2.8, 3.1);
		M_Sound.sm.Sound("item");							
	}	
}

