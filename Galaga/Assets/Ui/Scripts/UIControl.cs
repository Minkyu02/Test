using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    public TMP_Text playerHp;
    public GameObject gameoverText;
    private PlayerState state = null;
    public TMP_Text bestScore;
    public TMP_Text nowScore;
    private int bestScore_;
    
    // Start is called before the first frame update
    void Start()
    {

        state = GameManager.instance.player.GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHp.text = $"X : {GameManager.instance.player.GetComponent<PlayerState>().PlayerLife}";
        Die();
        if (state.IsDie) {
            if (Input.GetKeyDown(KeyCode.R)) {
                Time.timeScale = 1.0f;
                SceneManager.LoadScene("PlayGame");
            }
            bestScore_ = PlayerPrefs.GetInt("BestScore");
            if (state.Scroe > bestScore_) {
                PlayerPrefs.SetInt("BestScore",state.Scroe);
            }
            else {
                PlayerPrefs.SetInt("BestScore",bestScore_);
            }
            bestScore.text = $"BestScore : {PlayerPrefs.GetInt("BestScore")}";
        }
        else {
            nowScore.text = $"Score : {state.Scroe}";
        }
    }

    private void Die() {

        if (state.PlayerLife <= 0) {
            gameoverText.SetActive(true);
            GameManager.instance.player.SetActive(false);
            state.IsDie = true;
            Time.timeScale = 0f;
        }
    }


}
