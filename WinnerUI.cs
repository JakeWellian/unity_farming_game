using TMPro;
using UnityEngine;

public class WinnerUI : MonoBehaviour
{
    public TMP_Text winText;

    void Start()
    {
        int days = PlayerPrefs.GetInt("FinalDays");

        winText.text = "You completed the game in: " + days + " Days!";
    }
}
