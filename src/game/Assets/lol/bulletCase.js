var life : float = 0.5;

private var destroyTime : float;
var velocity : Vector3;
private var gravity : float = 1.0f;
private var turnSpeed : float;
private var turnAngle : float;

function Start(){
	destroyTime = Time.time + life;
	turnAngle = Random.value * 360;
	turnSpeed = Random.Range(-360.0,360.0);
}

function Update () {
	if(Time.time > destroyTime){
		Destroy(gameObject);
	}
	velocity.y -= gravity * Time.deltaTime;
	transform.position += velocity * Time.deltaTime;
	transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * life * 2.0);
}