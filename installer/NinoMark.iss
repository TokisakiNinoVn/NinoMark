; Inno Setup script for NinoMark. Built by .github/workflows/release.yml:
;   ISCC /DAppVersion=0.4.0 /DSourceDir=..\out\self-contained /DOutputDir=..\dist installer\NinoMark.iss

#ifndef AppVersion
  #define AppVersion "0.0.0"
#endif
#ifndef SourceDir
  #define SourceDir "..\out\self-contained"
#endif
#ifndef OutputDir
  #define OutputDir "..\dist"
#endif

#define AppName "NinoMark"
#define AppExe "NinoMark.exe"

[Setup]
AppId={{6F2B1C0E-4D7A-4B8E-9C35-2A71E5D0B9A4}
AppName={#AppName}
AppVersion={#AppVersion}
AppPublisher=Tokisaki Nino
AppPublisherURL=https://nino-mark.vercel.app
AppSupportURL=https://github.com/TokisakiNinoVn/NinoMark/issues
DefaultDirName={autopf}\{#AppName}
DefaultGroupName={#AppName}
DisableProgramGroupPage=yes
OutputDir={#OutputDir}
OutputBaseFilename=NinoMark-{#AppVersion}-setup
; app-fit.ico has 16..256px frames; the old app.ico only had a single 256px frame, which looked blurry when Windows scaled it down
SetupIconFile=..\src\NinoMark\Assets\app-fit.ico
UninstallDisplayIcon={app}\{#AppExe}
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
; Per-user install by default (no admin prompt); the user can choose "for all users" in the dialog
PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog
CloseApplications=yes
RestartApplications=no

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "{#SourceDir}\{#AppExe}"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{autoprograms}\{#AppName}"; Filename: "{app}\{#AppExe}"
Name: "{autodesktop}\{#AppName}"; Filename: "{app}\{#AppExe}"; Tasks: desktopicon

[Registry]
; Remove the "start with Windows" entry (written by the app) on uninstall
Root: HKCU; Subkey: "Software\Microsoft\Windows\CurrentVersion\Run"; ValueType: none; ValueName: "{#AppName}"; Flags: dontcreatekey uninsdeletevalue

[Run]
Filename: "{app}\{#AppExe}"; Description: "{cm:LaunchProgram,{#AppName}}"; Flags: nowait postinstall skipifsilent
