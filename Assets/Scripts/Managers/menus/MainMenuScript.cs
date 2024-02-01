using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuScript : MonoBehaviour {

    [SerializeField] private List<TextMeshProUGUI> registeredUIs;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private RawImage langPng;
    [SerializeField] private TextMeshProUGUI selectUI;

    [SerializeField] private GameObject configObject;
    [SerializeField] private GameObject playGameObject;

    private Vector2 playVector = new Vector2(0.275f, 0.2334084f);
    private Vector2 configVector = new Vector2(0.275f, 0.11838f);
    private Vector2 exitVector = new Vector2(0.275f, 0.0f);

    private int atualOption = 0;

    void Start() {
        TextControl.textControl.CheckUpdate();

        string language = TextControl.textControl.language;
        
        registeredUIs[0].text = TextControl.textControl.playText();
        registeredUIs[1].text = TextControl.textControl.configText();
        registeredUIs[2].text = TextControl.textControl.exitText();

        langPng.texture = Resources.Load<Texture2D>("Setting/mainMenu/country/" + language);
        audioSource.volume = PlayerPrefs.GetFloat("SoundGame");

        activatedUI(0);
        selectArrow(0);
    }

    public void languageChange() {
        if (configObject.activeInHierarchy) {
            return;
        }

        string language = TextControl.textControl.language;


        if (language.Equals("EUA")) {
            PlayerPrefs.SetString("Language", "PT_BR");
            registeredUIs[3].text = "PT_BR";
            registeredUIs[3].color = Color.green;
            language = "PT_BR";
        } else if (language.Equals("PT_BR")) {
            PlayerPrefs.SetString("Language", "EUA");
            registeredUIs[3].text = "EUA";
            registeredUIs[3].color = Color.blue;
            language = "EUA";
        }

        langPng.texture = Resources.Load<Texture2D>("Setting/mainMenu/country/" + language);
    }

    void Update() {
        if (configObject.activeInHierarchy) {
            return;
        }

        registeredUIs[0].text = TextControl.textControl.playText();
        registeredUIs[1].text = TextControl.textControl.configText();
        registeredUIs[2].text = TextControl.textControl.exitText();

        bool isUp = Input.GetKeyDown(KeyCode.UpArrow);
        bool isDown = Input.GetKeyDown(KeyCode.DownArrow);
        bool isSpace = Input.GetKey(KeyCode.Space);

        if (isSpace) {
            switch (atualOption) {
                case 0:
                    playGameObject.SetActive(true);
                break;
                case 1:
                    configObject.SetActive(true);
                break;
                case 2:
                    Application.Quit(0);
                break;
            }
        }

        if (isUp) {
            UpLogic();
            return;
        }

        if (isDown) {
            DownLogic();
            return;
        }
    }

    private void UpLogic() {
        switch (atualOption) {
            case 0:
                activatedUI(2);
                selectArrow(2);
            break;
            case 1:
                activatedUI(0);
                selectArrow(0);
            break;
            case 2:
                activatedUI(1);
                selectArrow(1);
            break;
        }
    }
    
    private void DownLogic() {
        switch (atualOption) {
            case 0:
                activatedUI(1);
                selectArrow(1);
            break;
            case 1:
                activatedUI(2);
                selectArrow(2);
            break;
            case 2:
                activatedUI(0);
                selectArrow(0);
            break;
        }
    }

    private void selectArrow(int select) {
        Vector2 vetor = new Vector2(0f,0f);
        switch (select) {
            case 0:
                vetor = playVector;
            break;
            case 1:
                vetor = configVector;
            break;
            case 2:
                vetor = exitVector;
            break;
        }
        selectUI.rectTransform.anchoredPosition = vetor;
        selectUI.rectTransform.anchorMin = vetor;
        selectUI.rectTransform.anchorMax = vetor;
    }

    private void activatedUI(int select) {
        for (int i = 0; i <= 2; i++) {
            registeredUIs[i].color = Color.white;
        }
        registeredUIs[select].color = Color.yellow;
        atualOption = select;
    }
}
