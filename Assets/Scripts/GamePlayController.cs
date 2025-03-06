using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;
    public GameObject loseLevel;
    private int currentLevel;
    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        PlayerPrefs.Save();
    }
    public void Lose()
    {
        var iq = PlayerPrefs.GetInt("IQ");
        PlayerPrefs.SetInt("IQ", iq-1);
        PlayerPrefs.Save(); 
        gameObject.SetActive(false);
        loseLevel.SetActive(true);
        loseLevel.GetComponent<LoseLevelController>().Show();
    }

    // Update is called once per frame
    public void Win()
    {
        var iq = PlayerPrefs.GetInt("IQ");
        PlayerPrefs.SetInt("IQ", iq+1);
        PlayerPrefs.Save();
        if (currentLevel < PlayerPrefs.GetInt("MaxLevel"))
        {
            currentLevel++;
            SceneManager.LoadScene("Level" + currentLevel);
        }
        else
        {
            SceneManager.LoadScene("Main");
        }
    }
}
