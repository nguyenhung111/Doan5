using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public PauseMenu paused;

    public AudioSource audioSource;
    public AudioClip shoot;

    public int currenBullet;
    public int maxBullet = 30;
    public int SLCon;

    public Text bulletcon, bullettong;

    private void Start()
    {
        currenBullet = maxBullet;
        SLCon = 60;
        audioSource = gameObject.GetComponent<AudioSource>();
        paused = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletcon.text = "" + currenBullet;
        bullettong.text = "" + SLCon;
        if (paused.pause == false )
        {
            if (Input.GetButtonDown("Fire1") && currenBullet >0)
            {
                Shoot();

            }
            if(currenBullet < 30 && SLCon > 0)
            {
                if (currenBullet == 0 || Input.GetKeyDown(KeyCode.R))
                {
                    if (currenBullet + SLCon >= 30)
                    {
                        SLCon -= maxBullet - currenBullet;
                        currenBullet = maxBullet;
                    }
                    else
                    {
                        currenBullet += SLCon;
                        SLCon = 0;
                    }

                }
            }
          
        }
    }

    void Shoot()
    {
        audioSource.PlayOneShot(shoot);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        currenBullet -=1;
    }
    public void AddBullet(int bullet)
    {
            SLCon += bullet;
    }
}
