using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reel : MonoBehaviour
{
    public List<Sprite> symbols;   // List of symbols
    public Image displayImage;     // UI image to show symbol

    public int resultIndex;        // Final result

    private bool isSpinning = false;

    public void StartSpin()
    {
        if (!isSpinning)
        {
            StartCoroutine(SpinAnimation());
        }
    }

    IEnumerator SpinAnimation()
    {
        isSpinning = true;

        float duration = 1.5f;
        float timer = 0f;

        while (timer < duration)
        {
            int randomIndex = Random.Range(0, symbols.Count);
            displayImage.sprite = symbols[randomIndex];

            yield return new WaitForSeconds(0.1f);
            timer += 0.1f;
        }

        // Final result
        resultIndex = Random.Range(0, symbols.Count);
        displayImage.sprite = symbols[resultIndex];

        isSpinning = false;
    }
}