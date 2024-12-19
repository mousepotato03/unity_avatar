using System;

public abstract class BodyTypeInfo
{
    //상체 두께
    public abstract float ArmThickness { get; }
    public abstract float ForeArmThickness { get; }

    //하체 두께
    public abstract float UpLegThickness { get; }
    public abstract float LegThickness { get; }

    //하체 허벅지 너비 조절
    public abstract float UpLegWidth { get; }
    public abstract float LegWidth { get; }

    //발 두께, 너비비
    public float FootThickness => (float)Math.Pow(LegThickness, 2);
    public float FootWidth => (float)Math.Pow(1/LegWidth, 2);
}

public class OverWeightBody : BodyTypeInfo
{
    public override float ArmThickness => 1.44f;
    public override float ForeArmThickness => 1 / 1.2f;
    public override float UpLegThickness => 1.2f;
    public override float LegThickness => 1 / 1.2f;

    public override float UpLegWidth => 1.2f;

    public override float LegWidth => 1.2f;
}

public class NormalBody : BodyTypeInfo
{
    public override float ArmThickness => 1.0f;
    public override float ForeArmThickness => 1.0f;
    public override float UpLegThickness => 1.0f;
    public override float LegThickness => 1.0f;

    public override float UpLegWidth => 1.0f;

    public override float LegWidth => 1.0f;
}

public class UnderWeightBody : BodyTypeInfo
{
    public override float ArmThickness => 0.8f;
    public override float ForeArmThickness => 0.8f;
    public override float UpLegThickness => 0.9f;
    public override float LegThickness => 0.9f;

    public override float UpLegWidth => 0.8f;

    public override float LegWidth => 0.9f;
}

public static class BodyTypeInfoFactory
{
    public static BodyTypeInfo GetBodyTypeInfo(BMICategory category)
    {
        return category switch
        {
            BMICategory.OverWeight => new OverWeightBody(),
            BMICategory.Normal => new NormalBody(),
            BMICategory.UnderWeight => new UnderWeightBody(),
            _ => null
        };
    }
}
