using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private bool isSpawn = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }


    void Spawn()
    {
        if (!isSpawn)
        {
            int spawnPoint = Random.Range(0, 2);
            if (ObjPool.instance.firstEnemyIndex > ObjPool.instance.firstEnemy.Length - 1)
            {
                ObjPool.instance.firstEnemyIndex = 0;
            }
            ObjPool.instance.firstEnemy[ObjPool.instance.firstEnemyIndex].transform.position = gameObject.transform.GetChild(spawnPoint).position;
            ObjPool.instance.firstEnemy[ObjPool.instance.firstEnemyIndex].SetActive(true);
            ObjPool.instance.firstEnemyIndex++;
            StartCoroutine(SpawnCool());
        }
    }

    IEnumerator SpawnCool()
    {
        isSpawn = true;
        yield return new WaitForSeconds(2.0f);
        isSpawn = false;
    }
}
