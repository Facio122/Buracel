using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _loseText;
    private Rigidbody2D _rbPlayer;
    private Animator _animPlayer;
    private float i = 0;
    void Start()
    {
        _rbPlayer = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        _animPlayer = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //GlobalVariables.isPlayerAlive = _isAlive;
        _funLose();
    }

    private void _funLose()
    {
        if(!GlobalVariables.isPlayerAlive)
        {
            _rbPlayer.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            StartCoroutine(showingText());
            _animPlayer.SetBool("dead", true);
        }
    }

    private void _funStartfromBegin()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

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
