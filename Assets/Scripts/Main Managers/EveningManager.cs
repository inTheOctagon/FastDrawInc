using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveningManager : MonoBehaviour
{

    [Header("The Evening of The Duel #1")]
    [SerializeField] GameObject theEveningText;
    [Header("Main Options Panel Variables")]
    [SerializeField] GameObject optionsFirstBit;
    [SerializeField] GameObject optionsSecondBit;
    bool mainSecondBitCon = true;
    bool mainOptionsCon = false;
    [SerializeField] GameObject mainPressAnyKeyText;
    [SerializeField] GameObject buttonOne;
    [SerializeField] GameObject buttonTwo;

    // optionOnePanel
    [SerializeField] GameObject optionOnePanel;
    bool pathOneSecondBitCon = false;
    [SerializeField] GameObject pathOneFirstBit;
    [SerializeField] GameObject pathOneSecondBit;
    [SerializeField] GameObject pathOnePressAnyKeyText;
    // optionTwoPanel
    [SerializeField] GameObject optionTwoPanel;
    bool pathTwoSecondBitCon = false;
    [SerializeField] GameObject pathTwoFirstBit;
    [SerializeField] GameObject pathTwoSecondBit;
    [SerializeField] GameObject pathTwoPressAnyKeyText;

    bool nextScene = false;

    [Header("Tournament Manager")]
    [SerializeField] GameObject tournamentManager;
    [Header("Value Manager")]
    [SerializeField] GameObject valueManager;

    private void Awake()
    {
        StartCoroutine("OptionsPanelSetter");
    }

    private void Update()
    {
        if (Input.anyKeyDown && mainSecondBitCon)
        {
            optionsSecondBit.GetComponent<Animator>().SetTrigger("FadeIn");
            mainSecondBitCon = false;
            mainOptionsCon = true;
        }
        else if (Input.anyKeyDown && !mainSecondBitCon && mainOptionsCon)
        {
            mainPressAnyKeyText.GetComponent<Animator>().SetTrigger("FadeOut");

            buttonOne.GetComponent<Animator>().SetTrigger("FadeIn");
            buttonTwo.GetComponent<Animator>().SetTrigger("FadeIn");

            mainOptionsCon = false;
        }
        else if (Input.anyKeyDown && pathOneSecondBitCon)
        {
            pathOneSecondBitCon = false;
            pathOneSecondBit.GetComponent<Animator>().SetTrigger("FadeIn");
            nextScene = true;
        }
        else if(Input.anyKeyDown && pathTwoSecondBitCon)
        {
            pathTwoSecondBitCon = false;
            pathTwoSecondBit.GetComponent<Animator>().SetTrigger("FadeIn");
            nextScene = true;
        }
        
        else if(Input.anyKeyDown && nextScene)
        {
            tournamentManager.GetComponent<TournamentManager>().nextScene();
        }
    }

    IEnumerator OptionsPanelSetter()
    {
        yield return new WaitForSeconds(2);
        theEveningText.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(3f);
        theEveningText.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(3f);
        optionsFirstBit.GetComponent<Animator>().SetTrigger("FadeIn");
        mainPressAnyKeyText.GetComponent<Animator>().SetTrigger("FadeIn");
    }

    public void eveningOneOptionOne()
    {
        optionOnePanel.SetActive(true);
        pathOneSecondBitCon = true;
        pathOneFirstBit.GetComponent<Animator>().SetTrigger("FadeIn");
        pathOnePressAnyKeyText.GetComponent<Animator>().SetTrigger("FadeIn");
        ValueManager.newBulletSize = ValueManager.newBulletSize - ValueManager.newBulletSize / 10;

    }

    public void eveningOneoptionTwo()
    {
        optionTwoPanel.SetActive(true);
        pathTwoSecondBitCon = true;
        pathTwoFirstBit.GetComponent<Animator>().SetTrigger("FadeIn");
        pathTwoPressAnyKeyText.GetComponent<Animator>().SetTrigger("FadeIn");
        ValueManager.newBulletSize = ValueManager.newBulletSize - ValueManager.newBulletSize / 10;
    }
   

}
