using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyLevel : MonoBehaviour
{

    void Update()
    {
        _funEnergyDecrease();
        _blockMaximumEnergy();
        _funIsEnergyZero();
    }
    private void _funEnergyDecrease()
    { 
        GlobalVariables.playerEnergy -= 1 * Time.deltaTime;

        if (GlobalVariables.playerEnergy < 0)
        {
            GlobalVariables.playerEnergy = 0;
        }
    }

    private void _blockMaximumEnergy()
    {
        if(GlobalVariables.playerEnergy > 100f )
        {
            GlobalVariables.playerEnergy = 100f;
        }
    }

    private void _funIsEnergyZero()
    {
        if(GlobalVariables.playerEnergy <= 0 ) {
            GlobalVariables.isPlayerAlive= false;
        }
    }
}
