using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChapterMenuScript : MonoBehaviour {

    [SerializeField] private List<TextMeshProUGUI> buttonText;
    /* 0 -> Chapter One. */
    /* 1 -> First Episode. */
    /* 2 -> Second Episode */
    /* 3 -> Third Episode. */
    /* 4 -> Tutorial Text. */
    /* 5 -> Tester Text. */

    
    public void ChangeLanguage() {
        TextControl.textControl.CheckUpdate();
        buttonText[0].text = TextControl.textControl.chapterOneText();

        buttonText[1].text = TextControl.textControl.episodeOneText();
        buttonText[2].text = TextControl.textControl.episodeTwoText();
        buttonText[3].text = TextControl.textControl.episodeThirdText();
        
        buttonText[4].text = TextControl.textControl.gameTestText();
        buttonText[5].text = TextControl.textControl.testerText();
    }

    public void playTest() {
        PlayerPrefs.SetString("NextScene", "FirstStage");
        PlayerPrefs.SetString("LastScene", "GameMenu");
        SceneManager.LoadSceneAsync("LoadingScreen");
    }

    public void exit() {
        gameObject.SetActive(false);
    }
}
