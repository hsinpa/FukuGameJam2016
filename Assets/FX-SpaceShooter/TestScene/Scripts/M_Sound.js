#pragma strict
static var sm : M_Sound;
var MUTE : boolean = false;
var item : AudioSource;
var click : AudioSource;
var firing_missile : AudioSource[];
var i_firing_missile : int = 0;
var explotion : AudioSource[];
var i_explotion : int = 0;
var firing_bullets : AudioSource[];
var i_firing_bullets : int = 0;
var firing_laser : AudioSource[];
var i_firing_laser : int = 0;



function Awake () {
	sm = this;
}

function ToggleMute(){
	MUTE = !MUTE;
}

function Sound (name : String) {
	if(!MUTE){
		switch(name){
			case "click":
				click.Play();
				break;
			case "item":
				item.Play();
				break;
			case "firing_missile":
				firing_missile[i_firing_missile].pitch = Random.Range(1.15, 1.4);
				firing_missile[i_firing_missile].Play();
				i_firing_missile++;
				if(i_firing_missile >= firing_missile.Length)
					i_firing_missile = 0;
				break;			
			case "explotion":
				explotion[i_explotion].pitch = Random.Range(1, 1.3);
				explotion[i_explotion].Play();
				i_explotion++;
				if(i_explotion >= explotion.Length)
					i_explotion = 0;
				break;
			case "bullet_spark":
				//DO AWESOME STUFF!
				break;
			case "laser_spark":
				//DO AWESOME STUFF!
				break;
			case "firing_laser":
				firing_laser[i_firing_laser].pitch = Random.Range(1.75, 2.0);
				firing_laser[i_firing_laser].Play();
				i_firing_laser++;
				if(i_firing_laser >= firing_laser.Length)
					i_firing_laser = 0;
				break;
			case "firing_bullet":
				firing_bullets[i_firing_bullets].pitch = Random.Range(0.9, 1.1);
				firing_bullets[i_firing_bullets].Play();
				i_firing_bullets++;
				if(i_firing_bullets >= firing_bullets.Length)
					i_firing_bullets = 0;
				break;
		}
	}	
}