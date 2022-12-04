using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speedHorizontal;
    [SerializeField] private float _speedVertical;
    [SerializeField] private float _groudCheckRadius;
    [SerializeField] GameObject _objectPlayerFoot;
    [SerializeField] private float _timeJumping;

    private Rigidbody2D _rbPlayer;
    private float _movementHorizontal = 0f;
    private float _timerJumping = 0;
    private bool _isJumping = true;

    void Start()
    {
        _rbPlayer = gameObject.GetComponent<Rigidbody2D>();
        _rbPlayer.gravityScale = GlobalVariables.GravityScale;
    }
    void Update()
    {
        _movementHorizontal = Input.GetAxis("Horizontal");
        _funPlayerMovement();
        _funPlayerJumping();
    }

    private void _funPlayerMovement()
    {
        _rbPlayer.velocity = new Vector2(_movementHorizontal * _speedHorizontal, _rbPlayer.velocity.y);
    }
    private void _funPlayerJumping()
    {
        bool pressedSpace = Input.GetKeyDown(KeyCode.Space);

        if (_isGrounded() && pressedSpace)
        {
            _isJumping = true;
            _rbPlayer.velocity = new Vector2(_rbPlayer.velocity.x, _speedVertical);
            _timerJumping = _timeJumping;
        }
        if (Input.GetKey(KeyCode.Space) && _isJumping)
        {
            if (_timerJumping > 0)
            {
                _rbPlayer.velocity = new Vector2(_rbPlayer.velocity.x, _speedVertical);
                _timerJumping -= Time.deltaTime;
            }
            else _isJumping = false;
        }
        if (Input.GetKeyUp(KeyCode.Space))
            _isJumping = false;
    }
    private bool _isGrounded()
    {
        LayerMask layerGround = LayerMask.GetMask("Ground");
        LayerMask layerMovableObject = LayerMask.GetMask("MovableObject");
        bool Ground = Physics2D.OverlapCircle(_objectPlayerFoot.transform.position, _groudCheckRadius, layerGround);
        bool MovableObject = Physics2D.OverlapCircle(_objectPlayerFoot.transform.position, _groudCheckRadius, layerMovableObject);
        if (Ground || MovableObject)
            return true;
        else
            return false;
    }

}
