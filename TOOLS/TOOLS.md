# TOOLS 索引

本目录当前**无自写脚本或随项目安装的工具**（`TOOLS/` 下只有本索引与 `scripts/` 空目录）。

构建脚本 `build.ps1` 属于 mod 工程的一部分，按「源码保持工程内部相对结构」的要求留在 `9.SRC/ReaperReplacementMod/build.ps1`，未移入本目录。

## 构建所依赖的外部工具（未随项目分发）

| 时间 | 工具/脚本 | 用途 | 版本 | 大小 | 来源 | 安装方式/依赖 |
|---|---|---|---|---|---|---|
| — | .NET SDK | 编译 C# 程序集（`net9.0`，`Godot.NET.Sdk/4.5.1`） | 未记录（由 `ReaperReplacementMod.csproj` 的 TargetFramework 推断需支持 net9.0） | 未记录 | 微软官方 | 系统级安装；`build.ps1` 调用 `dotnet build` |
| — | Godot Engine（mono） | 导入资源并导出 pck（`--headless --import` / `--export-pack "Windows Desktop"`） | 4.5.1 stable mono（`project.godot` 的 `config/features` 与脚本路径一致） | 未记录 | Godot 官方 | 免安装版，脚本内硬编码路径 `C:\Godot&GDRE\Godot_v4.5.1-stable_mono_win64\…_console.exe` |
| — | PowerShell | 执行 `build.ps1` | 未记录 | 未记录 | 系统自带 | 直接运行 |

> 版本号/大小以本机实际安装为准；本表只登记代码与脚本中确有引用的事实，未实测的项目标为「未记录」。
