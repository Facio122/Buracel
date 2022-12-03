using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
       if (collider.CompareTag("Player"))
        {
            _funPlayerDead();
        }
    }

    public void _funPlayerDead()
    {
        Debug.Log("Dead");
        GlobalVariables.isPlayerAlive = false;
    }
}
