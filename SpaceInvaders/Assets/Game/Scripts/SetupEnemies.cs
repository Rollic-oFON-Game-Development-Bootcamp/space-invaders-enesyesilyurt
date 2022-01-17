using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupEnemies : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyPrefabs;

    [Header("Variables")]
    [SerializeField]
    private int rowCount;
    [SerializeField]
    private int coloumCount;
    [SerializeField]
    private float rowOffset;
    [SerializeField]
    private float coloumOffset;
    [SerializeField]
    private float startColoumPos;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float xMin, xMax;

    [SerializeField]
    private float zStep;

    private void Start() {
        transform.position = new Vector3(xMin,0,transform.position.z);
        transform.LeanMoveX(xMax,speed).setEaseInOutSine().setLoopPingPong();
    }

    private void Update() 
    {
        transform.position -= new Vector3(0,0, zStep * Time.deltaTime);
    }

    private void Awake()
    {
        for (int i = 0; i < coloumCount; i++)
        {
            for (int j = -rowCount /2 ; j < rowCount/2+1; j++)
            {
                Instantiate
                (
                    enemyPrefabs[i%3],
                    new Vector3
                    (
                        rowOffset * j* rowCount, 0, coloumOffset * i* coloumCount + startColoumPos
                    ),
                    new Quaternion(Quaternion.identity.x,180,Quaternion.identity.z,Quaternion.identity.w),
                    transform
                );
            }
        }
    }
}
