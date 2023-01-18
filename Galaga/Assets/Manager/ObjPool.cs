using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPool : MonoBehaviour
{

    public static ObjPool instance = null;
    public GameObject[] bulletPool = new GameObject[40];
    [SerializeField]
    private GameObject bulltPrefebs;

    public GameObject[] enemyBulletPool = new GameObject[100];
    [SerializeField]
    private GameObject enemyBulltPrefebs;
    public int eBulletIndex = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this.gameObject);
        for (int i = 0; i < bulletPool.Length; i++)
        {
            bulletPool[i] = Instantiate(bulltPrefebs);
            bulletPool[i].SetActive(false);
        }
        for (int i = 0; i < enemyBulletPool.Length; i++)
        {
            enemyBulletPool[i] = Instantiate(enemyBulltPrefebs);
            enemyBulletPool[i].SetActive(false);
        }
    }




    // Update is called once per frame
    void Update()
    {

    }
}
