using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GamemodeManager : MonoBehaviour
{
    [SerializeField]
    private int currentGamemode;
    private int innocentDeaths;
    [SerializeField]
    private TMP_Text innocentDeathsText;
    [SerializeField]
    private int maxTime;
    private float timer;
    [SerializeField]
    private TMP_Text timerText;
    [SerializeField]
    private GameObject gameEndGameObject;
    [SerializeField]
    private TMP_Text gameEndText;
    private int gameStopped = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (currentGamemode == 0)
        {
            timer = maxTime;
        }
        else timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStopped == 1) return;
        if (currentGamemode == 0)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }
            else EndGame();
            timerText.text = Mathf.Ceil(timer).ToString();
        }
        else
        {
            if (innocentDeaths == 0)
            {
                timer += Time.deltaTime;
            }
            else EndGame();
            timerText.text = Mathf.Floor(timer).ToString();
        }
    }
    public void AddDeath()
    {
        innocentDeaths++;
        innocentDeathsText.text = innocentDeaths.ToString();
    }

    private void EndGame()
    {
        Cursor.lockState = CursorLockMode.None;
        gameEndGameObject.SetActive(true);
        if (currentGamemode == 0)
        {
            gameEndText.text = "You murdered " + innocentDeaths + " innocent grass.";
            if (PlayerPrefs.GetInt("gm0best") > innocentDeaths)
                PlayerPrefs.SetInt("gm0best", innocentDeaths);
        }
        else
        {
            if (PlayerPrefs.GetFloat("gm1best") < timer)
                PlayerPrefs.SetFloat("gm1best", timer);
            gameEndText.text = "You survived " + Mathf.Round(timer*10f)/10f + " seconds without murdering innocent grass.";
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
