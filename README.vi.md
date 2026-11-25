<p align="center">
  <img src="docs/images/logo.png" width="128" alt="NinoMark logo">
</p>

<h1 align="center">NinoMark</h1>

**Tiếng Việt** | [English](README.md)

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![CI](https://github.com/TokisakiNinoVn/NinoMark/actions/workflows/ci.yml/badge.svg)](https://github.com/TokisakiNinoVn/NinoMark/actions/workflows/ci.yml)
[![Release](https://img.shields.io/github/v/release/TokisakiNinoVn/NinoMark)](https://github.com/TokisakiNinoVn/NinoMark/releases/latest)
![Platform](https://img.shields.io/badge/platform-Windows%2010%2F11-blue)
![.NET](https://img.shields.io/badge/.NET-10-512BD4)

Ứng dụng chụp màn hình và chú thích nhanh cho Windows, viết bằng C# + WPF (.NET 10). Nhấn phím tắt, kéo chọn vùng, vẽ chú thích ngay trên vùng chọn rồi copy hoặc lưu — không cần mở thêm cửa sổ chỉnh sửa nào.

## Tính năng

### Chụp & chọn vùng
- Phím tắt toàn cục (mặc định `Alt + Shift + S`) — tự chụp màn hình đang chứa con trỏ chuột.
- Kéo để chọn vùng; resize bằng 8 handle, kéo bên trong để di chuyển vùng.
- Kính lúp khi chọn vùng, lưới căn chỉnh (đường kẻ/chấm, không xuất ra ảnh), khóa tỉ lệ khung hình.

### Chú thích tại chỗ
- Công cụ: Chọn, Chữ, Bút, Đường thẳng, Mũi tên, Chữ nhật, Elip, Highlight, Blur (pixelate), Tương phản (đảo màu), Đánh số, Thước đo (px).
- Tùy chỉnh màu (bộ chọn + hex), độ dày, độ mờ, kiểu nét (liền, đứt, chấm, gạch-chấm, đôi), kiểu mũi tên, font chữ.
- Bảng layer: đổi tên (nhấp đúp), ẩn/hiện, chọn nhiều (Ctrl/Shift + click), xóa, đổi thứ tự.
- Giữ `Shift` khi vẽ để ra hình vuông/tròn hoặc khóa góc 45°.
- Undo / Redo.

### Xuất ảnh
- Copy vào clipboard, Lưu nhanh vào thư mục cấu hình, hoặc Lưu thành... (chọn nơi lưu).
- Hoàn tất = copy + đóng.

### Hệ thống
- Chạy nền ở system tray, tùy chọn khởi động cùng Windows.
- Nhập/Xuất toàn bộ cài đặt ra file JSON.
- Đa ngôn ngữ: English (mặc định) / Tiếng Việt.
- Theme: Light (mặc định) / Dark / System.

## Phím tắt mặc định

| Phím | Chức năng |
| --- | --- |
| `Alt + Shift + S` | Chụp màn hình (toàn cục) |
| `Esc` | Hủy |
| `Enter` / `Ctrl + C` | Copy |
| `Ctrl + S` | Lưu nhanh |
| `Ctrl + Z` | Undo |
| `T P L A R E H B N` | Chọn công cụ |

Mọi phím tắt đều đổi được trong tab **Shortcuts** (có kiểm tra trùng phím).

## Cài đặt

Cửa sổ chính có 3 tab:

- **General** — ngôn ngữ, theme, phím tắt chụp, thư mục lưu, định dạng, khởi động cùng Windows, chạy nền ở tray.
- **Display** — vị trí thanh công cụ (Top/Bottom/Left/Right), gộp/tách thanh, hiện phím tắt trên nút, độ mờ viền chọn, kính lúp, lưới, bật/tắt từng tool, giá trị mặc định (màu, độ dày...).
- **Shortcuts** — phím tắt cho từng tool và thao tác.

Cài đặt lưu tại `%AppData%\NinoMark\settings.json`. Đặt biến môi trường `NINOMARK_DATA_DIR` để dùng thư mục dữ liệu riêng (hữu ích khi chạy thử, không đụng vào cài đặt thật).

## Tải về

Tải bản chạy sẵn tại [trang Releases](https://github.com/TokisakiNinoVn/NinoMark/releases/latest):

- **`NinoMark-<phiên bản>-setup.exe`** (khuyên dùng): bộ cài có lối tắt Start menu / desktop và gỡ cài đặt, không cần quyền admin.
- **`NinoMark-<phiên bản>-win-x64-portable.zip`**: giải nén và chạy `NinoMark.exe`, không cài gì vào máy.

Cả hai đã kèm sẵn .NET, không cần cài thêm.

## Yêu cầu khi tự build

- Windows 10/11 x64
- [.NET 10 SDK](https://dotnet.microsoft.com/download) (kèm Windows Desktop targeting pack)

## Build & chạy

```powershell
dotnet restore .\NinoMark.sln
dotnet build .\NinoMark.sln -c Debug
dotnet run --project .\src\NinoMark\NinoMark.csproj
```

## Publish bản chạy độc lập

```powershell
dotnet publish .\src\NinoMark\NinoMark.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o .\publish
```

Chạy `publish\NinoMark.exe`.

## Cấu trúc dự án

```text
NinoMark.sln
src/NinoMark/
├─ App.xaml(.cs)                  # Điểm khởi động
├─ MainWindow.xaml(.cs)           # Cửa sổ cài đặt + đăng ký hotkey toàn cục
├─ Models/AppSettings.cs          # Mô hình cài đặt
├─ Services/
│  ├─ ScreenCaptureService.cs     # Chụp màn hình dưới con trỏ
│  ├─ SettingsService.cs          # Đọc/ghi settings.json
│  ├─ TrayService.cs              # System tray, khởi động cùng Windows
│  ├─ ShortcutHelper.cs           # Phím tắt mặc định, kiểm tra trùng
│  ├─ Loc.cs                      # Đa ngôn ngữ
│  └─ Presets.cs, AppInfo.cs
└─ Windows/
   ├─ CaptureWindow.xaml(.cs)     # Overlay: chọn vùng + chú thích tại chỗ
   ├─ AboutWindow.xaml(.cs)
   └─ InfoListWindow.xaml(.cs)
```

## Giới hạn hiện tại

- Chưa test kỹ multi-monitor có scaling khác nhau (100%/125%/150%).
- Chỉ hỗ trợ Windows.

## Giấy phép

Phát hành theo [MIT License](LICENSE).
