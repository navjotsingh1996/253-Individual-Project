using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum gunType { handgun, ar, lmg, rocket, sniper, smg };
public enum fireRate { semi, multi };

public struct guns
{
    gunType type;
    string name;
    fireRate fr;
    int clipLength;
    float reloadTime;
    AudioClip shot;
    AudioClip reload;
}
