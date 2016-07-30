#pragma strict
static var fxm : M_FX;
var explotion : ParticleSystem;
var bullet_spark : ParticleSystem;
var laser_spark : ParticleSystem;
var glow_red : ParticleSystem;
var glow_blue : ParticleSystem;

var SHOWING_FX : boolean = true;



function Awake () {
	fxm = this;
}



function FX (name : String, emit : int, where : Vector2) {
if(SHOWING_FX){

	switch(name){
		case "explotion":
			explotion.transform.position = Vector3(where.x, where.y, -5);
			explotion.Emit(emit);
			break;
		case "bullet_spark":
			bullet_spark.transform.position = Vector3(where.x, where.y, -5);
			bullet_spark.Emit(emit);
			break;
		case "laser_spark":
			laser_spark.transform.position = Vector3(where.x, where.y, -5);
			laser_spark.Emit(emit);
			break;
		case "glow_red":
			glow_red.transform.position = Vector3(where.x, where.y, -5);
			glow_red.Emit(emit);
			break;
		case "glow_blue":
			glow_blue.transform.position = Vector3(where.x, where.y, -5);
			glow_blue.Emit(emit);
			break;
	}
	
}	
}