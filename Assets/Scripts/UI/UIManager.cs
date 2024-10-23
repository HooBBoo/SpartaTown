using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject GameScenePanel;
    public GameObject SetupPanel;

    public Button PlayerSetupButton;
    public Button DoneButton;
    public Button[] CharacterButtons;

    public GameObject player;
    public Animator playerAnimator;
    public RuntimeAnimatorController[] characterAnimators;

    private void Start()
    {
        //ShowStartScenePanel();
        ShowSetupPanel();

        // ��ư�� Ŭ���ϸ�, �г��� ����������!
        PlayerSetupButton.onClick.AddListener(ShowSetupPanel);
        DoneButton.onClick.AddListener(ShowStartScenePanel);

        if (player != null)
        {
            playerAnimator = player.GetComponent<Animator>();
        }

        CharacterButtons[0].onClick.AddListener(SelectCharacter1);
        CharacterButtons[1].onClick.AddListener(SelectCharacter2);
        CharacterButtons[2].onClick.AddListener(SelectCharacter3);
    }

    //��ŸƮ���� ��ư ���̰� �ϰ�, ĳ���� ���� �г��� ����
    public void ShowStartScenePanel()
    {
        GameScenePanel.SetActive(true);
        SetupPanel.SetActive(false);
    }

    // ĳ���� ���� �г��� ���̰��ϰ�, ��ŸƮ���� ��ư�� ����
    public void ShowSetupPanel()
    {
        GameScenePanel.SetActive(false);
        SetupPanel.SetActive(true);
    }
   
    public void ChangeCharacter(int characterIndex)
    {
        playerAnimator.runtimeAnimatorController = characterAnimators[characterIndex]; // ������ �ִϸ����� �ҷ�����
        PlayerDataManager.Instance.SetSelectedCharacter(characterAnimators[characterIndex]);
    }

    public void SelectCharacter1()
    {
        ChangeCharacter(0); // ù ��° ĳ���� ����
    }

    public void SelectCharacter2()
    {
        ChangeCharacter(1); // �� ��° ĳ���� ����
    }

    public void SelectCharacter3()
    {
        ChangeCharacter(2); // �� ��° ĳ���� ����
    }
}
