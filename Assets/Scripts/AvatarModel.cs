/// <summary>
/// 사이즈 코리아에서 제공하는 평균 사이즈를 기반으로 작성됨.
/// <see href="https://sizekorea.kr/human-meas-search/human-data-search/meas-item">
/// </summary>
public static class AvatarModel
{
    // Base Info
    public static readonly float DefaultHeight = 178.0f;
    public static readonly float DefaultWeight = 68.0f;

    // Upper Body
    public static readonly float DefaultUpperBodyHeight = 67.2f;
    public static readonly float DefaultShoulderWidth = 39.2f;
    public static readonly float DefaultArmLength = 58.6f;

    // Lower Body
    public static readonly float DefaultLowerBodyHeight = 100.9f;
    public static readonly float DefaultWaistWidth = 25.6f; 

    // Foot Info
    public static readonly int DefaultShoesSize = 270;

    // Model Bone Info
    public static readonly float DefaultLShoulderXpos = -0.072f;
    public static readonly float DefaultRShoulderXpos = 0.072f;
    public static readonly float DefaultLUpLegXpos = -0.08f;
    public static readonly float DefaultRUpLegXpos = 0.08f;
}
