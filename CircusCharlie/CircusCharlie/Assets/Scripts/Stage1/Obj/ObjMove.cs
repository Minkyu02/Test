using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMove : MonoBehaviour
{
    private ObjPooling pool = null;
    private float objSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        pool = transform.parent.GetComponent<ObjPooling>();   
    }

    // Update is called once per frame
    void Update()
    {
        pool.poolDestroy(gameObject);
        transform.Translate(Vector3.left * Time.deltaTime * objSpeed);
    }
}
