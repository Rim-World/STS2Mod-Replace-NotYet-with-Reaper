# TMP 索引

本目录存放临时与过程文件，除 `TMP.md` 外全部被 `.gitignore` 忽略（`TMP/*`），不入库。

| 时间 | 文件/目录 | 用途 | 格式 | 大小 | 来源 |
|---|---|---|---|---|---|
| 2026-11-01 | `02-缓存与临时/ReaperReplacementMod-.godot/` | 源码工程的 Godot 导入/构建缓存（`.godot/`，含 `imported/`、`mono/temp/bin/Debug/`、`uid_cache.bin` 等），构建时自动重建 | 目录（二进制/文本混合） | 2.87 MB | 原 `src/ReaperReplacementMod/.godot/`，整理时移出源码目录 |
| — | `01-旧Git仓库/` | 存放旧 `.git` 嵌套克隆 | 目录 | 空 | 合集内不存在旧克隆，本次未使用 |
| — | `03-运行日志/` | 存放运行/构建日志 | 目录 | 空 | 本次未产生日志 |
| 2026-11-01 | `04-历史版本源码/NotYetOnPlayPatch.remote-v1.0.cs` | 远端 `main` 上 `Patches/NotYetOnPlayPatch.cs` 的历史版本（升级 `UpgradeValueBy(2m)`，即 4→6），本地源码 2026-08-29 已改为 `(1m)`（4→5）；按「本地更新者胜出」保留本地版本，远端原文件内容在此留存备查 | C# 源码 | 3094 B | `git show 8afbed4:<origin/main 中的该文件>` |

## 分类说明

- `01-旧Git仓库/`：迁移前的 `.git` 目录一律 `mv` 到此，禁止删除。
- `02-缓存与临时/`：构建缓存、导入缓存、中间产物。
- `03-运行日志/`：游戏/构建过程日志。
- `04-历史版本源码/`：旧版本源码整包快照。

## 清理建议

- `02-缓存与临时/ReaperReplacementMod-.godot/` 可随时删除：重新执行 `9.SRC/ReaperReplacementMod/build.ps1` 会由 Godot 重新生成导入与编译中间文件，不影响源码与已有构建产物。
- 其余三个目录当前为空，无需清理。
