param([string]$ex="?")

if ($ex -eq "3-4") {
    & '.\Exercise 3-4\run.ps1'
} elseif ($ex -eq "5") {
    & '.\Exercise 5\run.ps1'
} else {
    Write-Host "Unknown exercise '$ex'`nUse '3-4' or '5'." -ForegroundColor Red
}