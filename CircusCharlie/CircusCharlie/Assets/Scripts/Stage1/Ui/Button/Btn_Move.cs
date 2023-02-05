using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Btn_Move : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isLeft = false;
    private bool isClicked = false;
    [SerializeField]
    private GameObject player = null;
    private PlayerMove playerMove = null;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = player.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked && !playerMove.isJump)
        {
            playerMove.Move(isLeft);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isClicked = false;
        if (!playerMove.isJump)
        {
            playerMove.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        player.GetComponent<Animator>().SetBool("isMove", false);
    }


}
