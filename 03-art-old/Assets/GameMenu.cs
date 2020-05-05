using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {
    [SerializeField] int firstLevelIndex = 1;
    [SerializeField] int gameOverIndex = 2;

    public void LoadScene(int index) {
        SceneManager.LoadScene(index);
    }

    public void Play() {
        LoadScene(firstLevelIndex);
    }

    public void Quit() {
        Application.Quit();
    }
}
