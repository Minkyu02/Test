using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rigi = null;
    private float bulletSpeed = 30f;
    private PlayerState state = null;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        state = GameManager.instance.player.GetComponent<PlayerState>();
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

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Enemy")) {
            gameObject.SetActive(false);
            state.Scroe += 1;
            other.gameObject.SetActive(false);
        }
    }
}
