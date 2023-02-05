using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPooling : MonoBehaviour
{
    public GameObject fireCirclePrefebs = null;
    private Stack<GameObject> fireCircles = new Stack<GameObject>();
    private GameObject circlePool = null;
    private int poolCount = 3;
    private bool isSpawn = false;
    public int objCount = 0;
    [SerializeField]
    private GameObject player = null;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < poolCount; i++)
        {
            circlePool = Instantiate(fireCirclePrefebs);
            circlePool.transform.parent = gameObject.transform;
            circlePool.SetActive(false);
            fireCircles.Push(circlePool);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        poolActive();
    }

    public void poolActive()
    {
        if (!isSpawn && objCount <= 1 && !player.GetComponent<PlayerMove>().isClear && !player.GetComponent<PlayerMove>().isDie)
        {
            float createZOne = player.transform.position.x + 15f;
            GameObject popCircle = fireCircles.Pop();
            popCircle.transform.position = new Vector3(createZOne, gameObject.transform.position.y, 0f);
            popCircle.SetActive(true);
            objCount ++;
            StartCoroutine(SpawnCool());
        }
    }

    public void poolDestroy(GameObject obj_)
    {
        float destoryZone = Camera.main.transform.position.x - 9f;
        if (player.GetComponent<PlayerMove>().isDie) {
            obj_.SetActive(false);
            fireCircles.Push(obj_);
            objCount--;
        }

        if (obj_.transform.position.x <= destoryZone)
        {
            obj_.SetActive(false);
            fireCircles.Push(obj_);
            objCount--;
        }
    }

    IEnumerator SpawnCool() {
        isSpawn = true;
        yield return new WaitForSeconds(Random.Range(3f,6f));
        isSpawn = false;
    }
}
