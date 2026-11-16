@echo off
setlocal
cd /d "%~dp0"
set "CSC=%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\csc.exe"
if not exist "%CSC%" set "CSC=%WINDIR%\Microsoft.NET\Framework\v4.0.30319\csc.exe"
if not exist "%CSC%" (
  echo Couldn't find the C# compiler that comes with .NET Framework 4.
  pause
  exit /b 1
)
"%CSC%" /nologo /target:winexe /optimize+ /win32icon:OrionVolume.ico /out:OrionVolume.exe /r:System.dll /r:System.Core.dll /r:System.Drawing.dll /r:System.Windows.Forms.dll /r:System.Web.Extensions.dll OrionVolume.cs
if errorlevel 1 (
  pause
  exit /b 1
)
echo Built OrionVolume.exe
pause
