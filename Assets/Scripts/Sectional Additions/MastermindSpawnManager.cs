using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MastermindSpawnManager : MonoBehaviour
{
    DuelManager duelManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        duelManagerScript = GameObject.Find("Duel Manager").GetComponent<DuelManager>();
        duelManagerScript.MastermindSpawnCondition = true;
        duelManagerScript.duel5Con = true;
        duelManagerScript.theMastermindStart = true;
    }

}
