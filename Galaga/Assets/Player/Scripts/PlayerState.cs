using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private float playerSpeed;
    private int playerLife;
    public float PlayerSpeed {
        get; set;
    }

    public float PlayerLife {
        get; set;
    }
    private void Awake() {
        PlayerSpeed = 10f;
        PlayerLife = 3;
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
