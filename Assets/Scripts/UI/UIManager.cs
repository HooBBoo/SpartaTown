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

        // 버튼을 클릭하면, 패널이 보여지도록!
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

    //스타트씬의 버튼 보이게 하고, 캐릭터 선택 패널은 숨김
    public void ShowStartScenePanel()
    {
        GameScenePanel.SetActive(true);
        SetupPanel.SetActive(false);
    }

    // 캐릭터 선택 패널을 보이게하고, 스타트씬의 버튼은 숨김
    public void ShowSetupPanel()
    {
        GameScenePanel.SetActive(false);
        SetupPanel.SetActive(true);
    }
   
    public void ChangeCharacter(int characterIndex)
    {
        playerAnimator.runtimeAnimatorController = characterAnimators[characterIndex]; // 선택한 애니메이터 불러오기
        PlayerDataManager.Instance.SetSelectedCharacter(characterAnimators[characterIndex]);
    }

    public void SelectCharacter1()
    {
        ChangeCharacter(0); // 첫 번째 캐릭터 선택
    }

    public void SelectCharacter2()
    {
        ChangeCharacter(1); // 두 번째 캐릭터 선택
    }

    public void SelectCharacter3()
    {
        ChangeCharacter(2); // 세 번째 캐릭터 선택
    }
}
