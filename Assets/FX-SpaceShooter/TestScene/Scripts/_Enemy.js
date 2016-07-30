#pragma strict
var fx_shield : ParticleSystem;
var SHOWING_FX : boolean = true;


function OnTriggerEnter2D(other: Collider2D) {
	if(other.tag == "ammo" && SHOWING_FX){
		fx_shield.Emit(1);					
	}	
}
