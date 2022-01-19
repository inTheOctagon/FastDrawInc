using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstEvening : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject EveningManager;

    private void Awake()
    {
        EveningManager.GetComponent<EveningManager>().firstEvening = true;
    }

}
