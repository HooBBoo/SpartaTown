using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class CameraFollow : MonoBehaviour
    {
        private Vector3 offset = new Vector3(0f, 0f, -10f);  // 카메라와 타겟과의 차이 -10만큼 뒤에 위치하도록 고정
        private float smoothTime = 0.25f;  //  카메라가 목표 위치에 도달하는 데 걸리는 시간(부드러운 움직임을 위해서), 값이 작을수록 빠르고 클수록 느림.
        private Vector3 velocity = Vector3.zero;

        // 카메라 타겟에 원래 Player를 넣었으나 뭔가 바꾸면서 따라가질 않아 일단 이렇게 해 보았습니다..
        [SerializeField] private Transform target1;
        [SerializeField] private Transform target2;
        [SerializeField] private Transform target3;

        private Transform currentTarget;
        private void Update()
        {
            // 활성화된 타겟을 찾아 currentTarget에 할당
            if (target1.gameObject.activeSelf)
            {
                currentTarget = target1;
            }
            else if (target2.gameObject.activeSelf)
            {
                currentTarget = target2;
            }
            else if (target3.gameObject.activeSelf)
            {
                currentTarget = target3;
            }

            // currentTarget이 존재하면 카메라가 따라가도록 함
            if (currentTarget != null)
            {
                Vector3 targetPosition = currentTarget.position + offset;
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            }
            //private void Update()
            //{
            //    Vector3 targetPosition1 = target1.position + offset;  //  거리유지를 위해 타겟의 위치에 고정된 offset값을 더함
            //    Vector3 targetPosition2 = target2.position + offset;
            //    Vector3 targetPosition3 = target3.position + offset;
            //    transform.position = Vector3.SmoothDamp(transform.position, targetPosition1, ref velocity, smoothTime); //  SmoothDamp가 부드러운 감속운동을 하게 함
            //    transform.position = Vector3.SmoothDamp(transform.position, targetPosition2, ref velocity, smoothTime);
            //    transform.position = Vector3.SmoothDamp(transform.position, targetPosition3, ref velocity, smoothTime);
            //    //  ref velocity: 참조로 넘겨진velocity 값으로 카메라 속도 관리
            //}
        }
    }
}
