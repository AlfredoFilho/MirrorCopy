[Setup]
AppName=MirrorCopy
AppVersion=1.0
DefaultDirName={pf}\MirrorCopy
DefaultGroupName=MirrorCopy
OutputDir=MirrorCopy\dist
OutputBaseFilename=MirrorCopyInstaller
Compression=lzma2
SolidCompression=yes
SetupIconFile=MirrorCopy\Assets\icon.ico

[Files]
Source: "MirrorCopy\publish\MirrorCopy.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "MirrorCopy\publish\D3DCompiler_47_cor3.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "MirrorCopy\publish\MirrorCopy.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "MirrorCopy\publish\PenImc_cor3.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "MirrorCopy\publish\PresentationNative_cor3.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "MirrorCopy\publish\vcruntime140_cor3.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "MirrorCopy\publish\wpfgfx_cor3.dll"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\MirrorCopy"; Filename: "{app}\MirrorCopy.exe"
Name: "{commondesktop}\MirrorCopy"; Filename: "{app}\MirrorCopy.exe"; Tasks: desktopicon
Name: "{group}\Uninstall MirrorCopy"; Filename: "{uninstallexe}"

[Tasks]
Name: "desktopicon"; Description: "Create a desktop icon"; GroupDescription: "Additional icons:"

[Run]
Filename: "{app}\MirrorCopy.exe"; Description: "Run MirrorCopy now"; Flags: nowait postinstall skipifsilent
