using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MastermindGuard : MonoBehaviour
{
    Vector2 startPos;
    Vector2 targetPos;

    [SerializeField] float moveDistance;

    [SerializeField] bool DownUp;
    [SerializeField] bool RightLeft;
    [SerializeField] float moveSpeed;

    [SerializeField] GameObject bustedText;

    
    
    void Start()
    {
        startPos = transform.position;
        if (DownUp) targetPos = startPos + new Vector2(0, -moveDistance);
        else if (RightLeft) targetPos = startPos + new Vector2(0, moveDistance);
    }

   
    void Update()
    {
        if(GameObject.Find("Duel Manager").GetComponent<DuelManager>().timerCondition)
        transform.position = Vector3.Lerp(startPos, targetPos, Mathf.PingPong(Time.time * moveSpeed, 1));
        else transform.position = Vector3.Lerp(transform.position, startPos, moveSpeed * Time.deltaTime);
    }


    private void OnMouseOver()
    {
        if (GameObject.Find("Duel Manager").GetComponent<DuelManager>().timerCondition)
        {
            StartCoroutine("BustedText");
            GameObject.Find("Duel Manager").GetComponent<DuelManager>().OpponentWinOutputFunction();
        }
        else return;
    }

    IEnumerator BustedText()
    {
        bustedText.SetActive(true);
        bustedText.transform.position = Input.mousePosition;
        yield return new WaitForSeconds(1);
        bustedText.SetActive(false);
    }

}
