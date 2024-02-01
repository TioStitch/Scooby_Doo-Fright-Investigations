using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenScript : MonoBehaviour {

    [SerializeField] private Slider loadingBar;
    [SerializeField] private RawImage background;
    [SerializeField] private RawImage toPlayNext;

    private string lastScene;
    private string nextScene;

    // Start is called before the first frame update

    void Awake() {
        lastScene = PlayerPrefs.GetString("LastScene");
        nextScene = PlayerPrefs.GetString("NextScene");
    }

    void Start() {
        System.Random random = new System.Random();
        background.texture = Resources.Load<Texture2D>("Wallpapers/Wallpaper-" + random.Next(1, 14));
    }

    // Update is called once per frame
    void Update() {
        if (loadingBar.value == 100) {

            if (Input.GetKeyDown(KeyCode.X)) {
                SceneManager.LoadSceneAsync(nextScene);
            }

            toPlayNext.gameObject.SetActive(true);
            return;
        }

        if (loadingBar.value <= 99) {
            loadingBar.value += 1;
        }
    }
}
