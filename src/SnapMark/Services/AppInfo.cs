using System.Diagnostics;
using System.Reflection;

namespace SnapMark.Services;

/// <summary>Thông tin app / người làm. Sửa các hằng số bên dưới cho đúng thông tin thật của bạn.</summary>
public static class AppInfo
{
    public const string AppName = "SnapMark";

    // ── TODO: thay bằng thông tin thật ──
    public const string Author = "Tokisaki Nino";
    public const string WebsiteUrl = "https://example.com/snapmark";
    public const string DonateUrl = "https://example.com/donate";

    public static string Version => Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.0.0";

    /// <summary>Tiêu đề cửa sổ: tên app + phiên bản.</summary>
    public static string TitleWithVersion => $"{AppName} v{Version}";

    /// <summary>Mở URL http/https bằng trình duyệt mặc định. Trả về false nếu không mở được.</summary>
    public static bool OpenUrl(string url)
    {
        try
        {
            if (!Uri.TryCreate(url, UriKind.Absolute, out var uri) || (uri.Scheme != Uri.UriSchemeHttps && uri.Scheme != Uri.UriSchemeHttp))
                return false;
            Process.Start(new ProcessStartInfo(uri.AbsoluteUri) { UseShellExecute = true });
            return true;
        }
        catch { return false; }
    }
}
