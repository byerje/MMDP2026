# Usage: run from repo root: .\scripts\deploy-ghpages.ps1
# Publishes the Blazor app and deploys publish/wwwroot to gh-pages via a temporary folder.

param()

# Publish
Write-Host "Publishing project..."
dotnet publish MurderMysteryParty/MurderMysteryParty.csproj -c Release -o publish

$publishDir = Join-Path (Get-Location) "publish\wwwroot"
if (-not (Test-Path $publishDir)) { Write-Error "Publish output not found at $publishDir"; exit 1 }

# Create temp folder
$timestamp = Get-Date -Format "yyyyMMddHHmmss"
$tempDir = Join-Path $env:TEMP ("ghdeploy_$timestamp")
New-Item -ItemType Directory -Path $tempDir -Force | Out-Null

# Copy files
Write-Host "Copying files to temp folder $tempDir ..."
robocopy $publishDir $tempDir /MIR | Out-Null

# Init git and push
Push-Location $tempDir
Write-Host "Initializing git in temp folder and pushing to gh-pages..."
git init
$remote = git -C .. config --get remote.origin.url 2>$null
if (-not $remote) { $remote = git config --get remote.origin.url }
if (-not $remote) { Write-Error "Remote origin not found; ensure this repo has a remote named 'origin'"; Pop-Location; Remove-Item $tempDir -Recurse -Force; exit 1 }

git remote add origin $remote
git checkout -b gh-pages
git add --all
git commit -m "Deploy to gh-pages" || Write-Host "No changes to commit"

git push origin gh-pages --force
Pop-Location

# Cleanup
Remove-Item $tempDir -Recurse -Force
Write-Host "Deployment finished."