using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CollisionMC : MonoBehaviour
{
    private float forceMagnitude = 0.5f; // �����ϰ� ���� ���� ũ��
    private Vector3 forceDirection = new Vector3(0f, 1f, 0f); // ���� ���� ����
    public AudioClip GG;
    private BoxCollider2D box;
    private void Awake()
    {
        box=GetComponent<BoxCollider2D>();
    }
    GameObject shield;
    void OnBecameInvisible()
    {
        if(Score.getScore()>=0)
        Destroy(gameObject);
    //ȭ�� �� ������ ����
    }
    private void isTriggerFalse()
    {
        box.isTrigger = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.CompareTag("Enemy"))
            {
        
                if (!(collision.contacts[0].normal.y<1.8f&&collision.contacts[0].normal.y > 0.2f)){
                //�ٴڿ� ��� ���� �ƴ� ���
                if (itemManage.getIsShield())
                {
                    itemManage.isShieldToFalse();
                    shield = GameObject.FindWithTag("ShieldItem");
                    Destroy(shield);
                }
                else
                {
                    AudioManagerMC.AudioPlay(GG);
                    //UnityEditor.EditorApplication.isPlaying = false;
                    Destroy(gameObject);
                }
                Animator animator=collision.gameObject.GetComponent<Animator>();
                animator.SetTrigger("cigaretteRun");
             }
            else
            {
                box.isTrigger = true;
                Invoke("isTriggerFalse", 0.5f);
                ApplyForce();
            }
            

          

        }

    }
    void ApplyForce()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // ���� �ִ� �Լ�
            rb.AddForce(forceDirection * forceMagnitude, ForceMode2D.Impulse);
        }
    }

}