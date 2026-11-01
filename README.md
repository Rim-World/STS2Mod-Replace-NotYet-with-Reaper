# 死亡收割（ReaperReplacementMod）

把《杀戮尖塔 2》铁甲战士技能牌「时候未到」（Not Yet）整卡替换为《杀戮尖塔 1》攻击牌「死亡收割」（Reaper）。

> Replaces the Slay the Spire 2 Ironclad skill "Not Yet" with the Slay the Spire 1 attack "Reaper" — name, art, text, card type, target and effect included.

## 功能

- 卡牌类型：技能 → 攻击；目标：自身 → 全体敌人。
- 核心变量：治疗 10（升级 13）→ 伤害 4（升级 +1，见「已知问题」）。
- 打出效果：对全体敌人造成伤害，并按**未被格挡的实际扣血**治疗自己（`UnblockedDamage` 求和）。
- 卡名、卡面文本、卡图（1000×760 大图 + 250×190 卡面）全部换成 STS1「死亡收割」。
- 15 语言：`deu / eng / esp / fra / ita / jpn / kor / pol / ptb / rus / spa / tha / tur / zhs / zht`，文本取自 STS1 本地正版资源并做格式转换。
- 直接在原卡上打补丁，不新增卡牌、不禁用原卡；费用 2、稀有度 Rare、`Exhaust` 关键词保持不变。

## 兼容性

- 游戏版本：`min_game_version = 0.107.1`；单一 DLL 同时适配 default 107 与 beta 110（运行时判定 `AttackCommand.FromCard` 的可用重载）。
- 依赖：无（`dependencies: []`）。`0Harmony` 与 `sts2` 仅在编译期引用，不随包分发。
- 与其它 mod：采用最小补丁面，正常情况与大多数 mod 兼容；不保证与盗版、修改版、移动版、老旧版本或冷门 mod 兼容。
- 存档影响：mod 开启时，历史记录中的「时候未到」显示为「死亡收割」；关闭后恢复原状。

## 安装

1. 从 [Releases](https://github.com/Rim-World/STS2Mod-Replace-NotYet-with-Reaper/releases) 下载 `ReaperReplacementMod v1.0.zip`。
2. 解压到游戏目录 `Slay the Spire 2/mods/ReaperReplacementMod/`（目录内应有 `.dll`、`.pck`、`.json` 三件）。
3. 启动游戏，在 mod 列表中启用「死亡收割 (Reaper)」。

## 构建

环境：.NET SDK（net9.0）、Godot 4.5.1 mono（`Godot_v4.5.1-stable_mono_win64`）、Windows。

```powershell
pwsh 9.SRC/ReaperReplacementMod/build.ps1
```

脚本依次执行：`dotnet build -c Debug` → Godot `--headless --import` → `--headless --export-pack "Windows Desktop"` → 拷贝 `ReaperReplacementMod.dll/.pdb/.json` 到 `mods/ReaperReplacementMod/`。脚本内的游戏目录与 Godot 路径为硬编码本机路径（`C:\Game\Steam\steamapps\common\Slay the Spire 2`、`C:\Godot&GDRE\…`），换机需改两行。

## 目录结构

```
STS2Mod-死割/
├── 1.ADR/           决策记录（ADR.md 索引）
├── 2.PLANS/         施工计划（PLANS.md 索引）
├── 3.DOCS/          知识与报告（DOCS.md 索引）
├── 4.SDD/           软件设计文档（SDD.md 索引）
├── 5.ChangeLog/     版本日志分片（ChangeLog.md 索引）
├── 9.SRC/           源码（ReaperReplacementMod/ 为 Godot C# 工程）
├── 10.OUTPUT/       构建产物与发布包（output.md 索引，内容不入库）
├── PRIVACY/         机密信息（当前无机密）
├── TMP/             临时与过程文件（TMP.md 索引，内容不入库）
├── TOOLS/           工具与自写脚本（TOOLS.md 索引）
├── description/     创意工坊/发布文案（中英文）
├── pics/            封面与素材图
├── AGENTS.md        仓库协作规范
├── CHANGELOG.md     Keep a Changelog 单文件日志
└── LICENSE           MIT（附游戏素材版权说明）
```

## 文档索引

- 决策：[ADR-001 新 mod 立项：Not Yet → Reaper](1.ADR/001-时候未到整卡替换为死亡收割.md)
- 计划：[Not Yet → Reaper 整卡替换](2.PLANS/001-G-时候未到整卡替换为死亡收割.md)
- 知识：[110→107 切换导致存档无法读取的根因](3.DOCS/001-T-110降至107切换导致存档损坏根因.md)、[死亡收割卡面文本翻译审批](3.DOCS/002-T-死亡收割卡面文本翻译审批.md)
- 设计：[总体设计](4.SDD/001-总体设计.md)
- 版本日志：[0.2.1 / 0.2.2 / 1.0](5.ChangeLog/001-1.0-2026-08-09.md)、[CHANGELOG.md](CHANGELOG.md)

## 版本

当前版本 **1.0**（`9.SRC/ReaperReplacementMod/ReaperReplacementMod.json`），对应 GitHub Release [`v1.0`](https://github.com/Rim-World/STS2Mod-Replace-NotYet-with-Reaper/releases/tag/v1.0)。

## 已知问题

- 升级伤害存在文档与源码不一致：源码为 `UpgradeValueBy(1m)`（4→5），ADR-001 与翻译审批文档记载为「升级 +2（4→6）」，待确认。
- 实机验证结论未记录（107/110、mod 开关组合）。
- 模组图标为 420×420 纯色占位（ADR-001）。

## 致谢

- 本 mod 使用 Codex（桌面版）+ DeepSeek V4 Flash（0731 正式版）完成，感谢梁圣。
- 感谢《杀戮尖塔 2》制作组为 mod 制作提供的便利。
- 感谢 BaseLib 制作者提供的文档，感谢 GitHub 项目 [@jiegec/STS2RevertAnthony](https://github.com/jiegec/STS2RevertAnthony) 提供的源码参考。

## 开源地址

https://github.com/Rim-World/STS2Mod-Replace-NotYet-with-Reaper

卡牌名称、卡图、文本等素材版权归 Mega Crit Games, LLC 所有，本项目为非商业同人 mod，详见 [LICENSE](LICENSE)。
