using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private const string UI_OBJS = "UiObjs";
    private const string SCORE_TEXT_OBJS = "ScoreTxt";
    private const string GAME_OVER_UI_OBJS = "GameOverUi";
    private int score = 0;
    public bool isGameOver = false;
    
    private GameObject scoreTxtobj = null;
    private GameObject gameOverUi = null;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {

            instance = this;
            // Init
            isGameOver = false;
            GameObject uiObjs_ = GFunc.GetRootObj(UI_OBJS);
            scoreTxtobj = uiObjs_.FindChildobj(SCORE_TEXT_OBJS);
            gameOverUi = uiObjs_.FindChildobj(GAME_OVER_UI_OBJS);

            score = 0;
        } // if: 게임 매니저가 존재하지 않는 경우 변수에 할당 및 초기화
        else
        {
            GFunc.LogWarning("[System] GameManager: Duplicated object warning");
            Destroy(gameObject);
        }

    }

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver && Input.GetMouseButtonDown(0))
        {
            GFunc.LoadScene(GFunc.GetAtiveScene().name);
        }
    }

    public void AddSCore(int newScore)
    {
        if (isGameOver == true)
        {
            return;
        }
        score += newScore;
        scoreTxtobj.SetTmpText($"score : {score}");
    }

    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverUi.SetActive(true);
    }
}
