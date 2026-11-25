using System.Text.Json;
using NinoMark.Models;
namespace NinoMark.Services;
public static class SettingsService
{
    // NINOMARK_DATA_DIR: thư mục dữ liệu riêng (dùng khi chạy thử/test để không đụng vào cài đặt thật).
    public static string DataFolder => Folder;

    private static readonly string Folder = ResolveFolder();
    private static readonly string FilePath = Path.Combine(Folder, "settings.json");

    private static string ResolveFolder()
    {
        if (Environment.GetEnvironmentVariable("NINOMARK_DATA_DIR") is { Length: > 0 } custom) return custom;

        var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var folder = Path.Combine(appData, "NinoMark");
        try
        {
            // App từng tên QuickShot, rồi SnapMark: lần chạy đầu với tên mới thì chuyển cài đặt cũ sang để không mất.
            var newFile = Path.Combine(folder, "settings.json");
            if (!File.Exists(newFile))
            {
                foreach (var oldName in new[] { "SnapMark", "QuickShot" })
                {
                    var oldFile = Path.Combine(appData, oldName, "settings.json");
                    if (!File.Exists(oldFile)) continue;
                    Directory.CreateDirectory(folder);
                    File.Copy(oldFile, newFile);
                    break;
                }
            }
        }
        catch { /* không chuyển được thì dùng cài đặt mặc định */ }
        return folder;
    }

    public static AppSettings Load()
    {
        try { if (File.Exists(FilePath)) return JsonSerializer.Deserialize<AppSettings>(File.ReadAllText(FilePath)) ?? new(); }
        catch { }
        return new();
    }
    /// <summary>Xuất cài đặt ra file JSON do người dùng chọn.</summary>
    public static void Export(AppSettings settings, string path) =>
        File.WriteAllText(path, JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true }));

    /// <summary>Đọc cài đặt từ file JSON; trả null nếu file không hợp lệ.</summary>
    public static AppSettings? Import(string path)
    {
        try { return JsonSerializer.Deserialize<AppSettings>(File.ReadAllText(path)); }
        catch { return null; }
    }

    public static void Save(AppSettings settings)
    {
        Directory.CreateDirectory(Folder);
        File.WriteAllText(FilePath, JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true }));
    }
}
