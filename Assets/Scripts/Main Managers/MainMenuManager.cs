using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] TMP_InputField yourName;
    [SerializeField] GameObject yourNameHere;
    
    //transition
    [SerializeField] GameObject tournamentManager;
    [SerializeField] GameObject fadeInPanel;
    [SerializeField] GameObject fadeOutPanel;

    private void Start()
    {
        StartCoroutine("setTheMenuUp");
    }

    public void signButton()
    {
        if (yourName.text.Length < 1)
        {
            StartCoroutine("yourNameHereSir");
        }

        else
        {
            StartCoroutine("weGoIn");
        }
    }

    IEnumerator setTheMenuUp()
    {
        yield return new WaitForSeconds(1.5f);
        fadeOutPanel.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(2);
        fadeOutPanel.SetActive(false);
    }

    IEnumerator weGoIn()
    {
        
        fadeInPanel.SetActive(true);
        ValueManager.playerName = yourName.text.ToString();
        fadeInPanel.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(2);
        yield return new WaitForSeconds(2);
        tournamentManager.GetComponent<TournamentManager>().nextScene();
    }

    IEnumerator yourNameHereSir()
    {
        yourNameHere.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        yourNameHere.SetActive(false);
    }
    
}
