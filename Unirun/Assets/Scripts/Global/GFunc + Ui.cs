using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public static partial class GFunc
{
    public static void SetTmpText(GameObject obj_, string text_)
    {
        TMP_Text tmpText = obj_.GetComponent<TMP_Text>();
        if (tmpText == null || tmpText == default(TMP_Text))
        {
            return;
        } // 텍스트 매쉬 컴포넌트가 없는 경우

        tmpText.text = text_;

    }
}
