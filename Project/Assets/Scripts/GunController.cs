using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {


    public GameObject BulletSpawn;
    public GameObject Bullet;
    public GameObject Explosion;

    int bulletSpeed = 2000;
    bool shooting = false;

    Animation shoot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /* need to integrate with oculus here */
		if (Input.GetMouseButtonDown(0) && !shooting)
        {
            shooting = true;
            shoot = gameObject.GetComponent<Animation>();
            shoot.Play();
            GameObject b = Instantiate(Bullet, BulletSpawn.transform.position, BulletSpawn.transform.rotation);
            b.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * bulletSpeed);
            Invoke("stopShooting", 0.5f);
        }
	}
    void stopShooting()
    {
        shooting = false;
    }
}
