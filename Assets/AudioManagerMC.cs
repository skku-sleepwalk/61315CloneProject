using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerMC : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip breaked;
    public static GameObject MainCharacter;
    private void Awake()
    {
        MainCharacter= GameObject.FindWithTag("MainCharacter");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetMouseButtonDown(0))   //���콺 ���� ��ư�� ����.
        {
            if (BreakCoolTime.getCoolTime())
            {
                AudioSource audioSource =GetComponent<AudioSource>();
                audioSource.PlayOneShot(breaked);
            }
        }
    }
    public static void AudioPlay(AudioClip clip)
    {
        AudioSource audioSource = MainCharacter.GetComponent<AudioSource>();
        audioSource.PlayOneShot(clip);
    }
}
