using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject enemyPefab;
    [SerializeField] GameObject enemy1Pefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBear",5,10);
        InvokeRepeating("SpawnDino",40 , 10);
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
    void SpawnBear()
    {
        
        Instantiate(enemyPefab, GenratePosition1(), enemyPefab.transform.rotation);
        Instantiate(enemyPefab, GenratePosition2(), enemyPefab.transform.rotation);
        Instantiate(enemyPefab, transform.position, enemyPefab.transform.rotation);
    }
    Vector3 GenratePosition3()
    {
        float spawnPosX = 2.81f;
        float spawnPosz = 65.6f;
        float spawnPosY = 5.33f;
        Vector3 pos = new Vector3(spawnPosX, spawnPosY, spawnPosz);
        return pos;
    }
    Vector3 GenratePosition4()
    {
        float spawnPosX = 80.39f;
        float spawnPosz = -29.34f;
        float spawnPosY = 14.62f;
        Vector3 pos = new Vector3(spawnPosX, spawnPosY, spawnPosz);
        return pos;
    }
    void SpawnDino()
    {
        Instantiate(enemy1Pefab, GenratePosition3(), enemy1Pefab.transform.rotation);
        Instantiate(enemy1Pefab, GenratePosition4(), enemy1Pefab.transform.rotation);
    }
    }
