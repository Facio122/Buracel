using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _loseText;
    [SerializeField] private bool _isAlive;
    private float i = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GlobalVariables.isPlayerAlive = _isAlive;
        _funLose();
    }

    private void _funLose()
    {
        if(!GlobalVariables.isPlayerAlive)
        {
            StartCoroutine(showingText());
        }
    }

    private void _funStartfromBegin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator showingText()
    {
        yield return new WaitForSecondsRealtime(0.1f);
         i += 0.01f;
        _loseText.color = new Color(0, 0, 0, i);
        if (i >= 1f)
        {
            StartCoroutine(wait2seconds());
        }
    }
    IEnumerator wait2seconds()
    {
        yield return new WaitForSecondsRealtime(2f);
        _funStartfromBegin();
        GlobalVariables.isPlayerAlive = true;
        GlobalVariables.playerEnergy = 100f;
    }
}
