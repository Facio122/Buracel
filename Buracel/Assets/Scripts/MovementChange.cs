using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementChange : MonoBehaviour
{
    [SerializeField] private GameObject _walkingplayer;
    [SerializeField] private GameObject _rollingplayer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        funReplacePlayer();
    }
    private void funReplaceForWalking(GameObject _walkingplayer, GameObject _rollingplayer)
    {
        _walkingplayer.SetActive(true);
        _walkingplayer.transform.position = _rollingplayer.transform.position;
        _rollingplayer.SetActive(false);
        GlobalVariables.isPlayerWalking = true;
    }
    private void funReplaceForRolling(GameObject _walkingplayer, GameObject _rollingplayer)
    {
        _rollingplayer.SetActive(true);
        _rollingplayer.transform.position = _walkingplayer.transform.position;
        _walkingplayer.SetActive(false);
        GlobalVariables.isPlayerWalking = false;
    }
    private void funReplacePlayer()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(enumerator());
        }
    }
    IEnumerator enumerator()
    {
        yield return new WaitForSecondsRealtime(1f);
        if (GlobalVariables.isPlayerWalking == true)
            funReplaceForRolling(_walkingplayer, _rollingplayer);
        else
            funReplaceForWalking(_walkingplayer, _rollingplayer);
    }
}
