using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
    private static GameManager instance = null;
    private static GameObject playerCharacter; // ������ Player ����

    public GameObject Character1;
    public GameObject Character2;
    public GameObject Character3;
   

    public Text nameTag;

    private void Awake()
    {
        // Singleton ���� ����: �ν��Ͻ��� �̹� �����ϸ� ���� �������� �ʰ� ����
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // GameManager ������Ʈ�� �� ��ȯ �� ����
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        if (playerCharacter == null)
        {
            LoadPlayerData();
            DontDestroyOnLoad(playerCharacter);
        }
        else  //  �̹� �����ϸ�
        {
            string playerName = PlayerPrefs.GetString("PlayerName", "Player"); // ����� �̸� �ҷ�����
            UpdateNameTag(playerName);
        }
    }

    // ����� ������ �ε��ϱ�
    public void LoadPlayerData()
    {
        // ����� ĳ���� ���� �ҷ�����
        int selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 1); // �⺻���� 1
        string playerName = PlayerPrefs.GetString("PlayerName", "Player"); // �⺻���� 'Player'

        InstantiatePlayer();
        SpawnCharacter(selectedCharacter);
        UpdateNameTag(playerName);
    }

    // Player ������Ʈ �ν��Ͻ�ȭ
    private void InstantiatePlayer()
    {
        if (playerCharacter == null)
        {
            playerCharacter = Instantiate(PlayerPrefab, new Vector3(0, 0, 0), Quaternion.identity);

            // Player �ؿ� �ִ� ĳ���� ���� ����
            Character1 = playerCharacter.transform.Find("Character1").gameObject;
            Character2 = playerCharacter.transform.Find("Character2").gameObject;
            Character3 = playerCharacter.transform.Find("Character3").gameObject;
        }
    }

    private void SpawnCharacter(int selectedCharacter)
    {
        Character1.SetActive(selectedCharacter == 1);
        Character2.SetActive(selectedCharacter == 2);
        Character3.SetActive(selectedCharacter == 3);
    }

    // �̸� �±� ������Ʈ
    private void UpdateNameTag(string playerName)
    {
        if (nameTag != null)
        {
            nameTag.text = playerName;
            PlayerPrefs.SetString("PlayerName", playerName); // �̸��� �����ؼ� ���� ��ȯ�� ���� �����ǰ� ��
            PlayerPrefs.Save();
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
