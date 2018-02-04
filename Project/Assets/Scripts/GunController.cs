using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {


    public GameObject BulletSpawn;
    public GameObject Bullet;
    public GameObject Explosion;

    int bulletSpeed = 2000;

    Animation shoot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /* need to integrate with oculus here */
		if (Input.GetMouseButtonDown(0))
        {
            shoot = gameObject.GetComponent<Animation>();
            shoot.Play();
            Invoke("stopShooting", shoot.clip.length);
            GameObject b = Instantiate(Bullet, BulletSpawn.transform.position, Quaternion.identity);
            b.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * bulletSpeed);
        }
	}
    void stopShooting()
    {
        shoot.Stop();
    }
}
