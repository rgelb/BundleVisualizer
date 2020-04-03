[Setup]
AppName=Bundle Visualizer
AppVerName=BundleVisualizer
AppCopyright=Copyright (C) 2020 Robert Gelb
AppPublisher=Robert Gelb
DefaultDirName={userpf}\BundleVisualizer
DisableDirPage=yes
DisableProgramGroupPage=yes
DisableReadyPage=yes
UninstallDisplayIcon={app}\BundleVisualizer.exe
OutputBaseFilename=BundleVisualizer
AppID=BundleVisualizer.1
VersionInfoVersion=0.1
PrivilegesRequired=lowest

[Files]
Source: "..\bin\debug\BundleVisualizer.exe"; DestDir: "{app}"
Source: "..\bin\debug\Newtonsoft.Json.dll"; DestDir: "{app}"

[Icons]
Name: "{userstartup}\Bundle Visualizer"; Filename: "{app}\BundleVisualizer.exe"; 

[Run]
Filename: "{app}\BundleVisualizer.exe"; Description: "Launch Bundle Visualizer"; Flags: postinstall nowait skipifsilent