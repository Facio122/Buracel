using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PLayer"))
        {
            _funPlayerDead();
        }
    }

    private void _funPlayerDead()
    {
        GlobalVariables.isPlayerAlive = false;
    }
}
