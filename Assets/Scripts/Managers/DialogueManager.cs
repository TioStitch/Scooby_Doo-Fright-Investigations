using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    
    [SerializeField] private TextMeshProUGUI dialogo;
    [SerializeField] private TextMeshProUGUI characterText;
    [SerializeField] private TextMeshProUGUI clickToNext;

    public bool hasDialogueBox = false;

    void Start() {
        clickToNext.SetText(TextControl.textControl.NextXStep());

        RectTransform dialogoBoxTransform = dialogo.GetComponent<RectTransform>();
        RectTransform clickToNextTransform = clickToNext.GetComponent<RectTransform>();
        RectTransform characterSelectorTransform = characterText.GetComponent<RectTransform>();
        configure(dialogoBoxTransform, clickToNextTransform, characterSelectorTransform);
    }

    private void configure(RectTransform dialogoTransform, RectTransform clickTransform, RectTransform characterTransform) {
        // Caixas de diálogo do jogo!
        // Caixa de diálogo.
        dialogo.fontSize = 18;
        dialogo.color = Color.white;

        float dialogAnchorY = 20.46f; // Porcentagem da altura da tela
        float clickAnchorY = 08.81f; // Porcentagem da altura da tela
        float characterAnchorY = 25.5f; // Porcentagem da altura da tela
        float marginMax = -37.19f; // Valor máximo da margem

        dialogoTransform.anchorMin = new Vector2(0.4f, dialogAnchorY / 100);
        dialogoTransform.anchorMax = new Vector2(0.4f, dialogAnchorY / 100);

        dialogo.margin = new Vector4(0, 0, -121.2f, 0);
        dialogo.wordSpacing = -7f;


        // Pressione 'X' para continuar!
        // Pressione para prosseguir.

        clickTransform.anchorMin = new Vector2(0.4f, clickAnchorY / 100);
        clickTransform.anchorMax = new Vector2(0.4f, clickAnchorY / 100);

        clickToNext.margin = new Vector4(0, 0, marginMax, 0);
        clickToNext.color = Color.yellow;

        // Exemplo: Velma Dinkley
        // Nome de Seletor do Personagem.
        
        characterTransform.anchorMin = new Vector2(0.4f, characterAnchorY / 100);
        characterTransform.anchorMax = new Vector2(0.4f, characterAnchorY / 100);

        characterText.margin = new Vector4(0, 0, marginMax, 0);
        characterText.color = Color.yellow;
    }

    public void startDialogueBox(DialogueTexts.Characters character, DialogueTexts.LevelSelector stage, int number) {
        clearDialogueBox();
        setDialogueBox(DialogueTexts.dialogueTexts.getDialogueBoxByID(character, stage, number, characterText));
        
        dialogo.gameObject.SetActive(true);
        characterText.gameObject.SetActive(true);
        clickToNext.gameObject.SetActive(true);
        hasDialogueBox = true;
    }

    public void clearDialogueBox() {
        dialogo.SetText("");
        hasDialogueBox = false;

        dialogo.gameObject.SetActive(false);
        characterText.gameObject.SetActive(false);
        clickToNext.gameObject.SetActive(false);
    }

    public void setDialogueBox(string text) {
        dialogo.SetText(text);
    }
}
