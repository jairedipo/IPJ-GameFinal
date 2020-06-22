using UnityEngine;
using UnityEngine.UI;

public class ExibeCusto : MonoBehaviour
{
    public Sprite[] Digits;
    public GameObject DigitPrefab;
    public int valor;

    void Start()
    {
        BuildDigits(valor);
    }

    void BuildDigits(int number)
    {
        string numberString = number.ToString();

        float offsetX = 0;
        foreach (char digit in numberString)
        {
            int idx = digit - '0';
            GameObject curDigit = Instantiate<GameObject>(DigitPrefab, transform);
            curDigit.GetComponent<Image>().sprite = Digits[idx];
            curDigit.transform.localPosition = new Vector3(offsetX, 0, 0);
            float digitWidth = Digits[idx].rect.width;
            offsetX += digitWidth + 15;
        }
    }
}
