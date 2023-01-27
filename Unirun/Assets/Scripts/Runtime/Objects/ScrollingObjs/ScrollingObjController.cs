using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjController : MonoBehaviour
{
    public string prefabName = null;
    public int scrollingObjCount = 0;
    protected float prefabYPos = 0f;
    protected GameObject objPrefab = null;
    protected List<GameObject> scrollingPool = null;
    protected Vector2 objPrefabSize = Vector2.zero;
    public float scrollingSpeed = 0f;
    private float lastScrObjInitXPos = default;

    // Start is called before the first frame update
    public virtual void Start()
    {
        objPrefab = gameObject.FindChildobj(prefabName);

        scrollingPool = new List<GameObject>();
        objPrefabSize = objPrefab.GetRectSizeDelta();
        prefabYPos = objPrefab.transform.localPosition.y;
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
        InitObjsPosition();

    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (scrollingPool == null || scrollingPool.Count <= 0)
        {
            return;
        }

        if (GameManager.instance.isGameOver == false)
        {
            for (int i = 0; i < scrollingObjCount; i++)
            {
                scrollingPool[i].AddLocalPos(scrollingSpeed * Time.deltaTime * (-1), 0f, 0f);

            }
            RepositionFirstObj();
        }

    }

    protected virtual void InitObjsPosition()
    {

    }

    protected virtual void RepositionFirstObj()
    {

    }
}
