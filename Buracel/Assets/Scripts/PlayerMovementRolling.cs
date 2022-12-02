using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRolling : MonoBehaviour
{
    private Rigidbody2D _rbPlayer;
    [SerializeField] private float _speedHorizontal = 1f;
    void Start()
    {
        _rbPlayer= gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _funMovement();
    }

    private void _funRollingRotate()
    {

    }

    private void _funMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        _rbPlayer.velocity = new Vector2(_rbPlayer.velocity.x + horizontalMovement * _speedHorizontal, _rbPlayer.velocity.y);
    }
}
