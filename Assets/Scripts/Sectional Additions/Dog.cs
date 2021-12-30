using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField] float dogSpeed = 3;
    Vector2 targetPos;
    Vector2 startPos;

    [SerializeField] GameObject duelManager;


    private void Start()
    {
        startPos = transform.position;  
    }

    private void Update()
    {
        DogMovement();
        DogReaching();

    }

    private void DogMovement()
    {
        if (duelManager.GetComponent<DuelManager>().timerCondition)
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, dogSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, dogSpeed * Time.deltaTime);
        }
    }

    private void DogReaching()
    {
        if(duelManager.GetComponent<DuelManager>().timerCondition && Vector2.Distance(transform.position, targetPos) < 0.3f)
        {
            duelManager.GetComponent<DuelManager>().OpponentWinOutputFunction();
        }
    }
}
