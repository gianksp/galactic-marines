var minLife : float = 0.01;
var maxLife : float = 0.02;

private var destroyTime : float;
private var angle : float;

public var list: Material[];
var random = new System.Random();


function Awake() {
    var number = random.Next(0,list.Length);
    gameObject.GetComponent.<Renderer>().material = list[number];
}

function Start(){
	destroyTime = Time.time + Random.Range(minLife, maxLife);
	angle = 45 * Mathf.Round(Random.Range(0,6));
}

function Update () {
	if (Time.time > destroyTime){
		Destroy(gameObject);
	}
	transform.LookAt(Camera.main.transform.position);
	transform.localRotation.eulerAngles.x += angle;
}