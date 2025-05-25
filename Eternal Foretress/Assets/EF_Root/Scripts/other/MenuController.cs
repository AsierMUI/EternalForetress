using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel;

    void Update()
    {
        if (menuPanel.activeSelf)
        {
            Time.timeScale = 0; 
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
