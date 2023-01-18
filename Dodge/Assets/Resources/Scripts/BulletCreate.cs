using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletCreate : MonoBehaviour
{
    public GameObject Bullet;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private PlayerState state = null;
    private Transform target = null;
    private float spawnRate;
    private float timeAfterSpawn;
    // Start is called before the first frame update
    void Start()
    {
        state = GameManager.instance.StateCall();
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            gameObject.transform.LookAt(target);
            GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation);
            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }

    }
}
