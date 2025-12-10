using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackableCheck : MonoBehaviour
{
    // Class Attached to Gameobject With a Collider
    // The Gameobject is A child of the Enemy Gameobject
    private Enemy _enemy;
    private void Awake()
    {
        _enemy = GetComponentInParent<Enemy>();
    }
    // Called when A collider "collides" with the "Trigger" collider attached to the Gameobject
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Sets Attackable Status
            _enemy.SetAttackableStatus(true);
        }
    }
    // Called when the collider stops "colliding" with the "trigger" collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _enemy.SetAttackableStatus(false);
        }
    }
}
