using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class WebCameraController : MonoBehaviour
{
    List<Color> upperPixels = new List<Color>();
    List<Color> bottomPixels = new List<Color>();
    private WebCamTexture _webCamTexture;
    [SerializeField] private Material _webCamMaterial;
    [SerializeField] private float brightnessLevel;

    private int _upperBrightnessPixelsCount;
    private int _bottomBrightnessPixelsCount;

    void Start()
    {
        _funCameraInit();
        StartCoroutine(ComparePixelsTime());
        StartCoroutine(AddRangeDeltaTime());
    }

    void Update()
    {
        //Debug.Log("width = " + _webCamTexture.width + "height = " + _webCamTexture.height);
    }

    private void _funCameraInit()
    {
        _webCamTexture = new WebCamTexture(Screen.width, Screen.height);
        _webCamMaterial.mainTexture = _webCamTexture;
        GetComponent<Renderer>().material.mainTexture = _webCamMaterial.mainTexture;
        _webCamTexture.Play();
    }

    private void _funAddRangePixels()
    {
        upperPixels.AddRange(_webCamTexture.GetPixels(256, 384, 3, 3));
        upperPixels.AddRange(_webCamTexture.GetPixels(512, 384, 3, 3));
        upperPixels.AddRange(_webCamTexture.GetPixels(765, 384, 3, 3));
        upperPixels.AddRange(_webCamTexture.GetPixels(256, 560, 3, 3));
        upperPixels.AddRange(_webCamTexture.GetPixels(512, 560, 3, 3));
        upperPixels.AddRange(_webCamTexture.GetPixels(765, 560, 3, 3));
        upperPixels.AddRange(_webCamTexture.GetPixels(256, 700, 3, 3));
        upperPixels.AddRange(_webCamTexture.GetPixels(512, 700, 3, 3));
        upperPixels.AddRange(_webCamTexture.GetPixels(765, 700, 3, 3));
        bottomPixels.AddRange(_webCamTexture.GetPixels(256, 100, 3, 3));
        bottomPixels.AddRange(_webCamTexture.GetPixels(512, 100, 3, 3));
        bottomPixels.AddRange(_webCamTexture.GetPixels(765, 100, 3, 3));
        bottomPixels.AddRange(_webCamTexture.GetPixels(256, 200, 3, 3));
        bottomPixels.AddRange(_webCamTexture.GetPixels(512, 200, 3, 3));
        bottomPixels.AddRange(_webCamTexture.GetPixels(765, 200, 3, 3));
        bottomPixels.AddRange(_webCamTexture.GetPixels(256, 300, 3, 3));
        bottomPixels.AddRange(_webCamTexture.GetPixels(512, 300, 3, 3));
        bottomPixels.AddRange(_webCamTexture.GetPixels(765, 300, 3, 3));
    }

    private void _compareUpperPixels()
    {
        for (int i = 0; i < upperPixels.Count; i++)
        {
            float H, S, V;
            Color.RGBToHSV(upperPixels[i], out H, out S, out V);
            if (V > brightnessLevel)
            {
                _upperBrightnessPixelsCount++;
                Debug.Log("is Brigthness upper" + _upperBrightnessPixelsCount);
            }
        }
    }

    private void _compareBottomPixels()
    {
        for (int i = 0; i < bottomPixels.Count; i++)
        {
            float H, S, V;
            Color.RGBToHSV(bottomPixels[i], out H, out S, out V);
            if (V > brightnessLevel)
            {
                _bottomBrightnessPixelsCount++;
                Debug.Log("is Brigthness bottom" + _bottomBrightnessPixelsCount);
            }
        }
    }

    private void _addEnergy()
    {
        if(_upperBrightnessPixelsCount > 200 && _bottomBrightnessPixelsCount > 200)
        {
            GlobalVariables.playerEnergy += 5f;
        }
    }

    IEnumerator ComparePixelsTime()
    {
        yield return new WaitForSecondsRealtime(1f);
        _compareUpperPixels();
        _compareBottomPixels();
        _addEnergy();
        Debug.Log(GlobalVariables.playerEnergy);
        _bottomBrightnessPixelsCount = 0;
        _upperBrightnessPixelsCount = 0;
        upperPixels.Clear();
        bottomPixels.Clear();

        //Debug.Log("hurra!");
        StartCoroutine(ComparePixelsTime());
    }

    IEnumerator AddRangeDeltaTime()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        _funAddRangePixels();
        //Debug.Log("add delta time");
        StartCoroutine(AddRangeDeltaTime());
    }
}
