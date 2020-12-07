using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemy : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public SoundsManager soundsManager;


    // Start is called before the first frame update
    void Start()
    {
        soundsManager = GameObject.FindGameObjectWithTag("Sounds").GetComponent<SoundsManager>();
        StartCoroutine(Shooting());
    }
    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(2);// chờ trong 1s
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        soundsManager.Playsound("gunakm");
        StartCoroutine(Shooting());
    }
}
