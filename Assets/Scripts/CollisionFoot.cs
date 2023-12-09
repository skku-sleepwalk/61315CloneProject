using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFoot : MonoBehaviour
{
    private bool isDead=false;
    public AudioClip foot;
    public bool getIsDead()
    {
        return isDead;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MainCharacter") && collision.contacts[0].normal.y>-1.3f&& collision.contacts[0].normal.y < -0.7f)
        {
            BoxCollider2D Box = gameObject.GetComponent<BoxCollider2D>();
            Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D>();
            Box.isTrigger = true;
            isDead = true;
            if (gameObject.transform.position.x - collision.transform.position.x > 0)
                rigid.AddForce(new Vector2(5f, 200f));
            else
                rigid.AddForce(new Vector2(-5f, 200f));
            AudioManagerMC.AudioPlay(foot);
        }
        else if(collision.gameObject.CompareTag("MainCharacter")){
            moveRight script = GetComponent<moveRight>();
            script.changeVelocity(-4);
        }
    }
    IEnumerator MyFunctionWithDelay()
    {
        // 2초 대기
        yield return new WaitForSeconds(0.5f);

        // 2초 후에 실행될 코드
        Destroy(gameObject);
    }
    private void Update()
    {
        if (isDead)
        {
            StartCoroutine(MyFunctionWithDelay());
        }
    }


}
