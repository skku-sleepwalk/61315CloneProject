using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FloorBreak : MonoBehaviour
{
    Transform myT;
    public static GameObject MainCharacter;
    private void Awake()
    {
        MainCharacter = GameObject.FindWithTag("MainCharacter");
    }

    // ���İ��� �����ϴ� �Լ�
    void SetObjectAlpha(GameObject obj, float alphaValue)
    {
        
        SpecialTile tile;
        if(obj.TryGetComponent(out tile))
        {
            tile.InvokeCoroutine();
        }
        else
        {
            Destroy(obj);
        }
    }
    int combo = 0;


    // Box Collider�� ��Ȱ��ȭ�ϴ� �Լ�
    void DisableBoxCollider(GameObject obj)
    {
        // Collider ������Ʈ�� �ִ� ��쿡�� ��Ȱ��ȭ
        BoxCollider2D collider = obj.GetComponent<BoxCollider2D>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))   //���콺 ���� ��ư�� ����.
        {
          
            Vector2 RayPoint = gameObject.transform.position;
            RaycastHit2D[] hit = Physics2D.BoxCastAll(RayPoint,new Vector2(0.7f,0.1f),0, Vector3.down, 1,1<<6);
            if (hit.Length != 0) {
                if (BreakCoolTime.getCoolTime())
                {
                    if (BreakCoolTime.getCombo())
                    {
                        combo++;
                    }
                    else
                    {
                        combo = 0;
                    }
                    if (combo >= 7)
                    {
                        combo = 0;
                        MainCharacter.transform.position = new Vector3(MainCharacter.transform.position.x, MainCharacter.transform.position.y - 2, MainCharacter.transform.position.z);
                        RaycastHit2D[] hit2 = Physics2D.BoxCastAll(RayPoint, new Vector2(1.5f, 2.8f), 0, Vector3.down, 1, 1 << 6);
                        foreach (RaycastHit2D flr in hit2)
                        {
                            SetObjectAlpha(flr.collider.gameObject, 0f);
                            // Box Collider�� ��Ȱ��ȭ
                            DisableBoxCollider(flr.collider.gameObject);
                        }
                    }
                    else
                    {
                        foreach (RaycastHit2D flr in hit)
                        {
                            SetObjectAlpha(flr.collider.gameObject, 0f);
                            // Box Collider�� ��Ȱ��ȭ
                            DisableBoxCollider(flr.collider.gameObject);
                        }
                    }
                    
                    //Timer timer = new Timer(BreakCoolTime.setCoolTime, null, 100, Timeout.Infinite);
                    BreakCoolTime.setCoolTime();
                    // ���İ��� 0���� ����

                }
            }
        }
    }
        
    
}
