using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjController : MonoBehaviour
{
    public string prefabName = null;
    public int scrollingObjCount = 0;

    private GameObject objPrefab = null;
    private List<GameObject> scrollingPool = null;
    // Start is called before the first frame update
    void Start()
    {
        objPrefab = gameObject.FindChildobj(prefabName);

        scrollingPool = new List<GameObject>();
        Vector2 objPrefabSize = objPrefab.GetRectSizeDelta();
        GameObject tempObj = null;
        if (scrollingPool.Count <= 0)
        {
            for (int i = 0; i < scrollingObjCount; i++)
            {
                tempObj = Instantiate(objPrefab, objPrefab.transform.position, transform.rotation, transform);
                scrollingPool.Add(tempObj);
                tempObj = null;
            }
        }

        objPrefab.SetActive(false);
        int scrollCntIndex = scrollingObjCount - 1;
        float horizonPos = 0f;
        for (int i = 0; i < scrollingObjCount; i++) {
            horizonPos = objPrefabSize.x * scrollCntIndex * (-1 + i) * 0.5f;
            scrollingPool[i].SetLocalPos(horizonPos,0f,0f);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
