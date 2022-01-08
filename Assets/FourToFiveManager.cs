using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourToFiveManager : MonoBehaviour
{
    [Header("UI Variables")]
    
    [SerializeField] GameObject pressAnyKeyText;
    [SerializeField] GameObject youHaveWonText;
    [SerializeField] GameObject orAreYouText;
    [SerializeField] GameObject whoIsThisText;

    private bool nextText = false;
    private bool nextScene = false;

    [Header("Tournament Manager")]

    [SerializeField] GameObject tournamentManager;




    private void Awake()
    {
        StartCoroutine("weGo");
    }




    private void Update()
    {
        if (nextText && Input.anyKeyDown)
        {
            whoIsThisText.GetComponent<Animator>().SetTrigger("FadeIn");
            nextScene = true;
            nextText = false;
            
        }
        else if (nextScene && Input.anyKeyDown)
        {
            StartCoroutine("weLeave");
        }
        
    }


    IEnumerator weGo()
    {
        yield return new WaitForSeconds(1.5f);
        youHaveWonText.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(3f);
        orAreYouText.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(1.5f);
        pressAnyKeyText.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(0.5f);
        nextText = true;

    }

    IEnumerator weLeave()
    {
        yield return new WaitForSeconds(0.5f);
        tournamentManager.GetComponent<TournamentManager>().nextScene();

    }

    
}
