## ① 环境

本 mod 不依赖任何基础 mod。

本 mod 支持 default 107、public beta 111 与 public beta 113 版本，单份 DLL 自动适配。

## ② 15 种语言支持

亚洲：简体中文 / 繁体中文 / 日语 / 韩语 / 泰语 / 土耳其语

欧洲与美洲：英语 / 葡萄牙语（巴西）/ 西班牙语（拉美）/ 西班牙语 / 法语 / 俄语 / 德语 / 意大利语 / 波兰语

文本标签按首字母顺序，依次为 deu、eng、esp、fra、ita、jpn、kor、pol、ptb、rus、spa、tha、tur、zhs、zht。

文本均来自《杀戮尖塔 1》，仅作简单格式调整，可能有少量错误。

## ③ 效果

将游戏中的“时候未到”卡牌的效果、卡名、卡面图片、卡面文本更换为与《杀戮尖塔 1》中卡牌“死亡收割”相同。

本 mod 采用直接在“时候未到”原卡牌上进行修改的方法生效，并非生成新卡牌 + 禁用旧卡牌。

本 mod 影响存档：在 mod 开启时，所有历史记录中的“时候未到”卡牌都会被更换为“死亡收割”卡牌；关闭 mod 后会恢复原状。

## ④ 影响（基于本人游戏理解）

在原版游戏高进阶（a10）难度下，大多数对局中，对于铁甲战士职业，死亡收割仅比时候未到略强；对于其它职业，死亡收割略逊于时候未到。

在原版游戏低进阶（a0）难度下，大多数对局中，对于铁甲战士职业，死亡收割显著强于时候未到；对于其它职业，死亡收割略逊于时候未到。

## ⑤ 兼容性与 Bug

本 mod 采用最小依赖的方式写成，正常来说与大多数 mod 兼容，且不易随着版本变化而失效。但本 mod 不保证与盗版、修改版、移动版、老旧版本或者冷门 mod、次级 mod 的兼容性。

由于 api 版本更新，107 与 111/113 的 `AttackCommand.FromCard` 重载不同，本 mod 在运行时自动选择；三个版本效果相同。111 新增的 `ind`、113 新增的 `ara` 未覆盖，缺语言时回退英文。

## ⑥ 鸣谢

本 mod 使用 Codex（桌面版）+ DeepSeek V4 Flash（0731 正式版）完成，感谢梁圣。

感谢《杀戮尖塔 2》制作组为了方便玩家制作 mod 所做的努力。

感谢 Baselib 制作者提供的文档，感谢 GitHub 项目 @jiegec/STS2RevertAnthony 提供的源码参考。

## 1. Environment

This mod does not depend on any base mod.

This mod supports the Default 107, Public Beta 111, and Public Beta 113 versions with a single DLL.

## 2. 15 Languages Supported

Asia: Simplified Chinese / Traditional Chinese / Japanese / Korean / Thai / Turkish

Europe & the Americas: English / Portuguese (Brazil) / Spanish (Latin America) / Spanish / French / Russian / German / Italian / Polish

The text tags, in alphabetical order, are: deu, eng, esp, fra, ita, jpn, kor, pol, ptb, rus, spa, tha, tur, zhs, zht.

All texts are taken from Slay the Spire 1, with only simple formatting adjustments; there may be minor errors.

## 3. Effects

Replaces the effect, card name, card art, and card text of the game's "Not Yet" card with those of the "Reaper" card from Slay the Spire 1.

This mod works by modifying the original "Not Yet" card directly, rather than creating a new card and disabling the old one.

This mod affects save files: while the mod is enabled, all "Not Yet" cards in historical records will be replaced with "Reaper" cards; disabling the mod restores the original state.

## 4. Impact (Based on My Understanding of the Game)

At higher ascension (A10) in the vanilla game, in most runs, Reaper is only slightly stronger than Not Yet for the Ironclad; for other characters, Reaper is slightly weaker than Not Yet.

At lower ascension (A0) in the vanilla game, in most runs, Reaper is significantly stronger than Not Yet for the Ironclad; for other characters, Reaper is slightly weaker than Not Yet.

## 5. Compatibility & Bugs

This mod is written with minimal dependencies, so under normal circumstances it is compatible with most mods and unlikely to break as the game version changes. However, compatibility is not guaranteed with pirated copies, modified versions, mobile versions, outdated versions, niche mods, or secondary mods.

Due to API updates, the `AttackCommand.FromCard` overload differs between 107 and 111/113; the mod selects it at runtime. The effect is identical on all three versions. The `ind` language added in 111 and the `ara` language added in 113 are not covered; missing languages fall back to English.

## 6. Credits

This mod was made with Codex (desktop) + DeepSeek V4 Flash (0731 official release). Thanks to Saint Liang.

Thanks to the Slay the Spire 2 team for their efforts to make modding easier for players.

Thanks to the Baselib developers for their documentation, and to the GitHub project @jiegec/STS2RevertAnthony for the source code reference.
