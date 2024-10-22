using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


// ����, ĳ���� �������� ��ɵ�

// ���⼭ Invoke �� �� �ֵ��� Event�� �޾Ƴ���
public class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent; //  Action�� ������ void�� ��ȯ, �ƴϸ� func
    public event Action<Vector2> OnLookEvent;  //  ���콺


    //  CallMoveEvent: �׵��� ��� �Ǿ��ִ� Move Event�� Invoke ���ִ� ��
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); //  ?, ������ ���� ������ ����
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
}
