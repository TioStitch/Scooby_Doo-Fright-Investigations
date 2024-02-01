using TMPro;
using UnityEngine;

public class DialogueTexts : MonoBehaviour {

    public static DialogueTexts dialogueTexts = new DialogueTexts();
    bool isEnglish = PlayerPrefs.GetString("Language").Equals("EUA");
    public enum Characters {FRED,VELMA,SHAGGY,DAPHNE,SCOOBY};
    public enum LevelSelector {FIRST};

    void Awake() {
        dialogueTexts = this;
    }

    private string getCharacterByID(Characters characters) {
        switch (characters) {
            case Characters.FRED:
                return "Fred Jones";
            case Characters.VELMA:
                return "Velma Dinkley";
            case Characters.SHAGGY:
                return "Shaggy Roggers";
            case Characters.DAPHNE:
                return "Daphne";
            case Characters.SCOOBY:
                return "Scooby Roggers";
            default:
                return "";
        }
    }

    public string getDialogueBoxByID(Characters character, LevelSelector stage, int number, TextMeshProUGUI characterText) {
        characterText.SetText(getCharacterByID(character));

        switch (character) {
            case Characters.VELMA:
                switch (stage) {
                    //Velma - Primeira fase.
                    case LevelSelector.FIRST:
                        switch (number) {
                            case 1:
                                return "Resolveremos este desafio para aprender a jogar!";
                            case 2:
                                return "Você pode usar WASD para se movimentar.";
                            case 3:
                                return "Também pode usar 'Espaço' para pular.";
                        }
                    break;
                }
                break;

            case Characters.FRED:
                switch (stage) {
                    //Fred - Primeira fase.
                    case LevelSelector.FIRST:
                        switch (number) {
                            case 1:
                                return isEnglish ? "Use WADS to movement." : "Utilize WASD para se movimentar!";
                            case 2:
                                return isEnglish ? "Use 'Space' to jump!" : "Você pode usar a tecla 'Espaco' do seu teclado para poder pular!";
                            case 3:
                                return isEnglish ? "Now collect the sandwichs." : "Agora colete os sanduíches.";
                            case 4:
                                return isEnglish ? "You have completed the tutorial!" : "Você completou o tutorial!";
                        }
                    break;
                }
                break;
        }
        return "";
    }
}