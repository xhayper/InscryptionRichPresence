@echo off
dotnet build --output .output/
RMDIR /s /q production >nul 2>&1
XCOPY .output\InscryptionRichPresence.dll production\ /v /y >nul
XCOPY manifest.json production\ /v /y >nul
XCOPY icon.png production\ /v /y >nul
XCOPY README.md production\ /v /y >nul