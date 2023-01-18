using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rigi = null;
    private float bulletSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }

    private void OnEnable() {
        // StartCoroutine(DestroyBullet());
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot() {
        rigi.MovePosition(rigi.position + Vector3.up * bulletSpeed * Time.deltaTime);
        if (rigi.position.y > 20) {
            gameObject.SetActive(false);
        }
    }
    // IEnumerator DestroyBullet() {
    //     yield return new WaitForSeconds(3.0f);
    //     gameObject.SetActive(false);
    // }
}
