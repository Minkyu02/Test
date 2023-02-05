using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerMove>().isClear = true;
        }
    }


    // 개발도중 오류사항 -> (isClear가 true로 변하고 플레이어 애니메이션이 재생되야 하는데 첫 부분에서 멈추는 이슈)
    // 해결 -> 멈추는 것이 아니라 AnyState에 있는 can translation to self가 켜져있어서 Trigger가 true로 변했을 때 계속 처음으로 자기자신을 호출함으로 발생한 이슈
    // Has exit time도 꺼져있어서 최소한의 동작도 안하고 바로 호출된 것!
    
}
