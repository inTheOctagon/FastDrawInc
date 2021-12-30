using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tafScript : MonoBehaviour
{
    [SerializeField] Texture2D tafCursor;
    [SerializeField] Texture2D normalCursor;
    [SerializeField] Slider timerSlider;
    private Vector2 cursorHotspot;

    [SerializeField] GameObject penaltyText;
    [SerializeField] GameObject duelManager;

    private bool penaltyInterval = true;

    private void OnMouseOver()
    {
        if(duelManager.GetComponent<DuelManager>().timerCondition && penaltyInterval)
        {
            cursorHotspot = new Vector2(tafCursor.width / 2, tafCursor.height / 2);
            Cursor.SetCursor(tafCursor, cursorHotspot, CursorMode.ForceSoftware);
            
                timerSlider.value = timerSlider.value - 0.25f;
                StartCoroutine("TimerPenaltyText");
                StartCoroutine("ppSetter");
        }
    }

    private void OnMouseExit()
    {
        StartCoroutine("normalCursorSetter");
    }

    IEnumerator TimerPenaltyText()
    {
        
        penaltyText.transform.position = Input.mousePosition;
        penaltyText.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        penaltyText.SetActive(false);
        
    }

    IEnumerator ppSetter()
    {
        penaltyInterval = false;
        yield return new WaitForSeconds(0.8f);
        penaltyInterval = true;
    }

    IEnumerator normalCursorSetter()
    {
        yield return new WaitForSeconds(0.5f);
        cursorHotspot = new Vector2(normalCursor.width / 2, normalCursor.height / 2);
        Cursor.SetCursor(normalCursor, cursorHotspot, CursorMode.ForceSoftware);
        
    }

    
}
