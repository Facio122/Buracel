using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyLevel : MonoBehaviour
{
    public Text ValueText;
    public int test;
    // Start is called before the first frame update
    void Start()
    {
        ValueText.text = GlobalVariables.playerEnergy.ToString()+"%";
    }

    // Update is called once per frame
    void Update()
    {
        _funEnergyDecrease();
    }
    private void _funEnergyDecrease()
    { 
        GlobalVariables.playerEnergy -= 1 * Time.deltaTime;
        ValueText.text = GlobalVariables.playerEnergy.ToString("0") + "%";
        if (GlobalVariables.playerEnergy <= 0)
        {
            GlobalVariables.playerEnergy = 0;
        }
    }
}
