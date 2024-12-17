using UnityEngine;

[ExecuteAlways]
public class AvatarEditor : MonoBehaviour
{
    // Mapping Avatar Body
    [Header("Body Transforms")]
    [Tooltip("키 조절할 때 사용함.")]
    public Transform hips;
    [Tooltip("상체 총장 조절할 때 사용함. 단, 허리 위로 모든 부분이 조절됨. ")]
    public Transform spine;
    public Transform leftShoulder, rightShoulder;
    public Transform leftArm, leftForeArm, rightArm, rightForeArm;
    public Transform leftUpLeg, leftLeg, rightUpLeg, rightLeg;
    public Transform leftFoot, rightFoot;

    // Base Info
    [Header("General Body Info")]
    [Tooltip("키 (cm)")]
    public float height;
    [Tooltip("체중 (kg)")]
    public float weight;

    // Upper Body
    [Header("Upper Body Info")]
    public float upperBodyHeight;
    public float shoulderWidth;
    public float chestHeight;
    public float armLength;

    // Lower Body
    [Header("Lower Body Info")]
    public float lowerBodyHeight;
    public float waistWidth;
    public float hipWidth;

    // Foot Info
    [Header("Foot Info")]
    public int shoesSize;

    private AvatarModel avatarModel;

    private void Awake()
    {
        avatarModel ??= new AvatarModel();
    }

    public float CalculateScaleFactor(float inputValue, float standardValue)
    {
        if (standardValue == 0) return 1.0f;
        return inputValue / standardValue;
    }

    // Modify Avatar Method
    public void modifyAvatar()
    {
        // 전체 높이 스케일 계산
        float heightScaleFactor = CalculateScaleFactor(height, avatarModel.height);

        // 상체 높이 스케일 계산
        float upperBodyScaleFactor = CalculateScaleFactor(upperBodyHeight, avatarModel.upperBodyHeight);

        // 팔 길이 스케일 계산
        float armLengthScaleFactor = CalculateScaleFactor(armLength, avatarModel.armLength);

        // 다리 길이 스케일 계산
        float lowerBodyScaleFactor = CalculateScaleFactor(lowerBodyHeight, avatarModel.lowerBodyHeight);

        // 발 사이즈 스케일 계산
        float footScaleFactor = CalculateScaleFactor(shoesSize, avatarModel.shoesSize);

        // 상체 스케일 조정
        if (spine != null)
        {
            spine.localScale = new Vector3(upperBodyScaleFactor, upperBodyScaleFactor, 1);
        }

        // 어깨 폭 조정
        if (leftShoulder != null && rightShoulder != null)
        {
            float shoulderWidthScaleFactor = CalculateScaleFactor(shoulderWidth, avatarModel.shoulderWidth);

            Vector3 leftShoulderPosition = leftShoulder.localPosition;
            Vector3 rightShoulderPosition = rightShoulder.localPosition;

            leftShoulderPosition.x = -Mathf.Abs(leftShoulderPosition.x) * shoulderWidthScaleFactor;
            rightShoulderPosition.x = Mathf.Abs(rightShoulderPosition.x) * shoulderWidthScaleFactor;

            leftShoulder.localPosition = leftShoulderPosition;
            rightShoulder.localPosition = rightShoulderPosition;
        }

        // 팔 길이 조정
        if (leftArm != null && rightArm != null && leftForeArm != null && rightForeArm != null)
        {
            leftArm.localScale = new Vector3(armLengthScaleFactor, armLengthScaleFactor, 1);
            rightArm.localScale = new Vector3(armLengthScaleFactor, armLengthScaleFactor, 1);
            leftForeArm.localScale = new Vector3(armLengthScaleFactor, armLengthScaleFactor, 1);
            rightForeArm.localScale = new Vector3(armLengthScaleFactor, armLengthScaleFactor, 1);
        }

        // 다리 길이 조정
        if (leftUpLeg != null && rightUpLeg != null && leftLeg != null && rightLeg != null)
        {
            leftUpLeg.localScale = new Vector3(lowerBodyScaleFactor, lowerBodyScaleFactor, 1);
            rightUpLeg.localScale = new Vector3(lowerBodyScaleFactor, lowerBodyScaleFactor, 1);
            leftLeg.localScale = new Vector3(lowerBodyScaleFactor, lowerBodyScaleFactor, 1);
            rightLeg.localScale = new Vector3(lowerBodyScaleFactor, lowerBodyScaleFactor, 1);
        }

        // 발 조정
        if (leftFoot != null && rightFoot != null)
        {
            leftFoot.localScale = new Vector3(footScaleFactor, footScaleFactor, 1);
            rightFoot.localScale = new Vector3(footScaleFactor, footScaleFactor, 1);
        }
    }
}
