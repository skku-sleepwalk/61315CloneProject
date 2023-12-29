using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CollisionMC : MonoBehaviour
{
    private float forceMagnitude = 0.4f; // 조절하고 싶은 힘의 크기
    private Vector3 forceDirection = new Vector3(0f, 1f, 0f); // 힘을 가할 방향
    public AudioClip GG;
    private BoxCollider2D box;

    private void Awake()
    {
        box=GetComponent<BoxCollider2D>();
    }
    GameObject shield;
    void OnBecameInvisible()
    {
        if (Score.getScore() >= 0)
        {
           AudioManagerMC.AudioPlay(GG);
            BroadcastMessage("StopFunction", SendMessageOptions.DontRequireReceiver);
            
         
        }
 
        //화면 밖 나가면 제거
    }
    private void isTriggerFalse()
    {
     

        box.isTrigger = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.CompareTag("Enemy"))
            {

                Vector2 RayPoint = gameObject.transform.position;
                RaycastHit2D hitLeft = Physics2D.BoxCast(RayPoint,new Vector2(0.4f,0.1f),0, Vector3.left, 0.2f, 1 << 8);
                RaycastHit2D hitRight = Physics2D.BoxCast(RayPoint, new Vector2(0.4f, 0.1f), 0, Vector3.right, 0.2f, 1 << 8);
                RaycastHit2D hitUp = Physics2D.BoxCast(RayPoint, new Vector2(0.4f, 0.1f), 0, Vector3.up, 0.2f, 1 << 8);
            if (hitLeft||hitRight|| hitUp)
            {
                    if (itemManage.getIsShield())
                    {
                        itemManage.isShieldToFalse();
                        shield = GameObject.FindWithTag("ShieldItem");
                        Destroy(shield);
                        Destroy(collision.gameObject);
                    }
                    else
                    {
                        AudioManagerMC.AudioPlay(GG);
                        //UnityEditor.EditorApplication.isPlaying = false;
                        BroadcastMessage("StopFunction", SendMessageOptions.DontRequireReceiver);
                    }
                    Animator animator=collision.gameObject.GetComponent<Animator>();
                    animator.SetTrigger("cigaretteRun");
                }
            else
            {

            }
                //else
                //{
                //    //box.isTrigger = true;
                //    //Invoke("isTriggerFalse", 0.5f);
                //    //ApplyForce();
                //}
            

          

            }

    }
    public void ApplyForce()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {

            // 힘을 주는 함수
            rb.velocity = Vector2.zero;
            rb.AddForce(forceDirection * forceMagnitude, ForceMode2D.Impulse);
            box.isTrigger = true;
            Invoke("isTriggerFalse", 0.5f);
        }
    }

}