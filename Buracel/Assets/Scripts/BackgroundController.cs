using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = 1f;
    private Material _material;
    private Rigidbody2D _rbPlayer;
    private float _offset;
    private Vector3 _tempPosition;
    private bool _isMoving;
    void Start()
    {
        _material = GetComponent<Renderer>().material;
        _rbPlayer = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        _tempPosition = GameObject.FindWithTag("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Player").transform.position == _tempPosition)
            _isMoving = false;
        else
            _isMoving = true;
        _tempPosition = GameObject.FindWithTag("Player").transform.position;
        _funScrollBackground();
    }

    private void _funScrollBackground()
    {
        if (_isMoving)
        {
            _offset += (_rbPlayer.velocity.x * _scrollSpeed) / 100000f;
            _material.SetTextureOffset("_MainTex", new Vector2(_offset, 0));
        }
        else
        {
            //_offset += (_rbPlayer.velocity.x * _scrollSpeed) / 100000f;
            _material.SetTextureOffset("_MainTex", new Vector2(_offset, 0f));
        }

    }
}
