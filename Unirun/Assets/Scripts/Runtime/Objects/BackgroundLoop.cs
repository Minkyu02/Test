using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : GComponent
{
    private float width = 0;
    public override void Awake() {
        width = gameObject.GetRectSizeDelta().x;
    }
    // Start is called before the first frame update
    public override void Start() {
        
    }

    // Update is called once per frame
    public override void Update() {
        if (transform.localPosition.x <= -width) {
            Reposition();
        }
    }

    private void Reposition() {
        Vector3 offset = new Vector3(width * 2f - 100f, 0f, 0f);
        transform.localPosition = transform.localPosition + offset;
    }
}
