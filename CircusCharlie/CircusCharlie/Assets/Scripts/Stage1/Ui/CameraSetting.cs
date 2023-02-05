using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetting : MonoBehaviour
{
    [SerializeField]
    private GameObject player = null;
    private Vector3 cameraPos = Vector3.zero;
    private Transform playerTrans = null;
    private float camXPos = 0f;
    private bool isCamOver = false;
    // Start is called before the first frame update
    void Start()
    {
        cameraPos = gameObject.transform.position;
        playerTrans = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        camXPos = playerTrans.position.x + 6f;
        if (player.transform.position.x + 6 >= 170) {
            isCamOver = true;
        }
        else {
            cameraPos = new Vector3(camXPos ,gameObject.transform.position.y, gameObject.transform.position.z );
            gameObject.transform.position = cameraPos;
        }

        if (isCamOver) {

        }
    }
}
