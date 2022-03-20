using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    public TextMeshProUGUI starsText;
    public int collectedStars; //stars collected from current run (will reset every run)
    public int totalStars; //total stars in player inventory (gets saved)

    void Awake()
    {
        totalStars = PlayerPrefs.GetInt("Stars");
    }

    public void AddStars(int amount)
    {
        collectedStars += amount;
        totalStars += amount;
        starsText.text = (collectedStars).ToString();

        PlayerPrefs.SetInt("Stars", totalStars);
    }

}
