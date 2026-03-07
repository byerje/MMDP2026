namespace MurderMysteryParty.Components.Pages.MyCharacter;

public static class RoundContentFormatter
{
    public static string FormatRound1Content(string content)
    {
        if (string.IsNullOrEmpty(content))
            return "";

        var sections = content.Split(new[] { "CONCEALED SECRETS:" }, StringSplitOptions.RemoveEmptyEntries);

        var formattedHtml = "";

        if (sections.Length > 0)
        {
            var interactionsSection = sections[0].Replace("INTERACTIONS & REVEAL CLUES:", "").Trim();
            if (!string.IsNullOrEmpty(interactionsSection))
            {
                formattedHtml += "<div class='content-section'>";
                formattedHtml += "<h5 class='section-title'>INTERACTIONS & REVEAL CLUES:</h5>";
                formattedHtml += "<ul class='round-list'>";

                var interactions = interactionsSection.Split('•', StringSplitOptions.RemoveEmptyEntries);
                foreach (var interaction in interactions)
                {
                    var cleanInteraction = interaction.Trim();
                    if (!string.IsNullOrEmpty(cleanInteraction))
                        formattedHtml += $"<li>{cleanInteraction}</li>";
                }
                formattedHtml += "</ul></div>";
            }
        }

        if (sections.Length > 1)
        {
            var secretsSection = sections[1].Trim();
            if (!string.IsNullOrEmpty(secretsSection))
            {
                formattedHtml += "<div class='content-section concealed-secrets'>";
                formattedHtml += "<h5 class='section-title secrets-title'>CONCEALED SECRETS:</h5>";
                formattedHtml += "<ul class='round-list secrets-list'>";

                var secrets = secretsSection.Split('•', StringSplitOptions.RemoveEmptyEntries);
                foreach (var secret in secrets)
                {
                    var cleanSecret = secret.Trim();
                    if (!string.IsNullOrEmpty(cleanSecret))
                        formattedHtml += $"<li>{cleanSecret}</li>";
                }
                formattedHtml += "</ul></div>";
            }
        }

        return formattedHtml;
    }

    public static string FormatRound2Content(string content)
    {
        if (string.IsNullOrEmpty(content))
            return "";

        var formattedHtml = "";
        var inList = false;
        var inSection = false;

        if (content.Contains("PART A") || content.Contains("PART B"))
        {
            var lines = content.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var trimmedLine = line.Trim();

                if (trimmedLine.StartsWith("PART A") || trimmedLine.StartsWith("PART B"))
                {
                    if (inList) { formattedHtml += "</ul>"; inList = false; }
                    if (inSection) { formattedHtml += "</div>"; }
                    formattedHtml += $"<div class='content-section'><h5 class='section-title'>{trimmedLine}</h5>";
                    inSection = true;
                }
                else if (trimmedLine.StartsWith("•"))
                {
                    if (!inList) { formattedHtml += "<ul class='round-list'>"; inList = true; }
                    formattedHtml += $"<li>{trimmedLine.Substring(1).Trim()}</li>";
                }
                else if (trimmedLine.Contains("If asked") || trimmedLine.Contains("corroborate"))
                {
                    if (inList) { formattedHtml += "</ul>"; inList = false; }
                    formattedHtml += $"<div class='corroboration-section'><p class='corroboration-text'>{trimmedLine}</p></div>";
                }
                else if (!string.IsNullOrEmpty(trimmedLine))
                {
                    if (inList) { formattedHtml += "</ul>"; inList = false; }
                    formattedHtml += $"<p>{trimmedLine}</p>";
                }
            }

            if (inList) formattedHtml += "</ul>";
            if (inSection) formattedHtml += "</div>";
        }
        else
        {
            formattedHtml = $"<p>{content.Replace("\n", "<br>")}</p>";
        }

        return formattedHtml;
    }

    public static string FormatRound3AContent(string content)
    {
        if (string.IsNullOrEmpty(content))
            return "";

        var formattedHtml = "";
        var lines = content.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines)
        {
            var trimmedLine = line.Trim();

            if (trimmedLine.StartsWith("FOLLOW AFTER:"))
            {
                var followAfter = trimmedLine.Replace("FOLLOW AFTER:", "").Trim();
                formattedHtml += $"<p class='round3-order'><strong>Follow After:</strong> {followAfter}</p>";
            }
            else if (trimmedLine.StartsWith("TRUE STORY REVEAL:"))
            {
                formattedHtml += "<h5 class='section-title round3-motive-title'>Your Motive:</h5>";
            }
            else if (trimmedLine.StartsWith("FOLLOWED BY:"))
            {
                var followedBy = trimmedLine.Replace("FOLLOWED BY:", "").Trim();
                formattedHtml += $"<p class='round3-order'><strong>Followed By:</strong> {followedBy}</p>";
            }
            else if (!string.IsNullOrEmpty(trimmedLine))
            {
                formattedHtml += $"<p class='round3-story'>{trimmedLine}</p>";
            }
        }

        return formattedHtml;
    }

    public static string FormatRound3BContent(string content)
    {
        if (string.IsNullOrEmpty(content))
            return "";

        var formattedHtml = "";
        var lines = content.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines)
        {
            var trimmedLine = line.Trim();

            if (trimmedLine.StartsWith("CHAOS TRIGGER:"))
            {
                formattedHtml += "<h5 class='section-title chaos-trigger-title'>Chaos Trigger:</h5>";
            }
            else if (trimmedLine.StartsWith("FINAL IGNITION:"))
            {
                formattedHtml += "<h5 class='section-title chaos-trigger-title'>Final Ignition:</h5>";
            }
            else if (trimmedLine.StartsWith("If "))
            {
                formattedHtml += $"<p class='chaos-condition'><strong>Condition:</strong> {trimmedLine}</p>";
            }
            else if (!string.IsNullOrEmpty(trimmedLine))
            {
                formattedHtml += $"<p class='chaos-action'>{trimmedLine}</p>";
            }
        }

        return formattedHtml;
    }
}
