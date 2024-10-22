using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController
{
    private Camera camera;
    private void Awake()
    {
        camera = Camera.main;  //  mainCamera태그가 붙어있는 카메라를 가져온다.
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
        // 실제 움직이는 처리는 여기서 하는 게 아니라 PlayerMovement에서 함
    }

    // 여기에서 전 처리 작업을 해주기 위해 위의 OnMove를 만들음
    // 마우스가 찍고 있는 위치를 카메라에 대해서 월드 죄표를 바꿔주는 것
    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(newAim);  //  카메라가 어딜 찍고있는지 알아야해서, 카메라를 기준으로. >> 월드좌표로 바꾸기 (카메라의 위치가 바뀌면 월드 죄표가 바뀔 수 있음)
        newAim = (worldPos - (Vector2)transform.position).normalized;  // 캐릭터에서 월드까지의 거리 transform >> worldPos = worldPos - transform (A에서B로 가는 벡터 = B - A)

        CallLookEvent(newAim);
    }
}

