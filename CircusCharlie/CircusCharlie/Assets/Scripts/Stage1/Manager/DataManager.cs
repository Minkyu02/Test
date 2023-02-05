using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager instance = null;
    bool timer = false;
    private int score;
    public bool isClear = false;
    public Text scoreTxt = null;
    private int life;
    public Image[] lifeImage = new Image[3];

    public int Score
    {
        get; set;
    }
    public int Life
    {
        get; set;
    }
    private void Awake()
    {
        Score = 5000;
        Life = 3;
        if (instance == null)
        {
            instance = this;
        }
        else
        {

            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!timer && Score > 10 && !isClear)
        {
            StartCoroutine(ScoreAdd());
        }
        scoreTxt.text = $"Bonus Score : {Score}";

    }


    IEnumerator ScoreAdd()
    {
        timer = true;
        yield return new WaitForSeconds(1.0f);
        Score -= 10;
        timer = false;
    }
}
