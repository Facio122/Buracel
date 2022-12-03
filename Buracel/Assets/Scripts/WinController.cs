using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinController : MonoBehaviour
{
    [SerializeField] private bool _isWin = false;
    [SerializeField] private GameObject _enterText;
    [SerializeField] private GameObject _youWinText;
    [SerializeField] private Transform _spawnPoint;

    private Rigidbody2D _rbPlayer;
    // Start is called before the first frame update
    void Start()
    {
        _rbPlayer = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GlobalVariables.isWin = _isWin;
        //Debug.Log(GlobalVariables.isWin);
        _funWin();
        _funClickEnter();
    }

    private void _funWin()
    {
        if (GlobalVariables.isWin)
        {
            LeanTween.moveLocalY(_youWinText, gameObject.transform.position.y, 1);
            StartCoroutine(waitForClickEnter());
            _rbPlayer.velocity = Vector2.zero;
        }
    }
    private void _funClickEnter()
    {
        if (Input.GetKeyDown(KeyCode.Return) && GlobalVariables.isWin)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GlobalVariables.isWin = false;
            GlobalVariables.playerEnergy = 100f;
        }
    }

    IEnumerator waitForClickEnter()
    {
        yield return new WaitForSecondsRealtime(3f);
        _enterText.SetActive(true);
    }
}
