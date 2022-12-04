using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    void Update()
    {
        _funCameraFollowPlayer();
    }

    private void _funCameraFollowPlayer()
    {
        gameObject.transform.position= GameObject.FindWithTag("Player").transform.position + new Vector3(0f,0f,-15f);
    }
}
