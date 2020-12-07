using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Chuyen
{
    public class Weapon : MonoBehaviour
    {
        public Transform firePoint;
        public GameObject bulletPrefab;
        public PauseUI paused;
        public Animator anim;

        public bool actack;
        public Rigidbody2D r2;

        private void Start()
        {


            paused = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<PauseUI>();
            anim = gameObject.GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {



            if (paused.pause == false)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    actack = true;
                    Shoot();

                }

            }

            void Shoot()
            {
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            }

        }
        private void HandleActacks()
        {
            if (actack)
            {
                anim.SetTrigger("Actack");

            }
        }
        private void ResetValues()
        {
            actack = false;
        }
        void FixedUpdate()
        {
            HandleActacks();
            ResetValues();
        }
    }
}