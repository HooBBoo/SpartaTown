using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
    private static GameManager instance = null;
    private static GameObject playerCharacter; // 생성될 Player 옵젝

    public GameObject Character1;
    public GameObject Character2;
    public GameObject Character3;
   

    public Text nameTag;

    private void Awake()
    {
        // Singleton 패턴 적용: 인스턴스가 이미 존재하면 새로 생성하지 않고 제거
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // GameManager 오브젝트도 씬 전환 후 유지
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
        else  //  이미 존재하면
        {
            string playerName = PlayerPrefs.GetString("PlayerName", "Player"); // 저장된 이름 불러오기
            UpdateNameTag(playerName);
        }
    }

    // 저장된 데이터 로드하기
    public void LoadPlayerData()
    {
        // 저장된 캐릭터 정보 불러오기
        int selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 1); // 기본값은 1
        string playerName = PlayerPrefs.GetString("PlayerName", "Player"); // 기본값은 'Player'

        InstantiatePlayer();
        SpawnCharacter(selectedCharacter);
        UpdateNameTag(playerName);
    }

    // Player 오브젝트 인스턴스화
    private void InstantiatePlayer()
    {
        if (playerCharacter == null)
        {
            playerCharacter = Instantiate(PlayerPrefab, new Vector3(0, 0, 0), Quaternion.identity);

            // Player 밑에 있는 캐릭터 참조 설정
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

    // 이름 태그 업데이트
    private void UpdateNameTag(string playerName)
    {
        if (nameTag != null)
        {
            nameTag.text = playerName;
            PlayerPrefs.SetString("PlayerName", playerName); // 이름을 저장해서 씬이 전환될 때도 유지되게 함
            PlayerPrefs.Save();
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
