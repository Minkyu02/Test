using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingPlatformController : ScrollingObjController
{
    private bool isStart = false;


    public override void Start()
    {
        base.Start();
        isStart = true;
    }

    public override void Update()
    {
        base.Update();
    }

    protected override void InitObjsPosition()
    {
        base.InitObjsPosition();
        Vector2 posOffset = Vector2.zero;
        float xPos = objPrefabSize.x * (scrollingObjCount - 1) * (-1) * 0.5f;
        float yPos = prefabYPos;
        for (int i = 0; i < scrollingObjCount; i++)
        {
            scrollingPool[i].SetLocalPos(xPos, yPos, 0f);
            posOffset = GetRamdomPosOffset();

            if (isStart == true && i == 1)
            {
                xPos = xPos + objPrefabSize.x;
                isStart = false;
            }
            else
            {
                xPos = xPos + objPrefabSize.x + posOffset.x;
            }
            yPos = prefabYPos + posOffset.y;
        }
    }

    protected override void RepositionFirstObj()
    {
        base.RepositionFirstObj();
        float lastScrObjCurrentXPos = scrollingPool[scrollingObjCount - 1].transform.localPosition.x;
        if (lastScrObjCurrentXPos <= objPrefabSize.x * 0.5f)
        {
            Vector2 posOffset = Vector2.zero;
            posOffset = GetRamdomPosOffset();
            float lastScrObjInitXPos = Mathf.Floor(scrollingObjCount * 0.5f) * objPrefabSize.x + (objPrefabSize.x * 0.5f);
            scrollingPool[0].SetLocalPos(lastScrObjInitXPos + posOffset.x - 1.2f, prefabYPos + posOffset.y, 0f);
            scrollingPool.Add(scrollingPool[0]);
            scrollingPool.RemoveAt(0);
        }
    }

    private Vector2 GetRamdomPosOffset()
    {
        Vector2 offset = Vector2.zero;
        offset.x = Random.Range(50f, 300f);
        offset.y = Random.Range(-80f, 30f);


        return offset;
    }
}
