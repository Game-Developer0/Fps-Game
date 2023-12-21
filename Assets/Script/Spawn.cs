using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject enemyPefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy",5,10);   
    }
    Vector3 GenratePosition()
    {
        float spawnPosX = Random.Range(52,65);
        float spawnPosz = Random.Range(78, 89);
        Vector3 pos=new Vector3(spawnPosX,6f,spawnPosz);
        return pos;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {
        for (int i = 0; i < 2; i++)
        {
            Instantiate(enemyPefab, GenratePosition(), enemyPefab.transform.rotation);
        }
    }
    }
