using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfigMenuScript : MonoBehaviour {

    [SerializeField] private List<TextMeshProUGUI> buttonText;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Slider slider;
    /* 0 -> Configuração Texto. */
    /* 1 -> Gráfico Atual. */
    /* 2 -> Resolução Atual. */
    /* 3 -> Gráfico em Texto. */
    /* 4 -> Resolução em Texto. */
    /* 5 -> Gráfico Leve em Texto. */
    /* 6 -> Gráfico Médio em Texto. */
    /* 7 -> Gráfico Bonito em Texto. */

    
    public void ChangeLanguage() {
        TextControl.textControl.CheckUpdate();
        buttonText[0].SetText(TextControl.textControl.configAbbreviateText());
        buttonText[3].text = TextControl.textControl.graphicsText();
        buttonText[4].text = TextControl.textControl.resolutionText();
    
        buttonText[5].text = TextControl.textControl.lowGraphicText();
        buttonText[6].text = TextControl.textControl.mediumGraphicText();
        buttonText[7].text = TextControl.textControl.beaultifulGraphicText();
    }

    public void ChangeVolume() {
        audioSource.volume = slider.value;
        PlayerPrefs.SetFloat("SoundGame", slider.value);
    }

    /*
    /* Tratamento de Gráficos
    /* Leve -> Médio -> Bonito
    */
    public void lowGraphic() {
        QualitySettings.SetQualityLevel(0);
        buttonText[1].text = TextControl.textControl.lowGraphicText();
    }

    public void mediumGraphic() {
        QualitySettings.SetQualityLevel(1);
        buttonText[1].text = TextControl.textControl.mediumGraphicText();
    }

    public void beaultifulGraphic() {
        QualitySettings.SetQualityLevel(2);
        buttonText[1].text = TextControl.textControl.beaultifulGraphicText();
    }

    /*
    /* Tratamento de Resolução Gráfica
    /* 10% -> 50% -> 100%
    */
    public void lowResolution() {
        QualitySettings.globalTextureMipmapLimit = 3;
        Screen.SetResolution(1280, 720, false);
        buttonText[2].text = "10%";
    }

    public void mediumResolution() {
        QualitySettings.globalTextureMipmapLimit = 2;
        Screen.SetResolution(1280, 720, true);
        buttonText[2].text = "50%";
    }

    public void highResolution() {
        QualitySettings.globalTextureMipmapLimit = 0;
        Screen.SetResolution(1920, 1080, true);
        buttonText[2].text = "100%";
    }

    public void exit() {
        gameObject.SetActive(false);
    }
}
