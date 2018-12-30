using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCase : MonoBehaviour {

    public Vector3 velocity;
    public float gravity = 0.1f;

    private float _turnAngle;
    private float _turnSpeed;

    // Use this for initialization
    void Start () {
        _turnAngle = Random.value * 360;
        _turnSpeed = Random.Range(-360.0f, 360.0f);
	}
	
	// Update is called once per frame
	void Update () {
        velocity.y -= gravity * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * 2.0f);
	}
}