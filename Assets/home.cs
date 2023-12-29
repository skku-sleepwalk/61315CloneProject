using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class home : MonoBehaviour, IPointerClickHandler
{

 
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("FFfff");
        Time.timeScale = 1f;
        CameraMove.isMoving = true;
        Stop.stoped = false;
        SceneManager.LoadScene("StartScene");
    }

}
