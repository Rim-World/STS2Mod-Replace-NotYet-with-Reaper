# OUTPUT 索引

本目录只做本地留存，除 `output.md` 外全部被 `.gitignore` 忽略（`10.OUTPUT/*`），不入库。

## 01-构建产物

| 时间 | 名称 | 版本号 | 大小 | 说明 |
|---|---|---|---|---|
| 2026-08-06 | ReaperReplacementMod v1（支持ritsulib，打包后mod）/ | 0.1.0 | 1.15 MB | 首版打包 mod：`ReaperReplacementMod.dll` 616960 B / `.pck` 515780 B / `.pdb` 16984 B / `.json` 520 B；清单描述含「可选集成 RitsuLib 设置页」 |
| 2026-08-07 | ReaperReplacementMod v2（修改本地化键，打包后mod）/ | 0.2.0 | 1.14 MB | 本地化键改为模组专属 `RE_REAPER.*` 后的打包 mod：dll 609792 B / pck 515812 B / pdb 14864 B / json 456 B（清单已去掉 RitsuLib 描述） |
| 2026-08-08 | ReaperReplacementMod v3（剔除冗余资源同时兼容两个版本，打包后mod）/ | 1.0 | 1.40 MB | 剔除冗余资源 + 107/110 兼容；dll 610304 B / pck 778356 B / pdb 15028 B / json 454 B（pck 时间 2026-08-09 03:54）。清单已直接写 1.0，故 0.2.1／0.2.2 的清单原件未留存 |
| 2026-08-09 | ReaperReplacementMod 正式版 v1.0/ | 1.0 | 1.40 MB | 与 v3 目录字节一致（dll/pck/pdb/json 同大小），即发布用安装件 |

## 02-发布包

| 时间 | 名称 | 版本号 | 大小 | 说明 |
|---|---|---|---|---|
| 2026-08-09 | ReaperReplacementMod v1.0.zip | 1.0 | 1.39 MB | 上传用安装包（解压到 `mods/ReaperReplacementMod/`） |
| 2026-08-09 | ReaperReplacementModSourceCode.zip | 1.0 | 4.22 MB | 上传用源码包 |

> Release 资产现状：GitHub 上 `v1.0` 已存在（2026-08-09 发布），本次整理**未新建 Release**。
> 游戏内安装目录 `C:/Game/Steam/steamapps/common/Slay the Spire 2/mods/ReaperReplacementMod/` 为 2026-08-29 重建（含未推送的升级数值改动），与本目录中 2026-08-09 的 v1.0 产物不同。
