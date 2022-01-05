using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTowerManager : MonoBehaviour
{
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
        StartCoroutine("ClockTower");
    }



    IEnumerator ClockTower()
    {

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
        yield return new WaitForSeconds(1.5f);
        // sound repeating
        yield return new WaitForSeconds(1.5f);
        // sound repeating
        tournamentManager.nextScene();

    }


}
