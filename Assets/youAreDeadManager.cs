using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class youAreDeadManager : MonoBehaviour
{
    [SerializeField] GameObject firstText;
    [SerializeField] GameObject secondText;
    [SerializeField] GameObject thirdText;



    private void Awake()
    {
        firstText.GetComponent<Animator>().SetTrigger("FadeIn");
        secondText.GetComponent<Animator>().SetTrigger("FadeIn");
        thirdText.GetComponent<Animator>().SetTrigger("FadeIn");
    }

}
