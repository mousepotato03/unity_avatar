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

    // Reference to the standard avatar
    [Header("Standard Avatar Reference")]
    [Tooltip("현재 mixamo 3D model의 체형 정보를 우리가 사용하는 cm 단위로 기준을 잡아둔 객체.")]
    public StandardAvatar standardAvatar;

    private void Awake()
    {
        standardAvatar ??= new StandardAvatar();
    }

    public float CalculateScaleFactor(float inputValue, float standardValue)
    {
        if (standardValue == 0) return 1.0f; 
        return inputValue / standardValue;
    }

    //public void changeHeight
}
