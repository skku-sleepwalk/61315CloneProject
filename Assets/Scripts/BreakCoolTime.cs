using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakCoolTime : MonoBehaviour
{
    private static float breakCoolTime = 1f;
    public static bool getCoolTime()
    {
        return (breakCoolTime >= 0.4f);
    }
    public static void setCoolTime(object state)
    {

        breakCoolTime = 0;
    }
    void Update()
    {
        breakCoolTime += Time.deltaTime;
    }
}
