#define MyAppName "QuickAutoSps"
#define MyAppVersion "2020.602.1100"
#define MyAppPublisher "Firstec, Inc."
#define MyAppURL "https://github.com/FirstecRepo/QuickAutoSps"
#define MyAppExeName "QuickAutoSps.exe"
#define MyCompanyName "Firstec"

[Setup]
AppId={{{880644A9-9C9A-4916-96B5-2348F2CD97A1}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
OutputBaseFilename=QuickAutoSps_setup{#MyAppVersion}
Compression=lzma
SolidCompression=yes
LicenseFile = LICENSE.txt

[Dirs]

[Files]
Source: "../Source/bin/Release/QuickAutoSps.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "../Source/bin/Release/QuickAutoSps.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "../Source/bin/Release/*.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "../Source/bin/Release/Data/*.*"; DestDir: "{app}"; Flags: ignoreversion
Source: "classByExtension.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "classBySubString.txt"; DestDir: "{app}"; Flags: ignoreversion
;Source: "dotNetFx40.exe"; DestDir: {tmp}; Flags: deleteafterinstall; Check: IsNotFrameworkInstalled



[Run]
;Filename: "{tmp}\dotNetFx40.exe"; Check: IsNotFrameworkInstalled

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; WorkingDir: "{app}"
Name: "{group}\Uninstall {#MyAppName}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; WorkingDir: "{app}"
  
[UninstallDelete]
Type: filesandordirs; Name: "{app}\*"
Type: dirifempty; Name: "{app}"
Type: filesandordirs; Name: "{localappdata}\{#MyCompanyName}"            

[code]
function IsNotFrameworkInstalled: Boolean;
begin
  Result := not RegKeyExists(HKEY_LOCAL_MACHINE, 'SOFTWARE\Microsoft\.NETFramework\policy\v4.0');
end;


