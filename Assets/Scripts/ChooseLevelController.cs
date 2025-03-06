using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLevelController : MonoBehaviour
{
    public int LevelId = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartLevel()
    {
        LeanTween.scale(gameObject, Vector3.one * 1.2f, 0.2f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
        {
            LeanTween.scale(gameObject, Vector3.one, 0.2f).setEase(LeanTweenType.easeInBounce).setOnComplete(() =>
            {
                PlayerPrefs.SetInt("CurrentLevel", LevelId);
                PlayerPrefs.Save();
                SceneManager.LoadScene("Level" + LevelId);
            });
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
