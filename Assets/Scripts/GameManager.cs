using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Reel[] reels;

    public GameObject winPopup; // THIS LINE IS IMPORTANT

    public void SpinAll()
    {
        StartCoroutine(SpinRoutine());
    }

    IEnumerator SpinRoutine()
    {
        foreach (Reel reel in reels)
        {
            reel.StartSpin();
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(1.5f);

        CheckWin();
    }

    void CheckWin()
    {
        if (reels[0].resultIndex == reels[1].resultIndex &&
            reels[1].resultIndex == reels[2].resultIndex)
        {
            Debug.Log("YOU WIN!");
            winPopup.SetActive(true);
        }
        else
        {
            winPopup.SetActive(false);
        }
    }
}