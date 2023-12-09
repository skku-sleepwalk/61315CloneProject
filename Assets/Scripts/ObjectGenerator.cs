using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectGenerator : MonoBehaviour
{

    public GameObject floors;
    public GameObject enemy;
    public GameObject shieldItem;
    // Start is called before the first frame update
    //float timer=0;
   // public int timediff=1;
    public GameObject character;
    public int Frequency;
    private int randomValue;
    private int randomValue2;
    private int randomValue3;
    private int randomValue4;
    private float summonCool=0f;

    private GameObject floorInstant;

    private int floorSummonPosition=-6;
   // public Transform blockParent;

    int sign;
    int itemSign;
    private float interval = 0.2f;
    GameObject CheckAndSpawnObject(Vector3 targetPosition)
    {
        // 특정 좌표에 있는 객체를 찾기
        Collider2D[] colliders = Physics2D.OverlapCircleAll(targetPosition, 0.01f);

        if (colliders.Length == 0)
        {
            // 특정 좌표에 객체가 없으면 새로운 객체 생성
            return SpawnObject(targetPosition,floors);
        }
        else return null;
    }

    GameObject SpawnObject(Vector3 spawnPosition, GameObject obj)
    {
        // 새로운 객체 생성
        
        GameObject newObject = Instantiate(obj, spawnPosition, Quaternion.identity);
        return newObject;
      
    }
    GameObject SpawnFloor(Vector3 spawnPosition)
    {
        GameObject newObject = PoolingManager.GetObject();
        newObject.transform.position = spawnPosition;
        return newObject;
    }
    void Start()
    {
        Frequency = 2;
         summonCool = 0f;
        for (int j=0;j<10;j++){
            randomValue = Random.Range(0, 15);//적
            randomValue2 = Random.Range(0, 15);//아이템 위치
            randomValue3 = Random.Range(0, 6);//아이템 생성 확률
            sign =Random.Range(0, 2);
            itemSign = Random.Range(0, 2);
            for (int i=0;i<33;i++){
                SpawnObject(new Vector3((i * interval), (2f - j), 0),floors);
                if (i==randomValue)
                { //적 생성
                    GameObject enem=SpawnObject(new Vector3(((sign==0?1:-1)*i * interval), (1.5f - j), 0), enemy);
                    if(sign!=0) enem.transform.right = Vector3.left;
                }
                if(i==randomValue2&&randomValue3==3) SpawnObject(new Vector3(((sign == 0 ? 1 : -1) * i * interval), (1.5f - j), 0), shieldItem);//아이템 생성
                if (i != 0||j!=0) SpawnObject(new Vector3(i*-interval, 2f-j,0),floors);//반대 방향도 생성
            }
        }
    }
    void Update()
    {   
        int k = Mathf.RoundToInt(character.transform.position.x / interval);
        int k2 = Mathf.RoundToInt(-(character.transform.position.x / interval));
        //초기화
        summonCool += Time.deltaTime;
        for(int j = -6; j < 10; j++)
        {
            bool thisFloorEnemyGenerated = false;
            
            for (int i = 12; i < 22; i++)
            {
               

                
                randomValue = Random.Range(12, 22);
                randomValue2 = Random.Range(12, 22);
                sign = Random.Range(0, 2);
                itemSign = Random.Range(0, 2);
                randomValue3 = Random.Range(0, 6);
                randomValue4 = Random.Range(0, Frequency);
                GameObject tmp=null;
                if((int)character.transform.position.y - j < 2)//이게 아마 시작할 때 위에 안 생기게 하려고 하는 거일 거임
                {
                    if (summonCool > 2f)
                    {
                        if (i == randomValue&&!thisFloorEnemyGenerated&&randomValue4==0)
                        {
                            tmp = SpawnObject(new Vector3(((int)character.transform.position.x) + interval * i * (sign == 0 ? 1 : -1), (int)character.transform.position.y - j + 0.5f, character.transform.position.z), enemy);
                            if (tmp != null&&((int)character.transform.position.x) + interval * i * (sign == 0 ? 1 : -1) < character.transform.position.x ) tmp.transform.right = Vector3.left;
                            thisFloorEnemyGenerated = true;
                        }
                        
                        if (i == randomValue2 && randomValue3 == 3) SpawnObject(new Vector3(((int)character.transform.position.x) + interval * i * (itemSign == 0 ? 1 : -1), (int)character.transform.position.y -j +0.5f, character.transform.position.z), shieldItem);
                    }
                    CheckAndSpawnObject(new Vector3(((int)character.transform.position.x)+interval*i, (int)character.transform.position.y-j, character.transform.position.z));
                    CheckAndSpawnObject(new Vector3(((int)character.transform.position.x) - interval * i, (int)character.transform.position.y - j, character.transform.position.z));
                }
             
            }

        }
        //Debug.Log(summonCool);
        if (summonCool > 2f) summonCool = 0f;
        
        
        // 캐릭터랑 거리 계산해서 6이상이면 증가시키고 생성


        if (character.transform.position.y-floorSummonPosition <8)
        {
            floorSummonPosition -= 1;
            //k,k2 언젠가 엎고만다.
            for(int i=k;i<=k+50;i++){
                SpawnObject(new Vector3(i * interval, floorSummonPosition, 0), floors);
                //if (sign == 0 & i == randomValue)
                //{//적 생성
                //    SpawnObject(new Vector3((i * interval), floorSummonPosition + 0.5f, 0), enemy);
                //}   
                //if (itemSign == 0 && i == randomValue2 && randomValue3 == 3)
                //{// 아이템 생성
                //    SpawnObject(new Vector3((i * interval), floorSummonPosition + 0.45f, 0), shieldItem);
                //}
            }
            for(int i=k2;i<=k2+ 50; i++){
                SpawnObject(new Vector3(-(i * interval), floorSummonPosition, 0), floors);
                //if (sign != 0 & i == randomValue)
                //{
                //    GameObject enem=SpawnObject(new Vector3(-(i * interval), floorSummonPosition + 0.5f, 0), enemy);
                //    if(character.transform.position.x> enem.transform.position.x) enem.transform.right = Vector3.left;
                //}
                //if(itemSign!=0&&i==randomValue2 && randomValue3 == 3)
                //{
                //    SpawnObject(new Vector3(-(i * interval), floorSummonPosition + 0.45f, 0), shieldItem);
                //}
            }


        }

    }
}
