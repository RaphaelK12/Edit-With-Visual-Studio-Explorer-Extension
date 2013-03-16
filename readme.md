Super simple Windows shell extension that opens a file for editing in Visual Studio.

* Uses an existing instance of Visual Studio if possible (devenv /edit)
* Works on Windows 8 x64/x86 at least, not tested but should work on 7 and potentially previous versions
* Should support at least Visual Studio 2008-2012; detects and uses appropriate version
* Good simple example for custom explorer shell extension in C# using [SharpShell](http://sharpshell.codeplex.com/)

Just something I threw together because I'm sick of switching editors after starting to edit a file...  Not perfect design, structure, whatever.

Install by opening Developer Command Prompt as Admin (or no UAC) and running scripts/install.cmd
