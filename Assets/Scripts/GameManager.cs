using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.SetInt("MaxLevel", 2);
        if (!PlayerPrefs.HasKey("IQ"))
        {
            PlayerPrefs.SetInt("IQ",0);
        }
        if (!PlayerPrefs.HasKey("CurrentLevel"))
        {
            PlayerPrefs.SetInt("CurrentLevel", 1);
        }
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("IQ: " + PlayerPrefs.GetInt("IQ"));
    }
}
