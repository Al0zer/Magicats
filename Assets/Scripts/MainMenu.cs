using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private string[] cheatCode;
    private int index;

    public float waitTime = 1f;
    public Animator musicAnim;

    void Start()
    {
        cheatCode = new string[] { "d", "e", "l" };
        index = 0;
    }

    void Update()
    {
        // Check if any key is pressed
        if (Input.anyKeyDown)
        {
            // Check if the next key in the code is pressed
            if (Input.GetKeyDown(cheatCode[index]))
            {
                // Add 1 to index to check the next key in the code
                index++;
            }
            // Wrong key entered, we reset code typing
            else
            {
                index = 0;
            }
        }

        // If index reaches the length of the cheatCode string, 
        // the entire code was correctly entered
        if (index == cheatCode.Length)
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("player prefs deleted");
            index = 0;
        }
    }

    public void StartGame()
    {
        StartCoroutine(ChangeScene(1));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Shop()
    {
        StartCoroutine(ChangeScene(2));
    }

    IEnumerator ChangeScene(int sceneIndex)
    {
        musicAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
