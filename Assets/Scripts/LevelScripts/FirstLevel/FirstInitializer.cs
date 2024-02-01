using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstInitializer : MonoBehaviour {

    [SerializeField] private ScreenBuilder sB;
    [SerializeField] private TextMeshProUGUI sandwich;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private DialogueManager dialogueManager;

    public static int collectedSandwichs = 0;
    private int fredDialogue = 1;

    void Start() {
        sB.Initializer(ScreenBuilder.Character.FRED);
        dialogueManager.startDialogueBox(DialogueTexts.Characters.FRED, DialogueTexts.LevelSelector.FIRST, 1);
    }

    public void addSandwich(int i) {
        collectedSandwichs += i;
    }

    void Update() {
        sandwich.SetText("" + collectedSandwichs);

        bool clickedX = Input.GetKeyDown(KeyCode.X);

        if (fredDialogue == 5) {
            if (collectedSandwichs != 14) {
                return;
            }
            dialogueManager.startDialogueBox(DialogueTexts.Characters.FRED, DialogueTexts.LevelSelector.FIRST, (fredDialogue-1));

            if (clickedX) {
                PlayerPrefs.SetString("NextScene", "GameMenu");
                PlayerPrefs.SetString("LastScene", "FirstStage");
                SceneManager.LoadSceneAsync("LoadingScreen");
            }
            return;
        }

        
        if (!dialogueManager.hasDialogueBox) {
            return;
        }

        //Caso aperte X.
        //Contudo tenha caixas de diálogo.
        //Caso o diálogo do Fred seja menor que o último.
        //----------------------->
        if (clickedX) {
            dialogueManager.startDialogueBox(DialogueTexts.Characters.FRED, DialogueTexts.LevelSelector.FIRST, fredDialogue);
            fredDialogue += 1;
            if (fredDialogue == 5) {
                dialogueManager.clearDialogueBox();
            }
        }
    }
}
