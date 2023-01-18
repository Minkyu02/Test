using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameControl : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;
    public Image[] heart = new Image[3];

    private float surviveTime;
    private PlayerState state = null;

    // Start is called before the first frame update
    void Start()
    {
        state = GameManager.instance.StateCall();
    }

    // Update is called once per frame
    void Update()
    {
        if (!state.IsDie)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time : " + (int)surviveTime;
        }
        else if (Input.GetKeyDown(KeyCode.R)) {
            GFunc.LoadScene("SampleScene");
        }
    }

    public void EndGame()
    {
        state.IsDie = true;
        GameObject uiobjs_ = GFunc.GetRootObj("Canvas");
        gameoverText = uiobjs_.FindChildobj("Gameover Text");
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);

        }

        recordText.text = "Best Time : " + (int) bestTime;
    }
}
