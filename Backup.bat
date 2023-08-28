﻿@echo off

set HOST=%1

set BACKUPPATH=%2

rem:: echo %HOST%
rem:: echo %BACKUPPATH%

sqlcmd -S %HOST% -E -Q "USE [PavilionsDB] EXEC [dbo].MakeBackup @backupLocation='%BACKUPPATH%'"