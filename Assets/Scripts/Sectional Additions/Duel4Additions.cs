using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duel4Additions : MonoBehaviour
{
    [SerializeField] DuelManager duelManager;
    private void Awake()
    {
        duelManager.GetComponent<DuelManager>().duel4Con = true;
        duelManager.timerValue = ValueManager.newTimerValue + 0.7f;
    }
}
