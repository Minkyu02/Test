using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float BulletSpeed = 8f;
    private Rigidbody rigi = null;
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        rigi.velocity = transform.forward * BulletSpeed;
        Destroy(gameObject,3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
