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

    // 알파값을 설정하는 함수
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


    // Box Collider를 비활성화하는 함수
    void DisableBoxCollider(GameObject obj)
    {
        // Collider 컴포넌트가 있는 경우에만 비활성화
        BoxCollider2D collider = obj.GetComponent<BoxCollider2D>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))   //마우스 좌측 버튼을 누름.
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
                            // Box Collider를 비활성화
                            DisableBoxCollider(flr.collider.gameObject);
                        }
                    }
                    else
                    {
                        foreach (RaycastHit2D flr in hit)
                        {
                            SetObjectAlpha(flr.collider.gameObject, 0f);
                            // Box Collider를 비활성화
                            DisableBoxCollider(flr.collider.gameObject);
                        }
                    }
                    
                    //Timer timer = new Timer(BreakCoolTime.setCoolTime, null, 100, Timeout.Infinite);
                    BreakCoolTime.setCoolTime();
                    // 알파값을 0으로 설정

                }
            }
        }
    }
        
    
}
