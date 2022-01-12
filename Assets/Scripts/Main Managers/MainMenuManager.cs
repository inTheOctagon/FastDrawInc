using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] TMP_InputField yourName;
    
    //transition
    [SerializeField] GameObject tournamentManager;
    [SerializeField] GameObject fadeInPanel;


    public void signButton()
    {
        if (yourName.text.Length < 1)
        {
            Debug.Log("your name, sir");
        }

        else
        {
            StartCoroutine("weGoIn");
        }
    }

    IEnumerator weGoIn()
    {
        fadeInPanel.SetActive(true);
        ValueManager.playerName = yourName.text.ToString();
        fadeInPanel.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(2);
        Debug.Log("your name " + ValueManager.playerName + "ye");
        yield return new WaitForSeconds(2);
        tournamentManager.GetComponent<TournamentManager>().nextScene();
    }
    
}
