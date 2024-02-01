using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenBuilder : MonoBehaviour {

    [SerializeField] List<RawImage> registeredImages;
    [SerializeField] List<TextMeshProUGUI> registeredTexts;

    public enum Character {FRED = 1, VELMA = 2, DAPHNE = 3, SHAGGY = 4, SCOOBY = 5};
    
    public void Initializer(Character character) {
        registeredImages[0].texture = Resources.Load<Texture2D>("setting/PlayerBanner");
        registeredImages[1].texture = Resources.Load<Texture2D>("setting/" + Convert.ToInt32(character));
        registeredImages[2].texture = Resources.Load<Texture2D>("setting/Sandwich-icon");
        Configure();
    }

    private void Configure() {
        const float bannerX = 0.09135623f;
        const float bannerY = 0.8154852f;

        const float playerX = 0.09135623f;
        const float playerY = 0.8131086f;

        const float sandwichX = 0.182f;
        const float sandwichY = 0.8054852f;

        const float pontuationX = 0.35875f;
        const float pontuationY = 0.7927796f;

        //Banner em volta do personagem
        //Círculo verde de contorno:
        RectTransform bannerTransform = registeredImages[0].rectTransform;

        bannerTransform.anchoredPosition = new Vector2(bannerX, bannerY);

        bannerTransform.anchorMin = new Vector2(bannerX, bannerY);
        bannerTransform.anchorMax = new Vector2(bannerX, bannerY);

        //Logo do personagem
        //Mantém dentro do círculo verde:
        RectTransform playerTransform = registeredImages[1].rectTransform;

        playerTransform.anchoredPosition = new Vector2(playerX, playerY);

        playerTransform.anchorMin = new Vector2(playerX, playerY);
        playerTransform.anchorMax = new Vector2(playerX, playerY);
        playerTransform.localScale = new Vector3(0.6152186f, 0.6220964f, 1f);

        //Logo do Sanduiche
        //Ele fica quase grudado no contorno.
        RectTransform sandwichTransform = registeredImages[2].rectTransform;

        sandwichTransform.anchoredPosition = new Vector2(sandwichX, sandwichY);

        sandwichTransform.anchorMin = new Vector2(sandwichX, sandwichY);
        sandwichTransform.anchorMax = new Vector2(sandwichX, sandwichY);
        
        sandwichTransform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 25.25f));
        sandwichTransform.localScale = new Vector3(0.4852437f, 0.5182815f, 1f);

        //Sanduiche mensagem
        //Ele fica quase grudado no contorno.
        RectTransform sandwichCoinTransform = registeredTexts[0].rectTransform;

        sandwichCoinTransform.anchoredPosition = new Vector2(pontuationX, pontuationY);

        sandwichCoinTransform.anchorMin = new Vector2(pontuationX, pontuationY);
        sandwichCoinTransform.anchorMax = new Vector2(pontuationX, pontuationY);
    }
}
