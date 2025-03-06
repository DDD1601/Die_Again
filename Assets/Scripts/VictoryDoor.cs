using GogoGaga.TME;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryDoor : MonoBehaviour
{
    public LeantweenCustomAnimator leantweenCustomAnimator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            leantweenCustomAnimator.PlayAnimation();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GamePlayController.instance.Win();
        }
    }
}
