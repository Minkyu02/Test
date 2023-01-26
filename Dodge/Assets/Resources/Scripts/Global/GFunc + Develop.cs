using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static partial class GFunc // static한개당 4바이트 할당 -> static으로 1개의 function을 만들면 4바이트 추가

{

    #region  Print log func
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message)
    {
        Debug.Log(message);
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message, Object context)
    {
        Debug.Log(message, context);
    }
    #endregion
}
