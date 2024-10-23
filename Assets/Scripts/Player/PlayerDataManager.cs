using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager Instance;

    public RuntimeAnimatorController selectedCharacter;


    // 선택된 캐릭터 애니메이터를 저장
    public void SetSelectedCharacter(RuntimeAnimatorController animator)
    {
        selectedCharacter = animator;
    }

    // 선택된 캐릭터 애니메이터 가져오기
    public RuntimeAnimatorController GetSelectedCharacter()
    {
        return selectedCharacter;
    }

}