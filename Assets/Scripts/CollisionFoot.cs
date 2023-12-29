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
        Vector2 RayPoint = gameObject.transform.position;
        RaycastHit2D hitUp = Physics2D.BoxCast(RayPoint, new Vector2(0.4f, 0.01f), 0, Vector3.up, 0.3f, 1 << 3);
        if (hitUp)
        {
            BoxCollider2D Box = gameObject.GetComponent<BoxCollider2D>();
            Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D>();
            Box.isTrigger = true;
            isDead = true;
            if (gameObject.transform.position.x - collision.transform.position.x > 0)
                rigid.AddForce(new Vector2(Random.Range(4f,6f), 10f), ForceMode2D.Impulse);
            else
                rigid.AddForce(new Vector2(Random.Range(-4f, -6f), 10f), ForceMode2D.Impulse);
            GameObject MainCharacter = GameObject.FindWithTag("MainCharacter");
            MainCharacter.GetComponent<CollisionMC>().ApplyForce();
            AudioManagerMC.AudioPlay(foot);
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
