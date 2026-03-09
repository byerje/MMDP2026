$file = "C:\Users\jbyer\Documents\source\repos\MMDP2026\MurderMysteryParty\Components\Pages\CharacterDetails\CharacterDetails.razor.cs"
$text = [System.IO.File]::ReadAllText($file, [System.Text.Encoding]::UTF8)

# Unicode codepoints:
# U+2705  = ?  White Heavy Check Mark
# U+274C  = ?  Cross Mark
# U+26A0  = ?   Warning Sign
# U+FE0F  =     Variation Selector-16 (makes ? emoji presentation)
# U+1F389 = ??  Party Popper

$check   = [char]0x2705
$cross   = [char]0x274C
$warn    = [char]0x26A0 + [char]0xFE0F
$party   = [char]::ConvertFromUtf32(0x1F389)

$text = $text -replace 'statusMessage = "(\?+) Character not found\.',                  "statusMessage = `"$cross Character not found."
$text = $text -replace 'statusMessage = \$"(\?+) You are currently assigned as',        "statusMessage = `$`"$check You are currently assigned as"
$text = $text -replace 'statusMessage = "(\?+) You already have a different character', "statusMessage = `"$warn You already have a different character"
$text = $text -replace 'statusMessage = \$"(\?+) \{character\.Name\} is already assigned to another player', "statusMessage = `$`"$cross {character.Name} is already assigned to another player"
$text = $text -replace 'statusMessage = \$"(\?+) You are already assigned as',          "statusMessage = `$`"$warn You are already assigned as"
$text = $text -replace 'statusMessage = \$"(\?+) \{character\.Name\} was just claimed', "statusMessage = `$`"$cross {character.Name} was just claimed"
$text = $text -replace 'statusMessage = \$"(\?+) Success!',                             "statusMessage = `$`"$party Success!"

[System.IO.File]::WriteAllText($file, $text, [System.Text.Encoding]::UTF8)
Write-Host "Done. Verifying..."

$verify = [System.IO.File]::ReadAllText($file, [System.Text.Encoding]::UTF8)
$verify -split "`n" | Where-Object { $_ -match "statusMessage\s*=" -and $_ -notmatch "null|Contains|==" } | ForEach-Object { $_.Trim() }
