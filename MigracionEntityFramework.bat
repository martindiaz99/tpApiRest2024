@echo off
cd /d "%~dp0"
cd /d "TP Veterinaria\TP Veterinaria"
dotnet ef database update
pause