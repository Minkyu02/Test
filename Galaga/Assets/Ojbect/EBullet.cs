using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBullet : MonoBehaviour
{
    private Rigidbody rigi = null;
    private float bulletSpeed = 30f;
    private PlayerState state = null;
    // Start is called before the first frame update
    void Start()
    {
        rigi = gameObject.GetComponent<Rigidbody>();
        state = GameManager.instance.player.GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    private void Shoot()
    {


        rigi.MovePosition(rigi.position + Vector3.down * bulletSpeed * Time.deltaTime);
        if (rigi.position.y < -20)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            state.PlayerLife -= 1;
            gameObject.SetActive(false);
        }
    }

}
