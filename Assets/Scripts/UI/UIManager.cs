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

        // ��ư�� Ŭ���ϸ�, �г��� ����������!
        PlayerSetupButton.onClick.AddListener(ShowSetupPanel);
        DoneButton.onClick.AddListener(ShowStartScenePanel);   
    }

    // ��ŸƮ���� ��ư ���̰� �ϰ�, ĳ���� ���� �г��� ����
    public void ShowStartScenePanel()
    {
        StartScenePanel.SetActive(true);
        SetupPanel.SetActive(false);
    }

    // ĳ���� ���� �г��� ���̰��ϰ�, ��ŸƮ���� ��ư�� ����
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
