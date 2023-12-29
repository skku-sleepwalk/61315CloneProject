using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakCoolTime : MonoBehaviour
{
    private static float breakCoolTime = 1f;
    public static bool getCoolTime()
    {
        return (breakCoolTime >= 0.5f);
    }
    public static bool getCombo()
    {
        return (!(breakCoolTime >= 1.0f));
    }
    public static void setCoolTime()
    {
        //매개변수 object state
        breakCoolTime = 0;
    }
    void Update()
    {
        breakCoolTime += Time.deltaTime;
    }
}
