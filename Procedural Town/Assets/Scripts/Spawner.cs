using System.Collections;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public MapGenerator mapGenerator;
    public float EnemyDensity;


    private void Update()
    {

        if (mapGenerator.isPress)
        {
            mapGenerator.isPress = false;
            float temp = mapGenerator.enemyCount * EnemyDensity;

            for (int i = 0; i < (int)temp; i++)
            {
                Transform enemyPosition=mapGenerator.GetRandomOpenCoord();
                Instantiate(enemyPrefab, enemyPosition.position, Quaternion.identity);

            }
        }

        
    }
    



}
