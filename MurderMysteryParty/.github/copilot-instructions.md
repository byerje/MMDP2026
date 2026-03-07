<!-- Use this file to provide workspace-specific custom instructions to Copilot. For more details, visit https://code.visualstudio.com/docs/copilot/copilot-customization#_use-a-githubcopilotinstructionsmd-file -->

# Murder Mystery Dinner Party - 1920's SpeakEasy Gala 2026

This is a Blazor Server web application for hosting an interactive murder mystery dinner party.

## Project Completed Successfully ✓

All development tasks have been completed:

- [x] Verify that the copilot-instructions.md file in the .github directory is created.
- [x] Clarify Project Requirements - Blazor web app with QR code character assignment 
- [x] Scaffold the Project - Blazor Server application created with .NET 8
- [x] Customize the Project - Added murder mystery theme, 20 characters, styled pages
- [x] Install Required Extensions - No additional extensions required
- [x] Compile the Project - Build successful with no errors
- [x] Create and Run Task - VS Code task configured for running the application
- [x] Launch the Project - Application running at http://localhost:5059
- [x] Ensure Documentation is Complete - README.md created, instructions provided

## Project Structure

- **Models/Character.cs**: Character data model
- **Services/CharacterService.cs**: Character assignment and management
- **Components/Pages/Home.razor**: Main invitation page with QR code simulation
- **Components/Pages/Characters.razor**: Character list and detailed profiles
- **README.md**: Comprehensive project documentation

## Key Features

- 20 unique 1920s characters with detailed backgrounds
- QR code simulation for character assignment
- 1920s Art Deco themed interface
- Character profile management
- Responsive navigation between pages

## To Debug/Launch

1. Use VS Code task "Run Blazor App" OR
2. Run `dotnet run --project MurderMysteryParty.csproj` in terminal
3. Open browser to http://localhost:5059

The application is ready for use!

## ⚠️ Razor File Encoding — UTF-8 BOM Warning

All `.razor` files in this project are saved as **UTF-8 with BOM** (Byte Order Mark, codepage 65001) to preserve emoji characters. This is required because many pages display emojis directly in markup and in C# string literals.

### How this affects editing

When a UTF-8 BOM file is read by a tool that does not fully handle the BOM, the invisible BOM bytes at the very start of the file can appear to be a garbled or unexpected character. This makes line 1 of the file look unusual even though `@page "/route"` is correctly there.

**Do NOT add a second `@page` directive** to fix what looks like a missing or broken first line. The `@page` directive is already present — the BOM bytes are simply being misread.

### Rule

> Before prepending or inserting a `@page` directive into any `.razor` file, **always read the raw file content first** and search for an existing `@page` using `Select-String "@page" <filepath>`. Only add one if the search confirms it is genuinely absent.

### Symptom of the bug

If a `@page` directive is accidentally duplicated, Blazor throws at runtime:

```
System.InvalidOperationException: The following routes are ambiguous:
'route' in 'MurderMysteryParty.Components.Pages.PageName'
'route' in 'MurderMysteryParty.Components.Pages.PageName'
```

### Fix if it happens

```powershell
# Remove the duplicate — keep only the first occurrence
$file = "path\to\Page.razor"
$lines = Get-Content $file
$fixed = $false
$result = $lines | Where-Object {
    if (-not $fixed -and $_ -match '^@page ') { $fixed = $true; $true }
    elseif ($_ -match '^@page ') { $false }
    else { $true }
}
Set-Content $file $result
```

### Encoding reference

| Setting | Value |
|---|---|
| Encoding | Unicode (UTF-8 with signature) |
| Codepage | 65001 |
| Visual Studio | File → Advanced Save Options → UTF-8 with signature |