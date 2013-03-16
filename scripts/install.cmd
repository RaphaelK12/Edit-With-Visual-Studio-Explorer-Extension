msbuild ..\BAG.EditWithVisualStudio.sln /p:Configuration=Release
gacutil /i ..\src\BAGEditWithVisualStudio\bin\Release\SharpShell.dll /f
gacutil /i ..\src\BAGEditWithVisualStudio\bin\Release\BAGEditWithVisualStudio.dll /f
regedit install.reg
taskkill /im "explorer.exe" /f
start explorer.exe