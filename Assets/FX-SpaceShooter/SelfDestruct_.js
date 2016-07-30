#pragma strict
var selfdestruct_in : float = 4; //time to live


function Start () {
	yield WaitForSeconds(selfdestruct_in);
	Destroy(gameObject);
}