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
    //
    private Animator _animPlayer;       //zmienna do animacji
    private Transform _trPlayer;

    private Rigidbody2D _playerRb;
    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        _playerRb = _objectplayer.GetComponent<Rigidbody2D>();

        _animPlayer = GetComponent<Animator>();     //anim - grab reference
        _trPlayer = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _funMovementPlayer();
        _funJumpingPlayer();
        //anim
        _funRunningSprite();
        _funFlipSprite();
        _funJumpingSprite();
        //_changeWalkDirection();       //piter code - nie dzia³a

       
    }

  

    private void _funRunningSprite()
    {
        if (Input.GetAxis("Horizontal") != 0)
            _animPlayer.SetBool("run", true);
        else _animPlayer.SetBool("run", false);
    }

    /* private void _changeWalkDirection()
    {

        if (Input.GetAxis("Horizontal") < 0)
            _trPlayer.transform.localScale = new Vector3(1f, -1f);
        else
            _trPlayer.transform.localScale = new Vector3(1f, 1f);
    }*/


    /*private void _funJumpingSprite()
    {
        if (!_isGrounded())
            _animPlayer.SetBool("jump", true);
        else
            _animPlayer.SetBool("jump", false);
        if (!_isGrounded() && _animPlayer.GetBool("run"))
            _animPlayer.SetBool("WalkingToJump", true);
        else
            _animPlayer.SetBool("WalkingToJump", false);
    }*/
    private void _funMovementPlayer()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        _playerRb.velocity = new Vector3(horizontalAxis * _movementSpeed, _playerRb.velocity.y);
    }
 

    private void _funJumpingPlayer()
    {
        if (_isSpacePressed() && _isGrounded())
        {
            _playerRb.velocity = new Vector2(_playerRb.velocity.x,_jumpingSpeed);
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

    private void _funFlipSprite()
{
    if (Input.GetAxis("Horizontal") > 0f)
        _trPlayer.localScale = new Vector3(-1.7f, _trPlayer.localScale.y, _trPlayer.localScale.z);
    else if (Input.GetAxis("Horizontal") < 0f)
        _trPlayer.localScale = new Vector3(1.7f, _trPlayer.localScale.y, _trPlayer.localScale.z);
}

    private void _funJumpingSprite()
    {
        if (_isGrounded() && !_isSpacePressed() )
            _animPlayer.SetBool(/*"Jump"*/"grounded", true);
        else if (_isSpacePressed())
            _animPlayer.SetBool(/*"Jump"*/"grounded", false);
        //if (!_isGrounded() && _animPlayer.GetBool("run"))
        //    _animPlayer.SetBool(/*"WalkingToJump"*/"Grounded", true);
        //else
        //    _animPlayer.SetBool(/*"WalkingToJump"*/"Grounded", false);
    }
}
