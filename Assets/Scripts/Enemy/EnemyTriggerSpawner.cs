using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerSpawner : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] Transform SpawnPosition;
    [SerializeField] int EnemyNumber = 1;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        // a spawner will spawn EnemyNumber amount of enemies before destroying itself
        if (other.gameObject.tag == "Player")
        {
            for (int i= 0; i != EnemyNumber; i++)
            {
                GameObject newEnemy = Instantiate(Enemy, SpawnPosition.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        
    }
}
