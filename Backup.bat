﻿@echo off

set HOST=%1

set DATABASE=%2

set BACKUPPATH=%3

echo %HOST%
echo %BACKUPPATH%

rem: sqlcmd -S %HOST% -E -Q "EXEC MakeBackup @backupLocation='%BACKUPPATH%\%DATABASE%.bak', @databaseName='DATABASE'"