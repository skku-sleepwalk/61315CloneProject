using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemManage : MonoBehaviour
{
    private static bool isShield;
    private void Start()
    {
        isShield = false;
    }
    public static bool getIsShield()
    {
        return isShield;
    }
    public static void isShieldToTrue()
    {
        isShield = true;
        return;
    }
    public static void isShieldToFalse()
    {
        isShield = false;
        return;
    }
}
