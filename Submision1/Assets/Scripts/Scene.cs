using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public LoadSceneMode loadMode = LoadSceneMode.Single;

    // pindah scene ke menu
    public void MenuScene()
    {
        SceneManager.LoadScene("MenuScene", loadMode);
    }

    // pindah scene kellading
    public void LoadingScene()
    {
        SceneManager.LoadScene("LoadingScene", loadMode);
    }

    // keluar dari game
    public void KeluarScene()
    {
        Application.Quit();
    }

    // pindah scene kellading
    public void GamePlayScene()
    {
        SceneManager.LoadScene("Gameplay", loadMode);
    }

}
