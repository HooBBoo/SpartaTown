using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerDataManager : MonoBehaviour
{
    public GameObject Character1;
    public GameObject Character2;
    public GameObject Character3;

    public Button Character1Btn;
    public Button Character2Btn;
    public Button Character3Btn;

    public GameObject PlayerPrefab;

    private void Start()
    {    
        Character1Btn.onClick.AddListener(Character1BtnClick);
        Character2Btn.onClick.AddListener(Character2BtnClick);
        Character3Btn.onClick.AddListener(Character3BtnClick);

        // 이전에 저장된 데이터 로드
        LoadPlayerData();
    }

    // 캐릭터1 선택
    public void Character1BtnClick()
    {
        PlayerPrefs.SetInt("SelectedCharacter", 1); // 캐릭터1
        SetActiveCharacter(1);
    }

    // 캐릭터2 선택
    public void Character2BtnClick()
    {
        PlayerPrefs.SetInt("SelectedCharacter", 2); // 캐릭터2
        SetActiveCharacter(2);
    }

    // 캐릭터3 선택
    public void Character3BtnClick()
    {
        PlayerPrefs.SetInt("SelectedCharacter", 3); // 캐릭터3
        SetActiveCharacter(3);
    }


    // 저장된 데이터 로드하기
    public void LoadPlayerData()
    {
        int selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 1); // 기본값은 캐릭터1

        SetActiveCharacter(selectedCharacter); // 저장된 캐릭터 활성화 시키기
    }

    // 선택된 캐릭터 활성화 하기
    public void SetActiveCharacter(int characterNumber)
    {
        Character1.SetActive(characterNumber == 1);
        Character2.SetActive(characterNumber == 2);
        Character3.SetActive(characterNumber == 3);
    }
}


//  처음에 했던 거

//public class PlayerDataManager : MonoBehaviour
//{
//    public GameObject PlayerPrefab;
//    public Vector2 spawnPosition = new Vector2(0, 0);

//    public GameObject Character1;
//    public GameObject Character2;
//    public GameObject Character3;

//    public Button Character1Btn;
//    public Button Character2Btn;
//    public Button Character3Btn;
//    public void Start()
//    {
//        Character1Btn.onClick.AddListener(Character1BtnClick);
//        Character2Btn.onClick.AddListener(Character2BtnClick);
//        Character3Btn.onClick.AddListener(Character3BtnClick);

//    }

//    public void SpawnPlayer()
//    {
//        GameObject Player = Instantiate(PlayerPrefab, spawnPosition, Quaternion.identity);
//    }


//public void Character1BtnClick()
//    {
//        Character1.SetActive(true);
//        Character2.SetActive(false);
//        Character3.SetActive(false);
//    }
//    public void Character2BtnClick()
//    {
//        Character1.SetActive(false);
//        Character2.SetActive(true);
//        Character3.SetActive(false);
//    }
//    public void Character3BtnClick()
//    {
//        Character1.SetActive(false);
//        Character2.SetActive(false);
//        Character3.SetActive(true);
//    }
//}