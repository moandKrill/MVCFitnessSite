Clear-Host
[Console]::OutputEncoding = [System.Text.Encoding]::UTF8

# Конфигурация
$projectPath = "."  # Текущий путь скрипта
$connectionString = "Server=31.31.196.28;Database=u2793557_FitnessClub;User Id=u2793557_fitness;Password=nP6uM5oE7psZ2oF8;"
$provider = "Pomelo.EntityFrameworkCore.MySql"
$outputDir = "Models"
$contextDir = "Data"
$contextName = "FitnessClubContext"
$namespaceName = "DB"

# Папки назначения
$targetProjectPath = "C:\Users\KIRILL\Desktop\Учеба С\Less4_MVC_fitnes_EF_MySQL\Less2_MVC"
$targetModelsPath = Join-Path $targetProjectPath "Models"
$targetContextPath = Join-Path $targetProjectPath "Data"

Set-Location $projectPath

# Очистка локальной папки моделей
if (Test-Path $outputDir) {
    $existingFiles = Get-ChildItem -Path $outputDir -File
    if ($existingFiles.Count -gt 0) {
        $confirmClear = Read-Host "? Очистить локальную папку '$outputDir'? (y/n)"
        if ($confirmClear -eq 'y') {
            Remove-Item "$outputDir\*" -Force
        }
    }
}
# Очистка локальной папки контекста
if (Test-Path $contextDir) {
    $existingCtxFiles = Get-ChildItem -Path $contextDir -File
    if ($existingCtxFiles.Count -gt 0) {
        $confirmCtx = Read-Host "? Очистить локальную папку '$contextDir'? (y/n)"
        if ($confirmCtx -eq 'y') {
            Remove-Item "$contextDir\*" -Force
        }
    }
} else {
    New-Item -ItemType Directory -Path $contextDir | Out-Null
}


# Установка dotnet-ef при необходимости
if (-not (dotnet tool list -g | Select-String 'dotnet-ef')) {
    Write-Host "?? Установка dotnet-ef..."
    dotnet tool install --global dotnet-ef
}

# Проверка и установка NuGet-пакетов
$requiredPackages = @{
    "Microsoft.EntityFrameworkCore"        = "8.0.3"
    "Microsoft.EntityFrameworkCore.Tools"  = "8.0.3"
    "Pomelo.EntityFrameworkCore.MySql"     = "8.0.0"
}

$projectFile = Get-ChildItem -Filter *.csproj | Select-Object -First 1
$projectContent = Get-Content $projectFile.FullName -Raw

foreach ($package in $requiredPackages.Keys) {
    $version = $requiredPackages[$package]
    if ($projectContent -notmatch "$package.*?Version=`"$version`"") {
        Write-Host "? Установка $package версии $version..."
        dotnet add package $package --version $version
    } else {
        Write-Host "? $package $version уже установлен"
    }
}

# Выполнение scaffold
dotnet ef dbcontext scaffold `
    "$connectionString" `
    $provider `
    --output-dir $outputDir `
    --context-dir $contextDir `
    --context $contextName `
    --data-annotations `
    --force

# # Замена namespace на 'DB'
# Get-ChildItem "$outputDir\*.cs","$contextDir\*.cs" | ForEach-Object {
#     (Get-Content $_.FullName) -replace 'namespace .*', "namespace $namespaceName" | Set-Content $_.FullName
# }

# Копирование с подтверждением очистки
function Copy-With-Cleanup {
    param (
        [string]$Source,
        [string]$Target
    )
    if (Test-Path $Target) {
        $targetFiles = Get-ChildItem $Target -File
        if ($targetFiles.Count -gt 0) {
            $confirm = Read-Host "? Очистить целевую папку '$Target' перед копированием? (y/n)"
            if ($confirm -eq 'y') {
                Remove-Item "$Target\*" -Force
            }
        }
    } else {
        New-Item -ItemType Directory -Path $Target | Out-Null
    }
    Copy-Item "$Source\*" -Destination $Target -Force
}

# Write-Host "?? Копирование моделей и контекста в проект..."
# Copy-With-Cleanup -Source $outputDir -Target $targetModelsPath
# Copy-With-Cleanup -Source $contextDir -Target $targetContextPath

Write-Host "? Все операции успешно завершены."
