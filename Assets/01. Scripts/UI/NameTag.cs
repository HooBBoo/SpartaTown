using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameTag : MonoBehaviour
{
    public InputField nameInput;
    public Text nameTag;

    // Start is called before the first frame update
    void Start()
    {
        // 저장된 이름이 있는지 확인
        string savedName = PlayerPrefs.GetString("PlayerName", "");

        if (string.IsNullOrEmpty(savedName))
        {
            // 저장된 이름이 없으면 새로운 이름 저장을 위해 SavePlayerName 연결
            nameInput.onEndEdit.AddListener(delegate { SavePlayerName(nameInput.text); });
        }
        else
        {
            // 저장된 이름이 있으면 기존 이름 변경을 위해 ChangePlayerName 연결
            nameInput.onEndEdit.AddListener(delegate { ChangePlayerName(nameInput.text); });
        }

        // 이전에 저장된 데이터 로드
        LoadPlayerName();
    }

    // Update is called once per frame
    public void LoadPlayerName()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "");

        nameInput.text = playerName; // 저장된 이름 InputField에 표시하기
        UpdateNameTag(playerName);
    }

    // 입력된 플레이어 이름 저장하기
    public void SavePlayerName(string playerName)
    {
        PlayerPrefs.SetString("PlayerName", playerName); // 플레이어 이름 저장
        UpdateNameTag(playerName);
    }

    public void UpdateNameTag(string palyerName)
    {
        if (nameTag != null)
        {
            nameTag.text = palyerName;
        }
    }
    //  이름 변경하기
    public void ChangePlayerName(string newPlayerName)
    {
        // 새로운 이름 저장
        PlayerPrefs.SetString("PlayerName", newPlayerName);

        // 이름표 업데이트
        UpdateNameTag(newPlayerName);
    }
}
