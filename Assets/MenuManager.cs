using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text personalBestWorkday, personalBestInfinite;
    private void Start()
    {
        personalBestWorkday.text = "PB: " + PlayerPrefs.GetInt("gm0best", 0).ToString();
        personalBestInfinite.text = "PB: " + (Mathf.Round(PlayerPrefs.GetFloat("gm1best", 0) * 10f)/10f).ToString() + "s";
    }
    public void GoToScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
