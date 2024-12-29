using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform avatar; // 아바타 Transform
    public Transform mainCamera; // 카메라 Transform

    private Vector3 initialAvatarPosition; // 초기 아바타 위치
    private Vector3 initialCameraPosition; // 초기 카메라 위치
    private float initialDistance; // 초기 아바타와 카메라 간 거리
    private Vector3 initialRatio; // 초기 비율 (Avatar와 Camera 위치의 비율)

    void Start()
    {
        if (avatar == null || mainCamera == null)
        {
            Debug.LogError("Avatar 또는 Main Camera를 설정하세요.");
            return;
        }

        // 초기 위치 및 거리 저장
        initialAvatarPosition = avatar.position;
        initialCameraPosition = mainCamera.position;
        initialDistance = Vector3.Distance(initialCameraPosition, initialAvatarPosition);

        // 초기 비율 계산
        initialRatio = (avatar.position - mainCamera.position) / initialDistance;
    }

    void Update()
    {
        if (avatar != null && mainCamera != null)
        {
            // 현재 카메라 위치 기준으로 아바타 위치 업데이트
            float currentDistance = Vector3.Distance(mainCamera.position, avatar.position);

            // 새로운 아바타 위치 계산 (초기 비율 유지)
            avatar.position = mainCamera.position + initialRatio * currentDistance;
        }
    }

    public void ResetToInitialRatio()
    {
        if (avatar != null && mainCamera != null)
        {
            // 초기 거리와 비율을 사용하여 아바타 위치 재조정
            avatar.position = mainCamera.position + initialRatio * initialDistance;
        }
    }
}
