# Changelog

All notable changes to this project are documented in this file.
The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Changed
- Renamed the app from SnapMark to NinoMark. Existing settings and the start-with-Windows entry migrate automatically on first launch.
- The `SNAPMARK_DATA_DIR` environment variable is now `NINOMARK_DATA_DIR`.
- Lower memory use: the working set is trimmed when the app sits in the tray and after a capture, dropping idle RAM from ~160 MB to under 10 MB.

## [0.3.0] - 2026-11-21

First public release.

### Added
- Global hotkey capture (default `Alt+Shift+S`) with an in-place annotation overlay.
- Tools: select, text, pen, line, arrow, rectangle, ellipse, highlight, blur, invert, number, ruler, magnifier.
- Line types: plain, ticked ends, dotted ends, arrow ends.
- Configurable font weight (light, normal, semi-bold, bold) and font family for text.
- Edit text by clicking it with the Text tool; edit numbers by clicking them with the Number tool.
- Hold `Ctrl` with any tool to select and move objects directly.
- Layers panel (rename, show/hide, multi-select, reorder) and object quick bar (duplicate, rotate, flip).
- Aspect-ratio lock, alignment grid, magnifier loupe while selecting.
- Settings window: shortcuts, toolbar position and layout, tool visibility and order, default styles.
- Settings import / export to a JSON file.
- System tray, start with Windows, English and Vietnamese UI, light / dark / system theme.

### Fixed
- Icons and search field icon were unreadable on the dark theme at first launch.

[Unreleased]: https://github.com/TokisakiNinoVn/NinoMark/compare/v0.3.0...HEAD
[0.3.0]: https://github.com/TokisakiNinoVn/NinoMark/releases/tag/v0.3.0
