using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostLeftController : MonoBehaviour
{
    [SerializeField] private GameObject _objectPlayer;
    [SerializeField] private float _boostPower;
    private Rigidbody2D _rbPlayer;

    void Start()
    {
            _rbPlayer = _objectPlayer.GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _rbPlayer.AddForce(new Vector3(-20f, 0f, 0f), ForceMode2D.Impulse);
        }
    }
}
