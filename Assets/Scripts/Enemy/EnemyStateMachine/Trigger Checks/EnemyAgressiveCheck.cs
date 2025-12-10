using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgressiveCheck : MonoBehaviour
{
    // Class Attached to Gameobject With a Collider
    // The Gameobject is A child of the Enemy Gameobject
    public GameObject PlayerTarget {  get; set; }
    private Enemy _enemy;
    private void Awake()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
        _enemy = GetComponentInParent<Enemy>();
    }
    // Called when A collider "collides" with the "Trigger" collider attached to the Gameobject
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == PlayerTarget)
        {
            // Sets the Aggro Status
            _enemy.SetAggressiveStatus(true);
        }
    }
    // Called when the collider stops "colliding" with the "trigger" collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == PlayerTarget)
        {
            _enemy.SetAggressiveStatus(false);
        }
    }
}
