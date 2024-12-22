using UnityEngine;
public enum BMICategory
{
    UnderWeight,
    Normal,
    OverWeight,
    Invalid
}

public static class BMIHelper
{
    public static BMICategory CalculateBMI(float height, float weight)
    {
        float heightInMeters = height / 100f;
        float bmi = weight / (heightInMeters * heightInMeters);
        return ClassifyBMI(bmi); // Enum 값을 문자열로 반환
    }

    private static BMICategory ClassifyBMI(float bmi)
    {
        if (bmi < 18.5f) return BMICategory.UnderWeight;
        if (bmi >= 18.5f && bmi < 23f) return BMICategory.Normal;
        if (bmi >= 23f) return BMICategory.OverWeight;
        return BMICategory.Invalid;
    }
}
