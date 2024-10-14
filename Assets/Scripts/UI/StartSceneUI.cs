using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneUI : MonoBehaviour
{
    public Button StartButton;
    public GameObject TitlePanel;

    private void Start()
    {
        ShowTitlePanel();
    }

    private void ShowTitlePanel()
    {
        TitlePanel.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
