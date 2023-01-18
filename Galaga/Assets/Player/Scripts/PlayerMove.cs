using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Rigidbody rigi = null;
    private PlayerState state = null;
    private float playerSpeed;
    private bool isShoot = false;
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        state = GameManager.instance.player.GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (rigi.transform.position.x < -29)
            {
                // Do Nothing
            }
            else
            {
                rigi.MovePosition(rigi.position + Vector3.left * Time.deltaTime * state.PlayerSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (rigi.transform.position.x > 29)
            {
                // Do Nothing
            }
            else
            {
                rigi.MovePosition(rigi.position + Vector3.right * Time.deltaTime * state.PlayerSpeed);
            }
        }

    }

    private void Shoot()
    {
        if (Input.GetKey(KeyCode.Space) && isShoot == false)
        {
            // 풀링한 오브젝트 위치 옮기고 활성화
            if (i > ObjPool.instance.bulletPool.Length - 1)
            {
                i = 0;
            }
            ObjPool.instance.bulletPool[i].transform.position = gameObject.transform.position;
            ObjPool.instance.bulletPool[i].SetActive(true);
            i++;
            StartCoroutine(ShootCool());
        }
    }

    IEnumerator ShootCool()
    {
        isShoot = true;
        yield return new WaitForSeconds(0.2f);
        isShoot = false;
    }

}
