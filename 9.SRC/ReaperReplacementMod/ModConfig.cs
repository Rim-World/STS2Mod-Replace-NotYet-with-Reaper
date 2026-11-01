namespace ReaperReplacementMod;

/// <summary>
/// 替换功能固定开启。已移除 RitsuLib 实时开关，
/// 避免会话中途切换导致 DynamicVars/卡面状态不一致。
/// </summary>
public static class ModConfig
{
    public static bool IsReplaceNotYetEnabled => true;
}
