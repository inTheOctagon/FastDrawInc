using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip bellClip;
    [SerializeField] AudioClip backgroundClip;
    private bool background;


    private void Update()
    {
        if(background && GetComponent<AudioSource>().volume < 0.6f)
        {
            GetComponent<AudioSource>().volume += 0.1f * Time.deltaTime;
        }
    }

}
