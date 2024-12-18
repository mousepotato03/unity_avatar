using UnityEngine;

[ExecuteAlways]
public class AvatarEditor : MonoBehaviour
{
    [Header("Body Transforms")]
    [Tooltip("키 조절할 때 사용함.")]
    public Transform hips;
    [Tooltip("상체 총장 조절할 때 사용함. 단, 허리 위로 모든 부분이 조절됨.")]
    public Transform spine;
    public Transform leftShoulder, rightShoulder;
    public Transform leftArm, leftForeArm, rightArm, rightForeArm;
    public Transform leftUpLeg, leftLeg, rightUpLeg, rightLeg;
    public Transform leftFoot, rightFoot;

    [Header("Body Adjustment")]
    public float height;
    public float weight;

    [Header("Upper Body Info")]
    public float upperBodyHeight;
    public float shoulderWidth;
    public float chestWidth;
    public float armLength;

    [Header("Lower Body Info")]
    public float lowerBodyHeight;
    public float waistWidth;
    public float hipWidth;

    [Header("Foot Info")]
    public int shoesSize;

    private float CalculateScaleFactor(float inputValue, float standardValue)
    {
        return standardValue == 0 ? 1.0f : inputValue / standardValue;
    }

    public void ModifyAvatar()
    {
        try
        {
            // Scale factors
            float heightScaleFactor = CalculateScaleFactor(height, AvatarModel.DefaultHeight);
            float weightScaleFactor = CalculateScaleFactor(weight, AvatarModel.DefaultWeight);
            float upperBodyScaleFactor = CalculateScaleFactor(upperBodyHeight, AvatarModel.DefaultUpperBodyHeight);
            float shoulderWidthScaleFactor = CalculateScaleFactor(shoulderWidth, AvatarModel.DefaultShoulderWidth);
            float armLengthScaleFactor = CalculateScaleFactor(armLength, AvatarModel.DefaultArmLength);
            float lowerBodyScaleFactor = CalculateScaleFactor(lowerBodyHeight, AvatarModel.DefaultLowerBodyHeight);
            float footScaleFactor = CalculateScaleFactor(shoesSize, AvatarModel.DefaultShoesSize);

            float BIGMAC = 1.0f; //살 
            BMICategory bmiCategory = BMIHelper.CalculateBMI(height, weight);
            switch (bmiCategory)
            {
                case BMICategory.OverWeight:
                    BIGMAC = 1.3f;
                    Debug.Log("BMI Category: OverWeight");
                    break;
                case BMICategory.UnderWeight:
                    BIGMAC = 0.7f;
                    Debug.Log("BMI Category: UnderWeight");
                    break;
                case BMICategory.Normal:
                    Debug.Log("BMI Category: Normal");
                    break;
                case BMICategory.Invalid:
                    Debug.Log("BMI Category: Invalid");
                    break;
            }
            Debug.Log($"MY BIGMAC Value : {BIGMAC}");

            // Spine adjustment
            spine.localScale = new Vector3(1, upperBodyScaleFactor, BIGMAC);

            // Shoulders adjustment
            leftShoulder.localPosition = new Vector3(
                -Mathf.Abs(leftShoulder.localPosition.x) * shoulderWidthScaleFactor,
                leftShoulder.localPosition.y,
                leftShoulder.localPosition.z
            );
            rightShoulder.localPosition = new Vector3(
                Mathf.Abs(rightShoulder.localPosition.x) * shoulderWidthScaleFactor,
                rightShoulder.localPosition.y,
                rightShoulder.localPosition.z
            );

            // Arms adjustment
            leftArm.localScale = new Vector3(1, armLengthScaleFactor, BIGMAC);
            rightArm.localScale = new Vector3(1, armLengthScaleFactor, BIGMAC);
            leftForeArm.localScale = new Vector3(1, armLengthScaleFactor, BIGMAC);
            rightForeArm.localScale = new Vector3(1, armLengthScaleFactor, BIGMAC);

            // Legs adjustment
            leftUpLeg.localScale = new Vector3(1, lowerBodyScaleFactor, BIGMAC);
            rightUpLeg.localScale = new Vector3(1, lowerBodyScaleFactor, BIGMAC);
            leftLeg.localScale = new Vector3(1, lowerBodyScaleFactor, BIGMAC);
            rightLeg.localScale = new Vector3(1, lowerBodyScaleFactor, BIGMAC);

            // Feet adjustment
            leftFoot.localScale = new Vector3(1, footScaleFactor, 1);
            rightFoot.localScale = new Vector3(1, footScaleFactor, 1);
        }
        catch (System.NullReferenceException ex)
        {
            Debug.LogWarning($"NullReferenceException in {nameof(ModifyAvatar)}: {ex.Message}");
        }
    }
}
