using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static partial class GFunc // static한개당 4바이트 할당 -> static으로 1개의 function을 만들면 4바이트 추가

{

    #region  Print log func
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message)
    {
#if DEBUG_MODE
        Debug.Log(message);
#endif
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message, Object context)
    {
#if DEBUG_MODE
        Debug.Log(message, context);
#endif
    }
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void LogWarning(object message)
    {
#if DEBUG_MODE
        Debug.LogWarning(message);
#endif
    }
    #endregion


    #region Assert for debug
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Assert(bool condition)
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif
    }
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Assert(bool condition, object message)
    {
#if DEBUG_MODE
        Debug.Assert(condition, message);
#endif
    }

    #endregion

    #region  Vaild Func
    public static bool IsValid<T>(this T component_)
    {
        bool IsValid = component_.Equals(null) == false;
        return IsValid;

    }



    #endregion
}
