using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageableObject = other.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            damageableObject.TakeDamage(1);
        }
        GameObject.Destroy(gameObject);
    }
}
