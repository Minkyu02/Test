using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isShoot = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnEnable()
    {
    }


    // Update is called once per frame
    void Update()
    {
        if (!isShoot) {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (ObjPool.instance.eBulletIndex > ObjPool.instance.enemyBulletPool.Length - 1)
        {
            ObjPool.instance.eBulletIndex = 0;
        }
        ObjPool.instance.enemyBulletPool[ObjPool.instance.eBulletIndex].transform.position = gameObject.transform.position;
        ObjPool.instance.enemyBulletPool[ObjPool.instance.eBulletIndex].SetActive(true);
        ObjPool.instance.eBulletIndex++;
        StartCoroutine(ShootRate());
    }

    IEnumerator ShootRate()
    {
        isShoot = true;
        yield return new WaitForSeconds(1.0f);
        isShoot = false;
    }
}
