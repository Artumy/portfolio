using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibroControl : MonoBehaviour
{
    public static VibroControl Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }

    public static void Vibrate(float ms)
    {
#if UNITY_EDITOR
        return;
#endif
        PhoneVIbrateCustom.Vibrate((long)ms);
    }
}
