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


    public GameObject[] firstEnemy = new GameObject[100];
    [SerializeField]
    private GameObject firstEnemyPrefebs;

    public int firstEnemyIndex = 0;


    public GameObject[] secondEnemy = new GameObject[10];
    [SerializeField]
    private GameObject secondEnemyPrefebs;

    public int secondEnemyIndex = 0;
    public GameObject[] thirdEnemy = new GameObject[10];
    [SerializeField]
    private GameObject thirdEnemyPrefebs;

    public int thirdEnemyIndex = 0;


    // Start is called before the first frame update
    void Awake()
    {
        GameObject bulletPools = new GameObject("BulletPool");
        GameObject enemyPool = new GameObject("EnemyPool");

        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this.gameObject);

        for (int i = 0; i < bulletPool.Length; i++)
        {
            bulletPool[i] = Instantiate(bulltPrefebs);
            bulletPool[i].transform.parent = bulletPools.transform;
            bulletPool[i].SetActive(false);
        }
        for (int i = 0; i < enemyBulletPool.Length; i++)
        {
            enemyBulletPool[i] = Instantiate(enemyBulltPrefebs);
            enemyBulletPool[i].transform.parent = bulletPools.transform;
            enemyBulletPool[i].SetActive(false);
        }
        for (int i = 0; i < firstEnemy.Length; i++)
        {
            firstEnemy[i] = Instantiate(firstEnemyPrefebs);
            firstEnemy[i].transform.parent = enemyPool.transform;
            firstEnemy[i].SetActive(false);
        }

    }




    // Update is called once per frame
    void Update()
    {

    }
}
