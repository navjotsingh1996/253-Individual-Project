using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour {


    public GameObject BulletSpawn;
    public GameObject Bullet;
    public GameObject Explosion;
    public Text ammo;

    int bulletSpeed = 2000;
    bool shooting = false;
    bool reloading = false;
    AudioSource audioSrc;
    GunData gundata;
    GunData myGun;
    int bulletsLeft;
	// Use this for initialition
	void Start () {
        audioSrc = gameObject.GetComponent<AudioSource>();
        gundata = GameObject.FindGameObjectWithTag("GunData").GetComponent<GunData>();
        for (int i = 0; i < gundata.Guns.Count; i++)
        {
            if (gundata.Guns[i].getType() == gameObject.tag)
            {
                myGun = gundata.Guns[i];
            }
        }
        bulletsLeft = myGun.getClipLength();
        ammo.text = "AMMO: " + bulletsLeft;
    }
	
	// Update is called once per frame
	void Update () {

        /* need to integrate with oculus here */
        if (bulletsLeft <= 0 || (Input.GetKeyDown(KeyCode.R) && bulletsLeft != myGun.getClipLength()))
        {
            reloading = true;
            bulletsLeft = myGun.getClipLength();
            ammo.text = "AMMO: RELOADING";
            audioSrc.clip = myGun.getReload();
            audioSrc.Play();
            Invoke("reloaded",myGun.getReloadTime());
        }

        /* need to integrate with oculus here */
		if (Input.GetMouseButton(0) && !shooting && !reloading)
        {
            bulletsLeft--;
            ammo.text = "AMMO: " + bulletsLeft;
            if (myGun.getWait())
            {
                shooting = true;
                Invoke("stopShooting", 0.5f);
            }
            gameObject.GetComponent<Animation>().GetClip("Shoot").wrapMode = WrapMode.Loop;
            gameObject.GetComponent<Animation>().Play();
            audioSrc.clip = myGun.getShot();
            audioSrc.loop = true;
            if (!audioSrc.isPlaying)
            {
                audioSrc.Play();
            }
            GameObject b = Instantiate(Bullet, BulletSpawn.transform.position, BulletSpawn.transform.rotation);
            b.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * bulletSpeed);
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (myGun.getWait())
            {
                audioSrc.loop = false;
            } else
            {
                audioSrc.Stop();
            }
            gameObject.GetComponent<Animation>().GetClip("Shoot").wrapMode = WrapMode.Once;
        }
	}

    void reloaded()
    {
        reloading = false;
        ammo.text = "AMMO: " + myGun.getClipLength();
    }

    void stopShooting()
    {
        shooting = false;
        audioSrc.Stop();
    }


}
