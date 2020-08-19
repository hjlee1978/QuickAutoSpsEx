#define MyAppName "QuickAutoSpsEx"
#define MyAppPublisher "Daeyang Electric Co., Ltd."
#define MyAppURL "https://github.com/hjlee1978/QuickAutoSpsEx"
#define MyAppExeName "QuickAutoSpsEx.exe"
#define MyCompanyName "Daeyang Electric Co., Ltd."
#define MyAppVersion GetFileVersion("../Source/bin/Release/"+MyAppExeName)

#define Dotnet472Enu "설치 .Net Framework " + GetFileVersion("NDP472-KB4054530-x86-x64-AllOS-ENU.exe")
#define Dotnet472Kor "설치 .Net Framework 한글언어팩 " + GetFileVersion("NDP472-KB4054530-x86-x64-AllOS-KOR.exe")

#define FullInstall

[Setup]
AppId={{880644A9-9C9A-4916-96B5-2348F2CD97A1}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={commonpf}\{#MyAppName}
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
#ifdef FullInstall
OutputBaseFilename={#MyAppName}_Setup_Full_{#MyAppVersion}
#else //FullInstall
OutputBaseFilename={#MyAppName}_Setup_{#MyAppVersion}
#endif //FullInstall
Compression=lzma
SolidCompression=yes
LicenseFile = LICENSE.txt

[Languages]
Name: "korean"; MessagesFile: "compiler:Languages\Korean.isl"

[Dirs]

[Files]
Source: "../Source/bin/Release/*.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "../Source/bin/Release/*.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "../Source/bin/Release/*.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "../Source/bin/Release/Data/*.*"; DestDir: "{app}\Data\"; Flags: ignoreversion

#ifdef FullInstall
Source: "NDP472-KB4054530-x86-x64-AllOS-ENU.exe"; DestDir: "{app}\temp\"; Flags: ignoreversion deleteafterinstall; Check: IsNotFrameworkInstalled
Source: "NDP472-KB4054530-x86-x64-AllOS-KOR.exe"; DestDir: "{app}\temp\"; Flags: ignoreversion deleteafterinstall; Check: IsNotFrameworkInstalled
#endif //FullInstall

[Run]
#ifdef FullInstall
Filename: "{app}\temp\NDP472-KB4054530-x86-x64-AllOS-ENU.exe"; Parameters: "/install /quiet /norestart"; StatusMsg: "{#Dotnet472Enu}"; Description: "{#Dotnet472Enu}"; Flags: postinstall; Check: IsNotFrameworkInstalled
Filename: "{app}\temp\NDP472-KB4054530-x86-x64-AllOS-KOR.exe"; Parameters: "/install /quiet /norestart"; StatusMsg: "{#Dotnet472Kor}"; Description: "{#Dotnet472Kor}"; Flags: postinstall; Check: IsNotFrameworkInstalled
#endif //FullInstall

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


