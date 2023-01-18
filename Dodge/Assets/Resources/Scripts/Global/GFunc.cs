using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static partial class GFunc // static한개당 4바이트 할당 -> static으로 1개의 function을 만들면 4바이트 추가

{
    public static void QuitThisGame() {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public static void LoadScene(string sceneName_) {
        SceneManager.LoadScene(sceneName_);
    }
}
