using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject buttonPlay;
    public GameObject menu;
    public GameObject chooseLevel;

    public void Play()
    {
        LeanTween.scale(buttonPlay, Vector3.one * 1.2f, 0.2f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
        {
            LeanTween.scale(buttonPlay, Vector3.one, 0.2f).setEase(LeanTweenType.easeInBounce).setOnComplete(()=>
            {
                menu.SetActive(false);
                chooseLevel.SetActive(true);
            });
        });
    }
}

