using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MastermindGuard : MonoBehaviour
{
    Vector3 startPos;
    Vector3 targetPos;

    [SerializeField] float moveDistance;

    [SerializeField] bool DownUp;
    [SerializeField] bool RightLeft;
    [SerializeField] float moveSpeed;

    [SerializeField] GameObject bustedText;

    float TimeInterval;

    
    
    void Awake()
    {
        startPos = transform.position;
        if (DownUp) targetPos = startPos + new Vector3(0, -moveDistance);
        else if (RightLeft) targetPos = startPos + new Vector3(0, moveDistance);
    }

   
    void Update()
    {


        if (GameObject.Find("Duel Manager").GetComponent<DuelManager>().timerCondition)
        {
            TimeInterval = Mathf.PingPong(Time.fixedTime * moveSpeed, 1);
            transform.position = Vector3.Lerp(startPos, targetPos, TimeInterval);
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime);
            TimeInterval = 0;
        }



        //animation part
        if (GameObject.Find("Duel Manager").GetComponent<DuelManager>().timerCondition)
        {

            gameObject.GetComponent<Animator>().SetBool("Walk", true);


        }

        else if (transform.position == startPos /*GameObject.Find("Duel Manager").GetComponent<DuelManager>().timerCondition == false*/)
        {
            
            gameObject.GetComponent<Animator>().SetBool("Walk", false);
            
        }
        else return;

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
