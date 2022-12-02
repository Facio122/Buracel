using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWalk : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _groundCheckRadius = 0.9f;
    [SerializeField] private float _jumpingSpeed = 1f;
    [SerializeField] private Transform _trGroundCheckPlayer;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private GameObject _objectplayer;

    private Rigidbody2D _playerRb;
    // Start is called before the first frame update
    void Start()
    {
        _playerRb = _objectplayer.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _funMovementPlayer();
        _funJumpingPlayer();
    }

    private void _funMovementPlayer()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        _playerRb.velocity = new Vector3(horizontalAxis * _movementSpeed, _playerRb.velocity.y);
    }
    private void _funJumpingPlayer()
    {
        if (_isSpacePressed() && _isGrounded())
        {
            _playerRb.velocity = new Vector2(_playerRb.velocity.x, _jumpingSpeed);
        }
    }
    private bool _isGrounded()
    {
        bool result = Physics2D.OverlapCircle(_trGroundCheckPlayer.position, _groundCheckRadius, _groundLayer);
        return result;
    }
    private bool _isSpacePressed()
    {
        bool result = Input.GetKeyDown(KeyCode.Space);
        return result;
    }
}
