using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Button exitButton;
    public Button resetButton;
    public string menu;
    public string mapa;

    void Start()
    {
        
        exitButton.onClick.AddListener(() => ChangeScene(menu));
        resetButton.onClick.AddListener(() => ChangeScene(mapa));
    }

    void ChangeScene(string sceneName)
    {
        
        SceneManager.LoadScene(sceneName);
    }
}
