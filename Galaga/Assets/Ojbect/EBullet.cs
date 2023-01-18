using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBullet : MonoBehaviour
{
    private Rigidbody rigi = null;
    private float bulletSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rigi = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    private void Shoot()
    {

        rigi.MovePosition(rigi.position + new Vector3((GameManager.instance.player.transform.position.x - rigi.position.x) * Time.deltaTime, -1 * bulletSpeed * Time.deltaTime, 0));
        if (rigi.position.y < -20)
        {
            gameObject.SetActive(false);
        }
    }

}
