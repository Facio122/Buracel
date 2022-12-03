using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class WebCameraController : MonoBehaviour
{
    private WebCamTexture _webCamTexture;
    [SerializeField] private Material _webCamMaterial;
    void Start()
    {
        _funCameraInit();
    }

    void Update()
    {
        Debug.Log("width = " + _webCamTexture.width + "height = " + _webCamTexture.height);
        //_funPixelsDetect();
    }

    private void _funCameraInit()
    {
        _webCamTexture = new WebCamTexture(Screen.width, Screen.height);
        _webCamMaterial.mainTexture = _webCamTexture;
        GetComponent<Renderer>().material.mainTexture = _webCamMaterial.mainTexture;
        _webCamTexture.Play();
    }

    private void _funPixelsDetect()
    {
        //List<Color> pixels = new List<Color>();
        Color[,] pixels = new Color[1024, 768];
        for (int i = 0; i < _webCamTexture.width; i++)
        {
            for (int j = 0; j < _webCamTexture.height; j++)
            {
                //pixels[j][i] = _webCamTexture.GetPixel(i, j);
            }
        }
    }



}
