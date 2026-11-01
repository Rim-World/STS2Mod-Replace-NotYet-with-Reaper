# Changelog

本项目所有 notable 变更均记录于此，格式参考 [Keep a Changelog](https://keepachangelog.com/zh-CN/1.1.0/)，版本号遵循语义化版本。
分版本细节（七字段）见 `5.ChangeLog/001-1.0-2026-08-09.md`。

## 未发布

### 变更

- 2026-08-29：升级伤害由 `UpgradeValueBy(2m)`（4→6）改为 `UpgradeValueBy(1m)`（4→5），已本地构建安装到 `mods/ReaperReplacementMod/`；**未推送、未递增版本号**，且与 ADR-001／翻译审批文档记载不一致，待确认后并入正式版本。

### 仓库整理（2026-11-01）

- 按 AGENTS.md 十目录结构重组仓库（`1.ADR` / `2.PLANS` / `3.DOCS` / `4.SDD` / `5.ChangeLog` / `9.SRC` / `10.OUTPUT` / `PRIVACY` / `TMP` / `TOOLS` + `description` / `pics`）。
- 源码移入 `9.SRC/ReaperReplacementMod/`，`.godot/` 构建缓存移入 `TMP/02-缓存与临时/`；**未修改任何代码**。
- 新增 `README.md`、`CHANGELOG.md`、`.gitignore`、`4.SDD/001-总体设计.md` 等文档；恢复远端的 `LICENSE`、`.gitignore` 规则与 `README.md`。
- 未新建 Release：仓库已有 `v1.0`；整理提交编号：`000f3bb`（后续回填提交另计）。

## [1.0] - 2026-08-09

### 新增

- 正式版：`Not Yet`（时候未到）→ `Reaper`（死亡收割）整卡替换（类型、目标、变量、OnPlay、OnUpgrade、卡名/文本、卡图三来源）。
- 15 语言卡面文本（`RE_REAPER.title` / `RE_REAPER.description`）；STS1 卡图 1000×760 与 250×190；DLL 内嵌 PNG 兜底。
- 发布资产：`ReaperReplacementMod v1.0.zip`（安装包）与 `ReaperReplacementModSourceCode.zip`（源码包）；GitHub Release `v1.0`。

### 变更

- 剔除冗余资源后重新打包；manifest 定版 `version=1.0`、`min_game_version=0.107.1`、`dependencies=[]`。
- 移除 RitsuLib 实时开关，`ModConfig.IsReplaceNotYetEnabled` 固定 `true`（避免会话中途切换导致 `DynamicVars`／卡面状态不一致）。

### 修复

- 107 下打出「死亡收割」卡在结算区的问题：改用运行时反射分派 `AttackCommand.FromCard` 重载，单一 DLL 同时适配 107/110（见 0.2.2）。

### 已知问题

- 实机验证结论未记录（开/关、有无 RitsuLib 组合）。
- 模组图标仍为 420×420 纯色占位。

## [0.2.2] - 2026-08-08

### 变更

- 撤销条件编译与版本探测，改为运行时反射分派 `FromCard(CardModel, CardPlay)` / `FromCard(CardModel)`；单一 DLL 双版本通用，切版本无需重新构建。

### 已知问题

- 若未来版本移除单参 `FromCard` 重载，非空断言处会抛 `NullReferenceException`（源码无兜底）。

## [0.2.1] - 2026-08-08

### 修复

- 107 下打出卡牌卡在结算区：按 `release_info.json` 版本设置 `STS2_GE_110`，条件编译选择对应 `FromCard` 重载（`<0.110` 与 `≥0.110` 各一套）。

### 已知问题

- 每个游戏版本需各自构建一份，切版本必须重新构建。

## [0.1.0] - 2026-08-06

### 新增

- 首版：`src/ReaperReplacementMod/` 工程（`ModEntry`、`ModConfig`、核心属性/OnPlay/卡图/文本补丁、`PortraitTextureLoader`、csproj、manifest、`project.godot`、`export_presets.cfg`、`build.ps1`）。
- 15 语言本地化、卡图替换、RitsuLib「单卡替换」设置页（后续版本移除）。

[1.0]: https://github.com/Rim-World/STS2Mod-Replace-NotYet-with-Reaper/releases/tag/v1.0
