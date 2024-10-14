using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject StartScenePanel;
    public GameObject SetupPanel;

    public Button PlayerSetupButton;
    public Button DoneButton;
    public Button StartButton;


    private void Start()
    {
        //ShowStartScenePanel();
        ShowSetupPanel();

        // 버튼을 클릭하면, 패널이 보여지도록!
        PlayerSetupButton.onClick.AddListener(ShowSetupPanel);
        DoneButton.onClick.AddListener(ShowStartScenePanel);   
    }

    // 스타트씬의 버튼 보이게 하고, 캐릭터 선택 패널은 숨김
    public void ShowStartScenePanel()
    {
        StartScenePanel.SetActive(true);
        SetupPanel.SetActive(false);
    }

    // 캐릭터 선택 패널을 보이게하고, 스타트씬의 버튼은 숨김
    public void ShowSetupPanel()
    {
        StartScenePanel.SetActive(false);
        SetupPanel.SetActive(true);
    }

    //public void StartGame()
    //{
    //    SceneManager.LoadScene("GameScene");
    //}
}
