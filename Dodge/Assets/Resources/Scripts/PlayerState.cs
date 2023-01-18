using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private bool isDie;
    private int hp;
    private GameControl gameControl = null;
    public int Hp
    {
        get; set;
    }

    public bool IsDie {
        get; set;
    }
    private void Awake()
    {
        Hp = 3;
        IsDie = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameControl = GameObject.Find("GameControl").GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Die()
    {
        gameObject.SetActive(false);
        isDie = true;
        gameControl.EndGame();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Bullet")) {
            Hp -= 1;
            gameControl.heart[(int)Hp].enabled = false;
            Destroy(other.gameObject);
        }
    }


}
