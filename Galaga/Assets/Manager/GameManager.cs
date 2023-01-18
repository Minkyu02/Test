using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instance = this;
        }
        else Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
