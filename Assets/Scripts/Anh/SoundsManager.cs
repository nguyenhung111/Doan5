using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public AudioClip gunAKM, jump, die;

    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        gunAKM = Resources.Load<AudioClip>("AK");
        jump = Resources.Load<AudioClip>("Ping");
        die = Resources.Load<AudioClip>("death1");

        audio = GetComponent<AudioSource>();
    }


    public void Playsound(string clip)
    {
        switch (clip)
        {
            case "gunakm":
                audio.clip = gunAKM;
                audio.PlayOneShot(gunAKM, 0.6f);
                break;

            case "jump":
                audio.clip = jump;
                audio.PlayOneShot(jump, 0.6f);
                break;

            case "die":
                audio.clip = die;
                audio.PlayOneShot(die, 1f);
                break;
        }
    }
}
