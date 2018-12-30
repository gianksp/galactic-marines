using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public int magazineSize = 30;
    public float reattack = 0.1f;

    public AudioClip sound;


    public GameObject bullet;
    public GameObject muzzleFire;
    public BulletCaseGenerator bulletCaseGenerator;

    public Transform muzzle;


    private bool _canShoot = true;
    private bool _reloading = false;
    private bool _isFiring = false;

    private int _magazine = 0;
    private AudioSource _audioSource;

	// Use this for initialization
	void Start () {
        _audioSource = GetComponent<AudioSource>();
        SetAmmoCount(magazineSize);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Shoot() {  
        if (CanShoot()){
            SetFiring(true);
            StartCoroutine("Fire");
        }
    }

    public void StopShooting() {
        StopCoroutine("Fire");
        _canShoot = true;
        SetFiring(false);
    }

    public bool IsFiring() {
        return _isFiring;
    }

    public void SetFiring(bool firing) {
        _isFiring = firing;
    }

    public void Reload() {
        SetAmmoCount(0);
        _reloading = true;
        Invoke("ResetMagazine", 2.25f);
    }

    public int GetAmmoCount() {
        return _magazine;
    }

    public void SetAmmoCount(int ammo) {
        _magazine = ammo;
    }

    public bool IsReloading() {
        return _reloading;
    }

    private void ResetMagazine() {
        _magazine = magazineSize;
        _reloading = false;
    }

    private IEnumerator Fire() {
        _canShoot = false;

        yield return new WaitForSeconds(reattack);

        // Create the Bullet from the Bullet Prefab
        var fire = (GameObject)Instantiate(muzzleFire, muzzle.position, transform.root.localRotation);

        var projectile = (GameObject)Instantiate(bullet, muzzle.position, transform.rotation);
        projectile.GetComponent<Bullet>().source = transform.tag;
        _audioSource.PlayOneShot(sound);

        int ammo = GetAmmoCount() - 1;
        SetAmmoCount(ammo);

        // Add velocity to the bullet
        projectile.GetComponent<Rigidbody>().AddForce(muzzle.forward * 700.0f);

        // Show case
        bulletCaseGenerator.DiscardCase();

        // Destroy the bullet after 2 seconds
        Destroy(projectile, 2.0f);

        _canShoot = true;
    }

    private bool CanShoot() {
        if (_canShoot && GetAmmoCount() > 0)
            return true;
        return false;
    }



}
