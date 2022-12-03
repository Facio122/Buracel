using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRolling : MonoBehaviour
{
    private Rigidbody2D _rbPlayer;
    private Transform _trPlayer;
    [SerializeField] private float _speedHorizontal = 1f;
    [SerializeField] private float _speedRotate = 1f;
    void Start()
    {
        _rbPlayer= gameObject.GetComponent<Rigidbody2D>();
        _trPlayer= gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _funMovement();
        _funRollingRotate();
    }

    private void _funRollingRotate()
    {
        float rotation = -90 * _speedRotate * _rbPlayer.velocity.x / 100;
        _trPlayer.Rotate(new Vector3(0f, 0f, rotation));
    }

    private void _funMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        _rbPlayer.velocity = new Vector2(_rbPlayer.velocity.x + horizontalMovement * _speedHorizontal, _rbPlayer.velocity.y);
    }
}
