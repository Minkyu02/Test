using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private GameObject gameoverText = null;
    public GameObject gameClear = null;
    public bool isFin = false;
    public bool isDie = false;
    public bool isJump = false;
    public bool isClear = false;
    private float jumpForce = 7f;
    private float moveSpeed = 3f;
    private Rigidbody2D playerRigi = null;
    private Animator playerAni = null;
    // Start is called before the first frame update
    void Start()
    {
        playerRigi = GetComponent<Rigidbody2D>();
        playerAni = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isClear) {
            GameClear();
            return;
        }
        KeyMove();
        Die();
    }

    public void Move(bool dir_)
    {
        if (!isDie && !isClear)
        {
            switch (dir_)
            {
                case true:
                    playerRigi.velocity = new Vector2(-moveSpeed, playerRigi.velocity.y);
                    playerAni.SetBool("isMove", true);
                    break;
                case false:
                    playerRigi.velocity = new Vector2(moveSpeed, playerRigi.velocity.y);
                    playerAni.SetBool("isMove", true);
                    break;
            }
        }
    }




    public void KeyMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRigi.velocity = new Vector2(-moveSpeed, playerRigi.velocity.y);
            playerAni.SetBool("isMove", true);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRigi.velocity = new Vector2(moveSpeed, playerRigi.velocity.y);
            playerAni.SetBool("isMove", true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAni.SetBool("isJump", true);
            playerRigi.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJump = true;
        }
    }
    private void GameClear()
    {
        playerRigi.velocity = Vector2.zero;        
        playerAni.SetTrigger("isClear");
        gameClear.SetActive(true);
        DataManager.instance.isClear = true;
        
    }
    private void Die() {
        if (DataManager.instance.Life <= 0) {
            isFin = true;
            gameoverText.SetActive(true);
        } 
    }

    public void OnBtnJump()
    {
        if (!isJump && !isDie && !isClear)
        {
            playerAni.SetBool("isJump", true);
            playerRigi.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            playerAni.SetBool("isJump", false);
            isJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Obj") && !isClear)
        {
            isDie = true;
            playerAni.SetBool("isDie",true);
            playerRigi.velocity = Vector2.zero;
            DataManager.instance.Life --;
            DataManager.instance.lifeImage[DataManager.instance.Life].transform.gameObject.SetActive(false);
            StartCoroutine(Cooltime());
        }
    }

    IEnumerator Cooltime() {
        yield return new WaitForSeconds(2f);
        playerAni.SetBool("isDie",false);
        isDie = false;
    }



}
