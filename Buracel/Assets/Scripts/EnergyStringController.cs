using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnergyStringController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ValueText;
    void Start()
    {
        ValueText.text = GlobalVariables.playerEnergy.ToString() + "%";
    }

    // Update is called once per frame
    void Update()
    {
        ValueText.text = GlobalVariables.playerEnergy.ToString("0") + "%";
    }
}
