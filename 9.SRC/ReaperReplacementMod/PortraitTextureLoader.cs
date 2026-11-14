using System;
using System.IO;
using System.Reflection;
using Godot;
using MegaCrit.Sts2.Core.Logging;

namespace ReaperReplacementMod;

/// <summary>
/// 加载死亡收割卡图。优先从模组 pck 读取；若失败则回退到 DLL 内嵌的 PNG 资源。
/// </summary>
public static class PortraitTextureLoader
{
    private static readonly object Sync = new();
    private static Texture2D? _texture;
    private static bool _loadFailed;

    public static Texture2D Get()
    {
        lock (Sync)
        {
            // 两路都失败时只尝试一次，避免卡面刷新反复重试并刷日志（与 1.0 的行为一致）。
            if (_loadFailed)
            {
                return null!;
            }

            // 纹理可能已被游戏释放：113 的检视卡会通过 BigPortrait 把模组 PNG 登记为
            // missed cache asset，房间切换时由 AssetCache 统一释放。
            if (_texture != null && GodotObject.IsInstanceValid(_texture))
            {
                return _texture;
            }

            _texture = null;

            try
            {
                // Ignore 让纹理不进入 Godot 资源缓存，也不与游戏的 AssetCache 共享所有权。
                // 否则 AssetCache 释放纹理后，本类仍会返回同一个已释放对象。
                _texture = ResourceLoader.Load<Texture2D>(
                    ModEntry.PortraitPng,
                    null,
                    ResourceLoader.CacheMode.Ignore);

                if (_texture != null)
                {
                    return _texture;
                }

                Log.Warn($"{ModEntry.ModId}: pck portrait not loadable, falling back to embedded texture");
            }
            catch (Exception e)
            {
                Log.Warn($"{ModEntry.ModId}: pck portrait load error: {e.Message}");
            }

            try
            {
                using Stream? stream = Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream("ReaperReplacementMod.assets.reaper_big.png");
                if (stream != null)
                {
                    using var ms = new MemoryStream();
                    stream.CopyTo(ms);
                    var image = new Image();
                    if (image.LoadPngFromBuffer(ms.ToArray()) == Error.Ok)
                    {
                        _texture = ImageTexture.CreateFromImage(image);
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error($"{ModEntry.ModId}: embedded portrait fallback failed: {e}");
            }

            if (_texture == null)
            {
                _loadFailed = true;
            }

            return _texture!;
        }
    }
}
