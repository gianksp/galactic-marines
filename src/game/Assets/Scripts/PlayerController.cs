using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;

    private bool die = false;
    public Gun gun;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!die)
        {
            //Get the Screen positions of the object
            Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

            //Get the Screen position of the mouse
            Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

            //Get the angle between the points
            float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

            //Ta Daaa
            transform.rotation = Quaternion.Euler(new Vector3(0f, 270 - angle, 0f));

            float x = Input.GetAxis("Horizontal") * Time.deltaTime * 1.0f;
            float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                z += 0.08f;
                x = 0; // Cant strafe while running
            }

            if (Input.GetKey(KeyCode.Space))
            {
                animator.SetTrigger("Reload");
                gun.Reload();
            }

            if (Input.GetMouseButton(0) && !gun.IsReloading())
            {
                if (gun.GetAmmoCount() == 0) {
                    animator.SetTrigger("Reload");
                    gun.Reload();
                } else {
                    gun.Shoot();
                }
            }
            else
            {
                //curSpeed = Mathf.Lerp(curSpeed, z, Time.deltaTime);
                //Debug.Log(curSpeed);
                //transform.Rotate(0, x, 0);
                transform.Translate(x, 0, z);
                gun.StopShooting();
            }


            animator.SetFloat("Speed", z);
            animator.SetFloat("SpeedH", x);
            animator.SetBool("Firing", gun.IsFiring());
        } else {
            
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet" && !die) {
            Debug.Log("Die");
            die = true;
            animator.SetTrigger("Die");
            if (transform.tag == "Player")
            {
                GameController.over = true;
            }
            Destroy(gameObject, 1.5f);
        }
    }

}
