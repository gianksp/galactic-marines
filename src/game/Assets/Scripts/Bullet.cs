using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public string source;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (source == "Player" && collision.transform.tag == "Enemy") {
            GameController.AddScore();
        }
        Destroy(gameObject);
    }
}
