using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static partial class GFunc
{
    // 씬의 루트 오브젝트를 서치해서 찾아주는 함수
    public static GameObject GetRootObj(string objName_)
    {
        Scene activeScene_ = GetAtiveScene();
        GameObject[] rootObjs_ = activeScene_.GetRootGameObjects();

        GameObject targetObj_ = null;
        foreach (GameObject rootObj in rootObjs_)
        {
            if (rootObj.name.Equals(objName_))
            {
                targetObj_ = rootObj;
                return targetObj_;
            }
            else { continue; }
        }
        return targetObj_;
    }
    // 특정 오브젝트의 자식 오브젝트를 서치해서 찾아주는 함수
    // private static GameObject GetChildObj(this GameObject targetObj_, string objName_)
    // {
    //     GameObject searchResult = null;
    //     for (int i = 0; i < targetObj_.transform.childCount; i++)
    //     {
    //         if (targetObj_.transform.GetChild(i).gameObject.name.Equals(objName_))
    //         {
    //             searchResult = targetObj_.transform.GetChild(i).gameObject;
    //             return searchResult;
    //         }
    //         else { continue; }
    //     }
    //     return searchResult;

    // }

    // 특정 오브젝트의 자식 오브젝트를 서치해서 찾아주는 함수
    public static GameObject FindChildobj(this GameObject targetObj_, string objName_) {
        GameObject searchResult = null;
        GameObject searchTarget = null;
        for (int i = 0; i < targetObj_.transform.childCount; i++) {
            searchTarget = targetObj_.transform.GetChild(i).gameObject;
            if (searchTarget.name.Equals(objName_)) {
                searchResult = searchTarget;
                return searchResult;
            }
            else {
                searchResult = FindChildobj(searchTarget, objName_);
            }
        }
        if (searchResult == null || searchResult == default) { }
        else {
            return searchResult;
        }
        return searchResult;
    }


    // 현재 활성화 되어 있는 씬을 찾아주는 함수

    public static Scene GetAtiveScene()
    {
        Scene activeScene_ = SceneManager.GetActiveScene();
        return activeScene_;
    }

}
