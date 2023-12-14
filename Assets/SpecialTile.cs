using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialTile : MonoBehaviour
{
    // Start is called before the first frame update
    int rand;//20

    public GameObject slow;
    public GameObject slowR;
    public GameObject slowL;

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
    }
}
