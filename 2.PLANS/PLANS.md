# PLANS 索引

| 编号 | 计划 | 层级 | 状态 | 时间 | 说明 |
|---|---|---|---|---|---|
| 001 | [Not Yet → Reaper 整卡替换](001-G-时候未到整卡替换为死亡收割.md) | G（整体） | v1.0 已构建安装并发布；实机验证结论未记录 | 2026-08-06 | 把塔2 铁甲战士技能牌「时候未到」（Not Yet）整卡替换为塔1「死亡收割」（Reaper）：技能→攻击、目标自身→全体敌人、治疗变量→伤害变量、AOE 伤害+按实际扣血吸血、升级加伤害、STS1 卡图与 15 语言文本；107/110 单 DLL 自适应 |

## 施工记录回填

| 时间 | 计划 | 实际施工内容 | 验收状态 |
|---|---|---|---|
| 2026-08-06 | 001-G | 创建 `9.SRC/ReaperReplacementMod/` 工程（ModEntry / ModConfig / 4 个补丁文件 / PortraitTextureLoader / csproj / manifest / project.godot / export_presets.cfg / build.ps1），15 语言本地化与卡图，构建安装 v0.1.0 | 静态验证通过；实机验证未记录 |
| 2026-08-07 | 001-G | 本地化键改为模组专属 `RE_REAPER.*`，重建安装 | 构建通过；实机验证未记录 |
| 2026-08-08 | 001-G | 107/110 跨版本修复：先按 `STS2_GE_110` 条件编译（v0.2.1），再改为运行时反射分派 `AttackCommand.FromCard` 重载（v0.2.2），单一 DLL 双版本通用 | 构建通过；107 实机结论未记录 |
| 2026-08-09 | 001-G | 剔除冗余资源、打包正式版 v1.0，产出 `ReaperReplacementMod v1.0.zip` 与 `ReaperReplacementModSourceCode.zip`，建立 GitHub Release `v1.0` | 已发布 |
| 2026-08-09 / 08-11 | 001-G | 源码与 README（中英）推送 GitHub（`95083b4` / `db877e0` / `b0eeee5` / `b6c5237`） | 已推送 |
| 2026-08-29 | 001-G | 未推送的本地修改：升级伤害 `UpgradeValueBy(2m)` → `(1m)`（4→5），重建安装到 `mods/ReaperReplacementMod/` | 构建通过；2026-11-01 用户拍板：升级伤害 +1（4→5），相关文档已同步 |
| 2026-11-01 | 001-G | 仓库整理为 AGENTS 十目录结构，补全 README/CHANGELOG/SDD/ChangeLog 等文档 | 文档整理完成，详见 `5.ChangeLog/001-1.0-2026-08-09.md` |

> 开工前必须检查本索引与对应计划文档，确认需求与前置条件后再动手。
