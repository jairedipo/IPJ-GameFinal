using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeInName : MonoBehaviour
{
    Image image;
    Text[] textos;

    void Start()
    {
        image = GetComponent<Image>();
        textos = GetComponentsInChildren<Text>();

        image.DOFade(1, 5);
        foreach (Text texto in textos)
        {
            texto.DOFade(1, 5);
        }
   }
}
