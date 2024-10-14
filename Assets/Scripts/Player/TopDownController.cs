using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


// 몬스터, 캐릭터 공통적인 기능들

// 여기서 Invoke 할 수 있도록 Event를 달아놓음
public class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent; //  Action은 무조건 void만 반환, 아니면 func
    public event Action<Vector2> OnLookEvent;  //  마우스


    //  CallMoveEvent: 그동안 등록 되어있는 Move Event를 Invoke 해주는 것
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); //  ?, 없으면 말고 있으면 실행
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
}
