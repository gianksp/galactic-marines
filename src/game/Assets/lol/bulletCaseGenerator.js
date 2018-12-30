var bulletCasePrefab : GameObject;
var rate : float = 8.0;
var velocity : Vector3;
var on : boolean = true;
private var nextbulletCaseTime : float;

function Update () {
	if (on){
		if(Time.time > nextbulletCaseTime){
			nextbulletCaseTime = Time.time + (1.0 / rate);
            var pos: Vector3 = new Vector3(transform.position.x,transform.position.y, transform.position.z);
			var newBulletCase : GameObject = Instantiate(bulletCasePrefab,pos,transform.rotation);
			newBulletCase.GetComponent(bulletCase).velocity = transform.TransformDirection(velocity) + Random.insideUnitSphere*2.0f;
            Destroy(newBulletCase, 1.5f);
		}
	}
}