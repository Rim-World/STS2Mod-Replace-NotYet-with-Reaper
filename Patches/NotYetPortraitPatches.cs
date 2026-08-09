using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;

namespace ReaperReplacementMod.Patches;

/// <summary>
/// 把 NotYet 的卡图三个来源全部替换为模组内 STS1 死亡收割卡图。
/// </summary>
[HarmonyPatch(typeof(CardModel), "PortraitPngPath", MethodType.Getter)]
public static class NotYetPortraitPngPathPatch
{
    private static bool Prefix(CardModel __instance, ref string __result)
    {
        if (__instance is not NotYet || !ModConfig.IsReplaceNotYetEnabled)
        {
            return true;
        }

        __result = ModEntry.PortraitPng;
        return false;
    }
}

[HarmonyPatch(typeof(CardModel), "Portrait", MethodType.Getter)]
public static class NotYetPortraitPatch
{
    private static bool Prefix(CardModel __instance, ref Texture2D __result)
    {
        if (__instance is not NotYet || !ModConfig.IsReplaceNotYetEnabled)
        {
            return true;
        }

        __result = PortraitTextureLoader.Get();
        return false;
    }
}

[HarmonyPatch(typeof(CardModel), "PortraitPath", MethodType.Getter)]
public static class NotYetPortraitPathPatch
{
    private static bool Prefix(CardModel __instance, ref string __result)
    {
        if (__instance is not NotYet || !ModConfig.IsReplaceNotYetEnabled)
        {
            return true;
        }

        __result = ModEntry.PortraitPng;
        return false;
    }
}
