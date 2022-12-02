using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private GameObject _objectPlayer;
    [SerializeField] private float _scrollSpeed = 1f;
    private Material _material;
    private Rigidbody2D _rbPlayer;
    private float _offset;
    void Start()
    {
        _material = GetComponent<Renderer>().material;
        _rbPlayer = _objectPlayer.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _funScrollBackground();
    }

    private void _funScrollBackground()
    {
        _offset += (_rbPlayer.velocity.x * _scrollSpeed) / 100000f;
        _material.SetTextureOffset("_MainTex", new Vector2(_offset,0));
    }
}
