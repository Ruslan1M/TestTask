using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Events : MonoBehaviour
{
    public static event Action ConditionCompleted;
    public static event Action textSaved;
    public static void onCondtitionCompleted()
    {
        ConditionCompleted?.Invoke();
    }

    public static void onLanguageSaved()
    {
        textSaved?.Invoke();
    }

}
