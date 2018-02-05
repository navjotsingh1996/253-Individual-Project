using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunData : MonoBehaviour {

    public GameObject[] GunObjects;
    [HideInInspector]
    public List<GunData> Guns = new List<GunData>();
    GameObject obj;
    string type;
    string name;
    bool wait;
    int clipLength;
    float reloadTime;
    AudioClip shot;
    AudioClip reload;

    public string getType() { return type; }
    public string getName() { return name; }
    public bool getWait() { return wait; }
    public int getClipLength() { return clipLength; }
    public float getReloadTime() { return reloadTime; }
    public AudioClip getShot() { return shot; }
    public AudioClip getReload() { return reload; }


    GunData(GameObject ob,  string tp, string nm, bool wt, int cl, float rt, AudioClip st, AudioClip rl)
    {
        obj = ob;
        type = tp;
        name = nm;
        wait = wt;
        clipLength = cl;
        reloadTime = rt;
        shot = st;
        reload = rl;
    }

    GunData()
    {
        obj = null;
        type = "";
        name = "";
        wait = false;
        clipLength = 0;
        reloadTime = 0;
        shot = null;
        reload = null;
    }

    // Use this for initialization
    void Awake () {
		for (int i = 0; i < GunObjects.Length; i++)
        {
            GunData gd = new GunData();
            GameObject g = GunObjects[i];
            GunAudio ga = g.GetComponent<GunAudio>();
            switch (g.tag)
            {
                case "SMG":
                    gd = new GunData(g, g.tag, g.name, false, 45, 3, ga.shooting, ga.reloading);
                    break;
                case "AR":
                    gd = new GunData(g, g.tag, g.name, false, 35, 5, ga.shooting, ga.reloading);
                    break;
                case "Handgun":
                    gd = new GunData(g, g.tag, g.name, true, 15, 1, ga.shooting, ga.reloading);
                    break;
                default:
                    break;
            }
            Guns.Add(gd);
        }
	}
}
