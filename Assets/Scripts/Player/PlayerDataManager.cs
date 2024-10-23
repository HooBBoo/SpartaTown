using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager Instance;

    public RuntimeAnimatorController selectedCharacter;


    // ���õ� ĳ���� �ִϸ����͸� ����
    public void SetSelectedCharacter(RuntimeAnimatorController animator)
    {
        selectedCharacter = animator;
    }

    // ���õ� ĳ���� �ִϸ����� ��������
    public RuntimeAnimatorController GetSelectedCharacter()
    {
        return selectedCharacter;
    }

}