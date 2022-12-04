using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour
{
    [SerializeField] private GameObject _ob1;
    [SerializeField] private GameObject _ob2;
    [SerializeField] private GameObject _ob3;
    [SerializeField] private GameObject _ob4;
    [SerializeField] private GameObject _ob5;


    void Update()
    {
        if (GlobalVariables.playerEnergy > 80 && GlobalVariables.playerEnergy < 101)
            _ob1.SetActive(true);
        else
            _ob1.SetActive(false);
        if (GlobalVariables.playerEnergy > 60 && GlobalVariables.playerEnergy < 101)
            _ob2.SetActive(true);
        else
            _ob2.SetActive(false);
        if (GlobalVariables.playerEnergy > 40 && GlobalVariables.playerEnergy < 101)
            _ob3.SetActive(true);
        else
            _ob3.SetActive(false);
        if (GlobalVariables.playerEnergy > 20 && GlobalVariables.playerEnergy < 101)
            _ob4.SetActive(true);
        else
            _ob4.SetActive(false);
        if (GlobalVariables.playerEnergy > 0 && GlobalVariables.playerEnergy < 101)
            _ob5.SetActive(true);
        else
            _ob5.SetActive(false);
    }
}
