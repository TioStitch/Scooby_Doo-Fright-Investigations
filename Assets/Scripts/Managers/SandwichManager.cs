using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class SandwichManager : MonoBehaviour {

    private const string sandwichPrefix = "Sandwich";
    private int sandwich;

    void Awake() {
         sandwich = PlayerPrefs.GetInt("Sandwich");
    }

    /////  --------   Métodos principais.  --------   /////
    public int getSandwich() {
        return sandwich;
    }

    public void addSandwich(int amount) {
        PlayerPrefs.SetInt(sandwichPrefix, sandwich + amount);
        PlayerPrefs.Save();
    }

    public void removeSandwich(int amount) {
        PlayerPrefs.SetInt(sandwichPrefix, sandwich - amount);
        PlayerPrefs.Save();
    }

    public void setSandwichCoins(int amount) {
        PlayerPrefs.SetInt(sandwichPrefix, amount);
        PlayerPrefs.Save();
    }
}