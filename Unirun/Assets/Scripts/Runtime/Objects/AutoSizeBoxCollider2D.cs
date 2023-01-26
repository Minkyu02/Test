using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoSizeBoxCollider2D : MonoBehaviour
{
    private BoxCollider2D box = null;
    private RectTransform rectParent = null;
    private RectTransform rect = null;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 objsize_ = default;
        box = gameObject.GetComponentMust<BoxCollider2D>();
        rectParent = transform.parent.gameObject.GetComponentMust<RectTransform>();
        rect = gameObject.GetComponentMust<RectTransform>();

        objsize_.x = rectParent.sizeDelta.x;
        objsize_.y = rect.sizeDelta.y;

        box.size = objsize_;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
