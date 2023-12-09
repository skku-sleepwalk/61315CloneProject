using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getItem : MonoBehaviour
{
    public int itemCode;
    public GameObject item;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (itemCode == 0)
        {
            if (collision.gameObject.CompareTag("MainCharacter")) {
                if (!itemManage.getIsShield())
                {
                    GameObject shield=Instantiate(item,collision.gameObject.transform);
                    shield.transform.position = collision.gameObject.transform.position;
                    itemManage.isShieldToTrue();
                   
                }
                 AudioSource audio=GetComponent<AudioSource>();
                 audio.Play();
               // Destroy(gameObject);
                BoxCollider2D coll=GetComponent<BoxCollider2D>();
                coll.isTrigger = true;
                Renderer renderer = GetComponent<Renderer>();
                if (renderer != null)
                {
                    Color currentColor = renderer.material.color;
                    currentColor.a = 0f;
                    renderer.material.color = currentColor;
                }
            }
        }
    }

}