using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HarmonyLib;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Commands.Builders;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;

namespace ReaperReplacementMod.Patches;

/// <summary>
/// 原版 NotYet.OnPlay：治疗 10（升级 13）。
/// 替换为 Reaper：对全体敌人造成伤害，并按实际扣血（UnblockedDamage）治疗。
/// </summary>
[HarmonyPatch(typeof(NotYet), "OnPlay")]
public static class NotYetOnPlayPatch
{
    /// <summary>
    /// 110+：AttackCommand.FromCard(CardModel, CardPlay?)；107：FromCard(CardModel)。
    /// 两版其余构建器方法签名一致，因此只在这里按运行时实际存在的重载反射分派，
    /// 一个 DLL 即可同时适配 107/110，切版本无需重新构建。
    /// </summary>
    private static readonly MethodInfo? FromCardTwoArg =
        typeof(AttackCommand).GetMethod("FromCard", new[] { typeof(CardModel), typeof(CardPlay) });

    private static readonly MethodInfo? FromCardOneArg =
        typeof(AttackCommand).GetMethod("FromCard", new[] { typeof(CardModel) });

    private static bool Prefix(
        PlayerChoiceContext choiceContext,
        CardPlay cardPlay,
        NotYet __instance,
        ref Task __result)
    {
        if (!ModConfig.IsReplaceNotYetEnabled)
        {
            return true;
        }

        __result = ReaperOnPlay(choiceContext, cardPlay, __instance);
        return false;
    }

    private static async Task ReaperOnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay cardPlay,
        NotYet instance)
    {
        AttackCommand command = DamageCmd.Attack(instance.DynamicVars.Damage.BaseValue);
        command = SetCardSource(command, instance, cardPlay);

        var attack = await command
            .TargetingAllOpponents(instance.CombatState!)
            .WithHitFx("vfx/vfx_giant_horizontal_slash")
            .Execute(choiceContext);

        int heal = attack.Results.SelectMany(r => r).Sum(r => r.UnblockedDamage);
        if (heal > 0)
        {
            await CreatureCmd.Heal(instance.Owner.Creature, heal);
        }
    }

    private static AttackCommand SetCardSource(AttackCommand command, CardModel card, CardPlay cardPlay)
    {
        if (FromCardTwoArg != null)
        {
            return (AttackCommand)FromCardTwoArg.Invoke(command, new object[] { card, cardPlay })!;
        }

        return (AttackCommand)FromCardOneArg!.Invoke(command, new object[] { card })!;
    }
}

/// <summary>
/// 原版升级：Heal +3（10→13）；替换为伤害 +2（4→6）。
/// </summary>
[HarmonyPatch(typeof(NotYet), "OnUpgrade")]
public static class NotYetOnUpgradePatch
{
    private static bool Prefix(NotYet __instance)
    {
        if (!ModConfig.IsReplaceNotYetEnabled)
        {
            return true;
        }

        __instance.DynamicVars.Damage.UpgradeValueBy(2m);
        return false;
    }
}
