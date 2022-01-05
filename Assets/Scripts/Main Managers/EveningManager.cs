using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EveningManager : MonoBehaviour
{

    ////Options Panel
    //[SerializeField] GameObject OptionsPanel;
    ////Options Texts
    [Header("Options Panel Variables")]
    [SerializeField] GameObject optionsFirstBit;
    
    [SerializeField] GameObject SecondBit;

    //[SerializeField] GameObject Path1Panel;

    //[SerializeField] GameObject Path2Panel;

    //Texts

    private void Awake()
    {
        StartCoroutine("OptionsPanelSetter");
    }

    private void Update()
    {
        

       
    }

    IEnumerator OptionsPanelSetter()
    {
        yield return new WaitForSeconds(1);
        optionsFirstBit.GetComponent<Animator>().SetTrigger("FadeIn");
    }

   

}
