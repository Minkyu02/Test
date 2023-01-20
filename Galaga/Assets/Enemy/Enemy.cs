using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isShoot = false;
    private bool isMove = true;
    private int randomNum;
    private Rigidbody rigi = null;
    private bool isLeft = false;
    private bool isCheck = false;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        randomNum = SetEnemy();
    }


    // Update is called once per frame
    void Update()
    {
        if (!isMove)
        {
            Move();
            Shoot();
        }
        else
        {
            MoveEnemy();
        }
        if (!isCheck) {
            StartCoroutine(MoveRate());
        }

    }

    private void Move()
    {
        if (isLeft)
        {
            if (rigi.position.x < -30)
            {
                isLeft = false;
            }
            else
            {
                rigi.MovePosition(rigi.position + Vector3.left * Time.deltaTime * 10);
            }
        }
        else
        {
            if (rigi.position.x > 30)
            {
                isLeft = true;
            }
            else
            {
                rigi.MovePosition(rigi.position + Vector3.right * Time.deltaTime * 10);
            }
        }
    }

    private void MoveEnemy()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.randomPos[randomNum].position, 30 * Time.deltaTime);
        if (transform.position == GameManager.instance.randomPos[randomNum].position)
        {
            isMove = false;
        }
    }
    private int SetEnemy()
    {
        int randomPos = Random.Range(0, 5);
        return randomPos;
    }


    private void Shoot()
    {
        if (!isShoot)
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
    }

    IEnumerator MoveRate()
    {
        isCheck = true;
        int left = Random.Range(0, 2);
        switch (left)
        {
            case 0:
                isLeft = false;
                break;
            case 1:
                isLeft = true;
                break;
        }
        yield return new WaitForSeconds(0.5f);
        isCheck = false;
    }
    IEnumerator ShootRate()
    {
        isShoot = true;
        yield return new WaitForSeconds(0.5f);
        isShoot = false;
    }
}
