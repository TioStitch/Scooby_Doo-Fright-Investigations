using UnityEngine;

public class TextControl : MonoBehaviour {

    public string language = "EUA";
    public static TextControl textControl = new TextControl();

    public void CheckUpdate() {

        if (PlayerPrefs.GetString("Language") == null
        || !PlayerPrefs.HasKey("Language")) {
            PlayerPrefs.SetString("Language", "EUA");
            language = "EUA";
        }

        language = PlayerPrefs.GetString("Language");
    }

    public string playText() {
        return language.Equals("EUA") ? "Start game" : "Iniciar jogo";
    }

    public string configText() {
        return language.Equals("EUA") ? "Settings" : "Configurações";
    }

    public string configAbbreviateText() {
        return language.Equals("EUA") ? "Config." : "Config.";
    }

    public string exitText() {
        return language.Equals("EUA") ? "Exit game" : "Sair do jogo";
    }

    public string lowGraphicText() {
        return language.Equals("EUA") ? "Low" : "Leve";
    }

    public string mediumGraphicText() {
        return language.Equals("EUA") ? "Medium" : "Médio";
    }

    public string beaultifulGraphicText() {
        return language.Equals("EUA") ? "Beaultiful" : "Bonito";
    }

    public string graphicsText() {
        return language.Equals("EUA") ? "Graphics" : "Gráficos";
    }

    public string resolutionText() {
        return language.Equals("EUA") ? "Resolution" : "Resolução";
    }

    public string chapterOneText() {
        return language.Equals("EUA") ? "Chap1. Haunted Library" : "Cap1. Biblioteca Assombrada";
    }


    /*
    /* Isto é apenas para o tutorial, será
    /* removida depois do temporariamente.
    */
    public string gameTestText() {
        return language.Equals("EUA") ? "Game Text" : "Teste de Jogo";
    }
    public string testerText() {
        return language.Equals("EUA") ? "Test" : "Testar";
    }



    public string episodeOneText() {
        return language.Equals("EUA") ? "First Episode" : "Primeiro Ep.";
    }

    public string episodeTwoText() {
        return language.Equals("EUA") ? "Second Episode" : "Segundo Ep.";
    }

    public string episodeThirdText() {
        return language.Equals("EUA") ? "Third Episode" : "Terceiro Ep.";
    }

    public string NextXStep() {
        return language.Equals("EUA") ? "Press 'X' to continue!" : "Pressione 'X' para prosseguir!";
    }
}
