using Xunit;
using MurderMysteryParty.Components.Pages.MyCharacter;

namespace MurderMysteryParty.Tests;

public class RoundContentFormatterTests
{
    // ?? FormatRound1Content ????????????????????????????????????????????????

    private const char B = '\u2022';

    [Fact]
    public void FormatRound1Content_EmptyString_ReturnsEmpty()
    {
        Assert.Equal("", RoundContentFormatter.FormatRound1Content(""));
    }

    [Fact]
    public void FormatRound1Content_NullEquivalent_ReturnsEmpty()
    {
        Assert.Equal("", RoundContentFormatter.FormatRound1Content(string.Empty));
    }

    [Fact]
    public void FormatRound1Content_SingleBullet_ProducesOneLiItem()
    {
        var content = $"INTERACTIONS & REVEAL CLUES:\n{B} Do this thing";
        var result = RoundContentFormatter.FormatRound1Content(content);
        Assert.Single(result.Split("<li>", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToList());
        Assert.Contains("<li>Do this thing</li>", result);
    }

    [Fact]
    public void FormatRound1Content_BulletWithEmbeddedNewline_ProducesOneLiItem()
    {
        var content = $"INTERACTIONS & REVEAL CLUES:\n{B} Go to Sam and say: 'Hello.'\n  Extra note on same bullet.";
        var result = RoundContentFormatter.FormatRound1Content(content);
        var liCount = result.Split("<li>", StringSplitOptions.RemoveEmptyEntries).Length - 1;
        Assert.Equal(1, liCount);
        Assert.DoesNotContain("\n", result);
    }

    [Fact]
    public void FormatRound1Content_MultipleBullets_ProducesCorrectLiCount()
    {
        var content = $"INTERACTIONS & REVEAL CLUES:\n{B} First item\n{B} Second item\n{B} Third item";
        var result = RoundContentFormatter.FormatRound1Content(content);
        var liCount = result.Split("<li>", StringSplitOptions.RemoveEmptyEntries).Length - 1;
        Assert.Equal(3, liCount);
    }

    [Fact]
    public void FormatRound1Content_NoBullets_TreatsWholeTextAsOneItem()
    {
        var content = "INTERACTIONS & REVEAL CLUES:\nNo bullet points here";
        var result = RoundContentFormatter.FormatRound1Content(content);
        // Without any • separator the entire text becomes one <li>
        var liCount = result.Split("<li>", StringSplitOptions.RemoveEmptyEntries).Length - 1;
        Assert.Equal(1, liCount);
        Assert.Contains("No bullet points here", result);
    }

    [Fact]
    public void FormatRound1Content_WithConcealedSecrets_ProducesTwoSections()
    {
        var content = $"INTERACTIONS & REVEAL CLUES:\n{B} Reveal clue here\nCONCEALED SECRETS:\n{B} Secret one";
        var result = RoundContentFormatter.FormatRound1Content(content);
        Assert.Contains("section-title secrets-title", result);
        Assert.Contains("secrets-list", result);
        Assert.Contains("content-section concealed-secrets", result);
    }

    [Fact]
    public void FormatRound1Content_SecretBulletWithEmbeddedNewline_ProducesOneLiItem()
    {
        var content = $"INTERACTIONS & REVEAL CLUES:\n{B} Clue one\nCONCEALED SECRETS:\n{B} Secret with\nnewline inside";
        var result = RoundContentFormatter.FormatRound1Content(content);
        var secretsSection = result.Substring(result.IndexOf("secrets-list"));
        var liCount = secretsSection.Split("<li>", StringSplitOptions.RemoveEmptyEntries).Length - 1;
        Assert.Equal(1, liCount);
        Assert.DoesNotContain("\n", result);
    }

    [Fact]
    public void FormatRound1Content_MultipleSpacesCollapsed()
    {
        var content = $"INTERACTIONS & REVEAL CLUES:\n{B} Item   with   extra   spaces";
        var result = RoundContentFormatter.FormatRound1Content(content);
        Assert.DoesNotContain("  ", result);
    }

    [Fact]
    public void FormatRound1Content_NewlinesRemovedFromOutput()
    {
        var content = $"INTERACTIONS & REVEAL CLUES:\n{B} Item one\n{B} Item two\nCONCEALED SECRETS:\n{B} Secret one";
        var result = RoundContentFormatter.FormatRound1Content(content);
        Assert.DoesNotContain("\n", result);
        Assert.DoesNotContain("\r", result);
    }

    // ?? FormatRound3BContent ??????????????????????????????????????????????

    [Fact]
    public void FormatRound3BContent_EmptyString_ReturnsEmpty()
    {
        Assert.Equal("", RoundContentFormatter.FormatRound3BContent(""));
    }

    [Fact]
    public void FormatRound3BContent_ChaosTrigger_RendersAsHeading()
    {
        var content = "CHAOS TRIGGER:\nSomeone screams.";
        var result = RoundContentFormatter.FormatRound3BContent(content);
        Assert.Contains("<h5 class='section-title chaos-trigger-title'>Chaos Trigger:</h5>", result);
    }

    [Fact]
    public void FormatRound3BContent_ChaosAction_RendersAsHeading()
    {
        var content = "CHAOS ACTION:\nYell and point.";
        var result = RoundContentFormatter.FormatRound3BContent(content);
        Assert.Contains("<h5 class='section-title chaos-trigger-title'>Chaos Action:</h5>", result);
    }

    [Fact]
    public void FormatRound3BContent_ChaosAction_DoesNotRenderAsPlainParagraph()
    {
        var content = "CHAOS ACTION:\nYell and point.";
        var result = RoundContentFormatter.FormatRound3BContent(content);
        Assert.DoesNotContain("<p class='chaos-action'>CHAOS ACTION:", result);
    }

    [Fact]
    public void FormatRound3BContent_ChaosTriggerAndAction_BothRenderAsHeadings()
    {
        var content = "CHAOS TRIGGER:\nIf Ruby shouts...\nCHAOS ACTION:\nYell 'IT'S AN INSIDE JOB!'";
        var result = RoundContentFormatter.FormatRound3BContent(content);
        Assert.Contains("<h5 class='section-title chaos-trigger-title'>Chaos Trigger:</h5>", result);
        Assert.Contains("<h5 class='section-title chaos-trigger-title'>Chaos Action:</h5>", result);
    }

    [Fact]
    public void FormatRound3BContent_FinalIgnition_RendersAsHeading()
    {
        var content = "FINAL IGNITION:\nEveryone points.";
        var result = RoundContentFormatter.FormatRound3BContent(content);
        Assert.Contains("<h5 class='section-title chaos-trigger-title'>Final Ignition:</h5>", result);
    }

    [Fact]
    public void FormatRound3BContent_ConditionLine_RendersWithConditionLabel()
    {
        var content = "If someone falls...";
        var result = RoundContentFormatter.FormatRound3BContent(content);
        Assert.Contains("<strong>Condition:</strong>", result);
        Assert.Contains("chaos-condition", result);
    }

    [Fact]
    public void FormatRound3BContent_ActionText_RendersAsChaosActionParagraph()
    {
        var content = "CHAOS TRIGGER:\nYell at everyone.";
        var result = RoundContentFormatter.FormatRound3BContent(content);
        Assert.Contains("<p class='chaos-action'>Yell at everyone.</p>", result);
    }
}
