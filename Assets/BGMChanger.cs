using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMChanger : MonoBehaviour
{
    public AudioClip baby;
    public AudioClip teen;
    public AudioClip adult;
    public AudioClip elder;
    AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = baby;
    }

    void Update()
    {
        if(Score.getScore() % 100 > 60)
        {
            source.clip = elder;
        }
        else if(Score.getScore() % 100 > 30){
            source.clip = adult;
        }
        //else if( Score.getScore() % 100 > 15){
        //    source.clip = teen;
        //}
        else
        {
            source.clip = baby;
        }
        if (Stop.stoped == false)
        {
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
        else
        {
            source.Pause();
        }
        
    }
}
