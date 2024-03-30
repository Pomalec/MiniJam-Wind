
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class weapon : MonoBehaviour
{
    public Animator animator;
    public Transform firePoint;
    public GameObject bulletPrefab;
    
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {

            animator.SetBool("isfiring", true);
            
            Shoot();

        }
       
        
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
    }
}
