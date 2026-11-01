using System.Collections.Generic;
using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.ValueProps;

namespace ReaperReplacementMod.Patches;

/// <summary>
/// NotYet 的核心属性替换：技能→攻击、目标自身→全体敌人、治疗变量→伤害变量。
/// CanonicalVars 是 NotYet 自己的 override，因此直接补丁 NotYet.CanonicalVars。
/// </summary>
[HarmonyPatch(typeof(CardModel), "Type", MethodType.Getter)]
public static class NotYetTypePatch
{
    private static void Postfix(CardModel __instance, ref CardType __result)
    {
        if (__instance is NotYet && ModConfig.IsReplaceNotYetEnabled)
        {
            __result = CardType.Attack;
        }
    }
}

[HarmonyPatch(typeof(CardModel), "TargetType", MethodType.Getter)]
public static class NotYetTargetTypePatch
{
    private static void Postfix(CardModel __instance, ref TargetType __result)
    {
        if (__instance is NotYet && ModConfig.IsReplaceNotYetEnabled)
        {
            __result = TargetType.AllEnemies;
        }
    }
}

[HarmonyPatch(typeof(NotYet), "CanonicalVars", MethodType.Getter)]
public static class NotYetCanonicalVarsPatch
{
    private static void Postfix(NotYet __instance, ref IEnumerable<DynamicVar> __result)
    {
        if (ModConfig.IsReplaceNotYetEnabled)
        {
            __result = new DynamicVar[] { new DamageVar(4m, ValueProp.Move) };
        }
    }
}
