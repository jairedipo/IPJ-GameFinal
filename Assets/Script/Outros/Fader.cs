using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fader : MonoBehaviour
{
    Image image;

    void Start()
    {
        image = GetComponent<Image>();
        image.color = new Color(0, 0, 0, 1);
        image.enabled = true;

        image.DOFade(0, 0.5f)
            .OnComplete(() => { image.enabled = false; });
    }

    public void FadeToGame()
    {
        image.enabled = true;
        image.color = new Color(0, 0, 0, 0);

        image.DOFade(1, 0.5f);
    }
}
