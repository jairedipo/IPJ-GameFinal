using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Sprite[] Digits;
    public GameObject DigitPrefab;
    float savedTime;

    public static int cristais;
    int oldCristais;

    void Start()
    {
        cristais = 90;
        BuildDigits(cristais);
        oldCristais = cristais;
        savedTime = Time.time;
    }

    void Update()
    {
        if(Time.time - savedTime > 1 && TempoDePartida.start)
        {
            cristais += 10;
            savedTime = Time.time;
        }

        if (oldCristais != cristais)
        {
            int childCount = transform.childCount;
            for (int i = 0; i < childCount; i++)
                Destroy(transform.GetChild(i).gameObject);

            BuildDigits(cristais);
            oldCristais = cristais;
        }
    }

    void BuildDigits(int number)
    {
        string numberString = number.ToString();

        float offsetX = 0;
        foreach(char digit in numberString)
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
