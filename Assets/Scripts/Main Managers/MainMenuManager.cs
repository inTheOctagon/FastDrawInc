using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [Header("Main Menu Variables")]
    [SerializeField] GameObject mainMenuTitle;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject exitButton;

    
    [SerializeField] GameObject streetSoundSource;
    private bool streetSoundSourceBool;

    [SerializeField] GameObject officeSoundSource;
    private bool officeSoundSourceBool;


    [Header("The Story Bit Variables")]
    private bool storyBitStarter;
    private bool firstBit;
    private bool secondBit;
    private bool thirdBit;

    [SerializeField] TMP_InputField yourName;
    [SerializeField] GameObject yourNameHere;
    
    //transition
    [SerializeField] GameObject tournamentManager;
    [SerializeField] GameObject fadeInPanel;
    [SerializeField] GameObject fadeOutPanel;

    [SerializeField] AudioClip signingSFX;

    private void Start()
    {
        mainMenuTitle.GetComponent<Animator>().SetTrigger("FadeIn");
        playButton.GetComponent<Animator>().SetTrigger("FadeIn");
        exitButton.GetComponent<Animator>().SetTrigger("FadeIn");
    }

    private void Update()
    {
       if(streetSoundSourceBool)
        {
            streetSoundSource.GetComponent<AudioSource>().volume = Mathf.MoveTowards(streetSoundSource.GetComponent<AudioSource>().volume, 0.3f, 0.05f * Time.deltaTime);
        }
       else if(!streetSoundSourceBool && streetSoundSource.GetComponent<AudioSource>().volume != 0)
        {
            streetSoundSource.GetComponent<AudioSource>().volume = Mathf.MoveTowards(streetSoundSource.GetComponent<AudioSource>().volume, 0.3f, 0.05f * Time.deltaTime);
        }

       if(officeSoundSourceBool)
        {
            officeSoundSource.GetComponent<AudioSource>().volume = Mathf.MoveTowards(officeSoundSource.GetComponent<AudioSource>().volume, 0.3f, 0.05f * Time.deltaTime);
        }
       else if(!officeSoundSourceBool && officeSoundSource.GetComponent<AudioSource>().volume != 0)
        {
            officeSoundSource.GetComponent<AudioSource>().volume = Mathf.MoveTowards(officeSoundSource.GetComponent<AudioSource>().volume, 0.3f, 0.05f * Time.deltaTime);
        }

        
        if (storyBitStarter)
        {
            if (firstBit && Input.anyKeyDown)
            {
                //firstBit IENumerator
                firstBit = false;
                secondBit = true;
            }
            else if (secondBit && Input.anyKeyDown)
            {
                //secondBit IENumerator
                secondBit = false;
                thirdBit = true;
            }
            else if (thirdBit && Input.anyKeyDown)
            {
                //thirdBit IENumerator
                thirdBit = false;
                StartCoroutine("setTheContractUp");

            }
        }
        else return;

    }

    public void playButtonFunc()
    {
        mainMenuTitle.GetComponent<Animator>().SetTrigger("FadeOut");
        playButton.GetComponent<Animator>().SetTrigger("FadeOut");
        exitButton.GetComponent<Animator>().SetTrigger("FadeOut");
    }

    public void exitButtonFunc()
    {
        Application.Quit();
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

    //main menu to story bit 

    IEnumerator mainMenuFaderAndAudioSourceTrigger()
    {
        yield return new WaitForSeconds(2f);
        playButton.SetActive(false);
        exitButton.SetActive(false);
        // street sounds goes in and the texts
        streetSoundSourceBool = true;
        //first text and next: press any key. and firstbitbool
        //they fade - only story bits -
        //and AFter that and it's texts and then secondbitbool
        //they fade - only story bits -
        //and AFter that and it's texts and then secondbitbool
        // the main panel fades away then we end with the contract in front of us.
    }

    //the contract part
    IEnumerator setTheContractUp()
    {
        yield return new WaitForSeconds(1.5f);
        fadeOutPanel.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(1.5f);
        fadeOutPanel.SetActive(false);
    }

    IEnumerator yourNameHereSir()
    {
        yourNameHere.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        yourNameHere.SetActive(false);
    }
    
    IEnumerator weGoIn()
    {
        GetComponent<AudioSource>().PlayOneShot(signingSFX);
        yield return new WaitForSeconds(2);
        fadeInPanel.SetActive(true);
        ValueManager.playerName = yourName.text.ToString();
        fadeInPanel.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(2);
        yield return new WaitForSeconds(2);
        tournamentManager.GetComponent<TournamentManager>().nextScene();
    }

    
    

}
