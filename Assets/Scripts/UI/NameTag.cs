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
        // ����� �̸��� �ִ��� Ȯ��
        string savedName = PlayerPrefs.GetString("PlayerName", "");

        if (string.IsNullOrEmpty(savedName))
        {
            // ����� �̸��� ������ ���ο� �̸� ������ ���� SavePlayerName ����
            nameInput.onEndEdit.AddListener(delegate { SavePlayerName(nameInput.text); });
        }
        else
        {
            // ����� �̸��� ������ ���� �̸� ������ ���� ChangePlayerName ����
            nameInput.onEndEdit.AddListener(delegate { ChangePlayerName(nameInput.text); });
        }

        // ������ ����� ������ �ε�
        LoadPlayerName();
    }

    // Update is called once per frame
    public void LoadPlayerName()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "");

        nameInput.text = playerName; // ����� �̸� InputField�� ǥ���ϱ�
        UpdateNameTag(playerName);
    }

    // �Էµ� �÷��̾� �̸� �����ϱ�
    public void SavePlayerName(string playerName)
    {
        PlayerPrefs.SetString("PlayerName", playerName); // �÷��̾� �̸� ����
        UpdateNameTag(playerName);
    }

    public void UpdateNameTag(string palyerName)
    {
        if (nameTag != null)
        {
            nameTag.text = palyerName;
        }
    }
    //  �̸� �����ϱ�
    public void ChangePlayerName(string newPlayerName)
    {
        // ���ο� �̸� ����
        PlayerPrefs.SetString("PlayerName", newPlayerName);

        // �̸�ǥ ������Ʈ
        UpdateNameTag(newPlayerName);
    }
}
