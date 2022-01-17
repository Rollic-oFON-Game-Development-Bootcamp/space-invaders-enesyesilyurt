using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : LivingEntity
{
    [SerializeField]
    private FloatingJoystick joystick;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float speed;

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        transform.position += new Vector3
        (
            joystick.Horizontal * Time.deltaTime * speed,
            0,
            joystick.Vertical * Time.deltaTime * speed
        );

        float positionX;
        if(transform.position.x > 44 || transform.position.x < -44)
        {
            positionX = -transform.position.x;
        }
        else 
        {
            positionX = transform.position.x;
        }

        transform.position = new Vector3(positionX, transform.position.y, Mathf.Clamp(transform.position.z,-18,20));
    }

    private void Rotate()
    {
        transform.rotation = new Quaternion
        (
            Mathf.Lerp(transform.rotation.x, Mathf.Clamp(joystick.Vertical, -.1f, .1f), .04f),
            0,
            Mathf.Lerp(transform.rotation.z, Mathf.Clamp(-joystick.Horizontal, -.1f, .1f), .04f),
            transform.rotation.w
        );
    }
}
