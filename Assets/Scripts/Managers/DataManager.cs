using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {
    
    void Start() {
        if (!PlayerPrefs.HasKey("Graphics")) {
            //Informação de jogo.
            PlayerPrefs.SetInt("Sandwich", 0);
            PlayerPrefs.SetString("Language", "EUA");
            PlayerPrefs.SetString("LastScane", "GameMenu");

            //Configurações.
            PlayerPrefs.SetString("Graphics", "LOW");
            PlayerPrefs.SetFloat("Resolution", 1.0f);
            PlayerPrefs.SetFloat("SoundGame", 100.0f);
        }
        Screen.SetResolution(1920, 1080, true);
    }
}