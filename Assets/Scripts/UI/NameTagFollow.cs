using UnityEngine;

    //  NameTag가 캐릭터를 따라다니도록
    public class NameTagFollow : MonoBehaviour
    {
        // 이름표가 캐릭터의 머리 위에 표시되도록
        private Vector2 offset = new Vector2(0f, 1.2f);

        [SerializeField] private Transform target; // 따라갈 캐릭터의 Transform

        private void Update()
        {
            // NameTag의 위치를 캐릭터(target)의 위치 + offset으로 설정
            if (target != null)
            {
                Vector3 targetPosition = target.position + (Vector3)offset;
                transform.position = Camera.main.WorldToScreenPoint(targetPosition);
            }
        }
    }

