using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Transform weaponHold;
    
    [SerializeField]
    private float waitTime;

    void Start()
    {
        StartCoroutine("WaitAndShoot");
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab,weaponHold.position,Quaternion.identity);
    }

    private IEnumerator WaitAndShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Shoot();
        }
    }
}
