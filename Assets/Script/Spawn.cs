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
    Vector3 GenratePosition1()
    {
        float spawnPosX = 57.16f;
        float spawnPosz = 94f;
        float spawnPosY = 7f;
        Vector3 pos=new Vector3(spawnPosX,spawnPosY,spawnPosz);
        return pos;
    }
    Vector3 GenratePosition2()
    {
        float spawnPosX = 9.74f;
        float spawnPosz = 88f;
        float spawnPosY = 10.03f;
        Vector3 pos = new Vector3(spawnPosX, spawnPosY, spawnPosz);
        return pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {
        
        Instantiate(enemyPefab, GenratePosition1(), enemyPefab.transform.rotation);
        Instantiate(enemyPefab, GenratePosition2(), enemyPefab.transform.rotation);
        Instantiate(enemyPefab, transform.position, enemyPefab.transform.rotation);
    }
    }
