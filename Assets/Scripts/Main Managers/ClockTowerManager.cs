using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClockTowerManager : MonoBehaviour
{
    [Header("Audio Variables")]
    
    [SerializeField] AudioClip bellClip;
    
    public bool background;
    
    
    [Header("Visual Variables")]
    [SerializeField] GameObject proudlyText;
    [SerializeField] GameObject duelText;
    [SerializeField] GameObject towerPanel;
    //image switching
    [SerializeField] GameObject clockTower;
    [SerializeField] Sprite duelTime;

    [Header("Tournament Manager")]
    
    [SerializeField] TournamentManager tournamentManager;

    

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine("ClockTower");
        
        background = true;

    }

    private void Update()
    {
        if (background && GetComponent<AudioSource>().volume < 0.6f)
        {
            GetComponent<AudioSource>().volume += 0.1f * Time.deltaTime;
        }
        else if (!background && GetComponent<AudioSource>().volume != 0)
        {
            GetComponent<AudioSource>().volume -= +0.1f * Time.deltaTime;
            Debug.Log(GetComponent<AudioSource>().volume);

        }
        else return;
    }
   


    IEnumerator ClockTower()
    {
        GetComponent<AudioSource>().Play(0);
        yield return new WaitForSeconds(2.5f);
        proudlyText.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(2.5f);
        duelText.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(4.5f);
        towerPanel.GetComponent<Animator>().SetTrigger("FadeOut");
        duelText.GetComponent<Animator>().SetTrigger("FadeOut");
        proudlyText.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(4.5f);
        clockTower.GetComponent<SpriteRenderer>().sprite = duelTime;
        GetComponent<AudioSource>().PlayOneShot(bellClip);
        yield return new WaitForSeconds(5.5f);
       
        tournamentManager.nextScene();

    }


}
