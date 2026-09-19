@echo off
title BioClock - Biometric Attendance System
cd /d "%~dp0"

set "EXE=bin\Debug\Demo.exe"

if not exist "%EXE%" (
    echo.
    echo [ERROR] Demo.exe not found at: %EXE%
    echo Build the project first, or check the path.
    echo.
    pause
    exit /b 1
)

echo.
echo Starting BioClock fingerprint attendance app...
echo EXE: "%CD%\%EXE%"
echo.
start "" "%EXE%"
