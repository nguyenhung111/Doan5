using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip shootSound, DeathSound, ExplisonSound,Bom;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        shootSound = Resources.Load<AudioClip>("danmaybay");
        DeathSound = Resources.Load<AudioClip>("Nomaybay");
        ExplisonSound = Resources.Load<AudioClip>("Nomaybay");
        Bom = Resources.Load<AudioClip>("bom");
        audioSrc = GetComponent<AudioSource>();
    }

    public static void shoot()
    {
        audioSrc.PlayOneShot(shootSound);
    }
    public static void death()
    {
        audioSrc.PlayOneShot(DeathSound);
    }
    public static void Explison()
    {
        audioSrc.PlayOneShot(ExplisonSound);
    }
    public static void Bomroi()
    {
        audioSrc.PlayOneShot(Bom);
    }
}
