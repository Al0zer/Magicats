using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public bool boughtHealth = false;
    public bool boughtAttack = false;

    public int healthCost = 1;
    public int attackCost = 1;

    public TextMeshProUGUI starsText;
    public TextMeshProUGUI healthCostText;
    public TextMeshProUGUI attackCostText;

    public Button healthButton;
    public Button attackButton;

    public Sprite tooPoor;
    public Sprite bought;

    public GameObject healthPanel;
    public GameObject attackPanel;
    public GameObject hasHealthIMG;
    public GameObject hasAttackIMG;

    public float waitTime = 1f;
    public Animator musicAnim;

    private int currentStars;

    // Start is called before the first frame update
    void Start()
    {
        currentStars = PlayerPrefs.GetInt("Stars");
        healthCostText.text = "x " + healthCost.ToString();
        attackCostText.text = "x " + attackCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        starsText.text = "x " + (PlayerPrefs.GetInt("Stars")).ToString();

        //player does not have enough stars to buy
        if (PlayerPrefs.GetInt("Stars") < healthCost)
        {
            healthButton.GetComponent<Image>().sprite = tooPoor;
            healthButton.interactable = false;
        }

        if (PlayerPrefs.GetInt("Stars") < attackCost)
        {
            attackButton.GetComponent<Image>().sprite = tooPoor;
            attackButton.interactable = false;
        }

        //if boughtHealth/boughtAttack = true, basically if player already has the thing
        if (PlayerPrefs.GetInt("BoughtHealth") != 0)
        {
            healthButton.GetComponent<Image>().sprite = bought;
            healthButton.interactable = false;

            healthPanel.SetActive(false);
            hasHealthIMG.SetActive(true);
        }

        if (PlayerPrefs.GetInt("BoughtAttack") != 0)
        {
            attackButton.GetComponent<Image>().sprite = bought;
            attackButton.interactable = false;

            attackPanel.SetActive(false);
            hasAttackIMG.SetActive(true);
        }
    }

    public void BuyHealth()
    {
        boughtHealth = true;
        PlayerPrefs.SetInt("BoughtHealth", (boughtHealth ? 1 : 0));

        currentStars -= healthCost;
        PlayerPrefs.SetInt("Stars", currentStars);
    }

    public void BuyAttack()
    {
        boughtAttack = true;
        PlayerPrefs.SetInt("BoughtAttack", (boughtAttack ? 1 : 0));

        currentStars -= attackCost;
        PlayerPrefs.SetInt("Stars", currentStars);
    }

    public void BackToMenu()
    {
        StartCoroutine(ChangeScene(0));
    }

    IEnumerator ChangeScene(int sceneIndex)
    {
        musicAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
