using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCaseGenerator : MonoBehaviour {

    public GameObject prefab;
    public Vector3 velocity;

    public void DiscardCase() {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject bulletCase = (GameObject)Instantiate(prefab, pos, transform.rotation);
        bulletCase.GetComponent<BulletCase>().velocity = transform.TransformDirection(velocity) + Random.insideUnitSphere * 2.0f;
        Destroy(bulletCase, 1.0f);
    }
}