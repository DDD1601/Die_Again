using System;
using System.Collections;
using TMPro;
using Unity.Cinemachine;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseLevelController : MonoBehaviour
{
    public TextMeshProUGUI iqText;
    public TextMeshProUGUI levelText;
    public GameObject buttonRetry;
    public GameObject buttonSkip;
    public GameObject player;
    public void Show()
    {
        StartCoroutine(ShowLoseLevel());
    }

    private IEnumerator ShowLoseLevel()
    {
        levelText.gameObject.SetActive(false);
        iqText.gameObject.SetActive(false);
        buttonRetry.gameObject.SetActive(false);
        buttonSkip.gameObject.SetActive(false);
        levelText.text = "Level " + PlayerPrefs.GetInt("CurrentLevel");
        var cine = GameObject.Find("CinemachineCamera").GetComponent<CinemachineCamera>();
        cine.Follow = player.transform;
        var cineFollow = cine.GetComponent<CinemachineFollow>();
        cineFollow.FollowOffset = new Vector3(0, 4f, -12.5f);
        yield return new WaitForSeconds(1.5f);
        levelText.gameObject.SetActive(true);
        iqText.gameObject.SetActive(true);
        buttonRetry.gameObject.SetActive(true);
        buttonSkip.gameObject.SetActive(true);
        iqText.text = "IQ " + PlayerPrefs.GetInt("IQ");
    }




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Retry()
    {
        LeanTween.scale(buttonRetry, Vector3.one * 1.2f, 0.2f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
        {
            LeanTween.scale(buttonRetry, Vector3.one, 0.2f).setEase(LeanTweenType.easeInBounce).setOnComplete(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            });
        });
    }

    // Update is called once per frame
    public void SkipLevel()
    {
        LeanTween.scale(buttonSkip, Vector3.one * 1.2f, 0.2f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
        {
            LeanTween.scale(buttonSkip, Vector3.one, 0.2f).setEase(LeanTweenType.easeInBounce).setOnComplete(() =>
            {
                SceneManager.LoadScene("Main");
            });
        });
    }
}
