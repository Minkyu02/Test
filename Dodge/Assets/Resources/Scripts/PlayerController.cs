using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigi = null;
    private CapsuleCollider collider_ = null;
    private float playerSpeed = 8f;
    private bool isDie = false;
    private PlayerState state = null;
    
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        collider_ = GetComponent<CapsuleCollider>();
        state = GameManager.instance.StateCall();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (state.Hp <= 0)
        {
            state.IsDie = true;
            state.Die();
        }
        if (Input.GetKey(KeyCode.Q)) {
            GFunc.QuitThisGame();
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigi.MovePosition(rigi.position + Vector3.forward * Time.deltaTime * playerSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigi.MovePosition(rigi.position + Vector3.left * Time.deltaTime * playerSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigi.MovePosition(rigi.position + Vector3.right * Time.deltaTime * playerSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //rigi.MovePosition(rigi.position + new Vector3(0,0,-1) * Time.deltaTime * playerSpeed);
            rigi.MovePosition(rigi.position + Vector3.back * Time.deltaTime * playerSpeed);
        }
    }


    private void NewMove()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * playerSpeed;
        float zSpeed = zInput * playerSpeed;

        Vector3 playerVelo = new Vector3(xSpeed, 0f, zSpeed);
        rigi.velocity = playerVelo;

    }



}
