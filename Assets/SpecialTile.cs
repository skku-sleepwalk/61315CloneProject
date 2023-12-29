using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpecialTile : MonoBehaviour
{
    // Start is called before the first frame update
    int rand;//20

    public GameObject slow;
    public GameObject slowR;
    public GameObject slowL;

    Transform myT;


    private void Awake()
    {
        rand= Random.Range(0, 100);
        if (rand == 0)
        {
            GameObject specialTile=Instantiate(slow);
            specialTile.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.05f, gameObject.transform.position.z);
            GameObject specialTileL = Instantiate(slowL);
            specialTileL.transform.position = new Vector3(gameObject.transform.position.x-0.2f, gameObject.transform.position.y - 0.05f, gameObject.transform.position.z);
            GameObject specialTileR = Instantiate(slowR);
            specialTileR.transform.position = new Vector3(gameObject.transform.position.x+0.2f, gameObject.transform.position.y - 0.05f, gameObject.transform.position.z);
        }
        if (rand == 1/*==1<99*/)
        {
           
         //¹ÝÅõ¸í

            Renderer currentColor = gameObject.GetComponent<Renderer>();
            Color a =currentColor.material.color;
            a.a = 0.5f;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            Vector2 RayPoint = gameObject.transform.position;
            RaycastHit2D hit = Physics2D.Raycast(RayPoint, Vector3.left, 1, 1 << 6);
            RaycastHit2D hit2 = Physics2D.Raycast(RayPoint, Vector3.right, 1, 1 << 6);

             currentColor = hit.collider.gameObject.GetComponent<Renderer>();
          a = currentColor.material.color;
            a.a = 0.5f;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            currentColor = hit2.collider.gameObject.GetComponent<Renderer>();
            a = currentColor.material.color;
            a.a = 0.5f;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
    private void Start()
    {

    }

    IEnumerator PopCoroutine()
    {
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        Color currentColor = renderer.color;
        myT = transform;
        Vector3 targetPosition = myT.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(0f, 0.5f));
        Vector3 previousPosition = myT.position;

        for (int i = 0; i < 20; i++)
        {
            currentColor.a = Mathf.Lerp(currentColor.a, 0f, 0.07f);
            renderer.color = currentColor;
            myT.position = Vector2.Lerp(myT.position, targetPosition, 0.07f);
            yield return new WaitForSeconds(0.03f);
        }
        renderer.color = new Color(1f, 1f, 1f, 0f);
        myT.position = previousPosition;
    }

    public void InvokeCoroutine()
    {
       
        StartCoroutine(PopCoroutine());
    }
}
