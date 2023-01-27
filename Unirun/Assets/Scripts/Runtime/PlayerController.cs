using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private const float PLAYER_STEP_ON_Y_ANGLE_MIN = 0.7f;
    public float jumpForce = 700f;
    private bool isGrounded = false;
    private bool isDead = false;
    private Rigidbody2D rigi = null;
    private Animator ani = null;
    public AudioClip deadSound = null;
    private AudioSource playerAudio = null;
    private int jumpCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigi = gameObject.GetComponentMust<Rigidbody2D>();
        // rigi = GetComponent<Rigidbody2D>();
        ani = gameObject.GetComponentMust<Animator>();
        playerAudio = gameObject.GetComponentMust<AudioSource>();
        // ani = GetComponent<Animator>();
        // // playerAudio = GetComponent<AudioSource>();
        // GFunc.Assert(rigi != null || rigi != default);
        // GFunc.Assert(ani != null || ani != default);
        // GFunc.Assert(playerAudio != null || playerAudio != default);
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead) {
            return;
        }
        Jump();
        ani.SetBool("Grounded", isGrounded);
    }


    void Die()
    {
        ani.SetTrigger("Die");
        playerAudio.clip = deadSound;
        playerAudio.Play();
        rigi.velocity = Vector2.zero;
        rigi.gravityScale = 0;
        isDead = true;
        GameManager.instance.OnPlayerDead();
    }
    void Jump()
    {
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;
            rigi.velocity = Vector2.zero;
            rigi.AddForce(new Vector2(0,jumpForce));
            playerAudio.Play();
        }
        // 더블점프 할 때
        else if (Input.GetMouseButtonUp(0) && rigi.velocity.y > 0)
        {
            rigi.velocity = rigi.velocity * 0.5f;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DeadZone") && !isDead)
        {
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (PLAYER_STEP_ON_Y_ANGLE_MIN < other.contacts[0].normal.y)
        {
            jumpCount = 0;
            isGrounded = true;
        }

    }
    private void OnCollisionExit2D(Collision2D other) {
        isGrounded = false;
    }
}
