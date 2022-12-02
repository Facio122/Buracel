using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _objectPlayer;
    private Transform _trPlayer;
    void Start()
    {
        _trPlayer = _objectPlayer.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _funCameraFollowPlayer();
    }

    private void _funCameraFollowPlayer()
    {
        gameObject.transform.position= _trPlayer.transform.position + new Vector3(0f,0f,-15f);
    }
}
