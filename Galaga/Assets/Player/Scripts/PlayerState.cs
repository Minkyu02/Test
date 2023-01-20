using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private float playerSpeed;
    private int playerLife;

    private bool isDie;
    private int score;
    public float PlayerSpeed
    {
        get; set;
    }

    public bool IsDie
    {
        get; set;
    }

    public float PlayerLife
    {
        get; set;
    }

    public int Scroe
    {
        get; set;
    }
    private void Awake()
    {
        PlayerSpeed = 20f;
        PlayerLife = 3;
        IsDie = false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
