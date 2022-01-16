using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdEvening : MonoBehaviour
{
    [SerializeField] GameObject EveningManager;

    private void Awake()
    {
        EveningManager.GetComponent<EveningManager>().thirdEvening = true;
    }
}
