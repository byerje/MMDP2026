using Xunit;
using MurderMysteryParty.Components.Pages.MyCharacter;

namespace MurderMysteryParty.Tests;

public class RoundContentFormatterTests
{
    // ?? FormatRound1Content ????????????????????????????????????????????????

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
        var content = "INTERACTIONS & REVEAL CLUES:\n• Do this thing";
        var result = RoundContentFormatter.FormatRound1Content(content);
        Assert.Single(result.Split("<li>", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToList());
        Assert.Contains("<li>Do this thing</li>", result);
    }

    [Fact]
    public void FormatRound1Content_BulletWithEmbeddedNewline_ProducesOneLiItem()
    {
        // \n inside a bullet item used to cause a visual double-bullet
        var content = "INTERACTIONS & REVEAL CLUES:\n• Go to Sam and say: 'Hello.'\n  Extra note on same bullet.";
        var result = RoundContentFormatter.FormatRound1Content(content);
        var liCount = result.Split("<li>", StringSplitOptions.RemoveEmptyEntries).Length - 1;
        Assert.Equal(1, liCount);
        Assert.DoesNotContain("\n", result);
    }

    [Fact]
    public void FormatRound1Content_MultipleBullets_ProducesCorrectLiCount()
    {
        var content = "INTERACTIONS & REVEAL CLUES:\n• First item\n• Second item\n• Third item";
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
        var content = "INTERACTIONS & REVEAL CLUES:\n• Reveal clue here\nCONCEALED SECRETS:\n• Secret one";
        var result = RoundContentFormatter.FormatRound1Content(content);
        Assert.Contains("section-title secrets-title", result);
        Assert.Contains("secrets-list", result);
        Assert.Contains("content-section concealed-secrets", result);
    }

    [Fact]
    public void FormatRound1Content_SecretBulletWithEmbeddedNewline_ProducesOneLiItem()
    {
        var content = "INTERACTIONS & REVEAL CLUES:\n• Clue one\nCONCEALED SECRETS:\n• Secret with\nnewline inside";
        var result = RoundContentFormatter.FormatRound1Content(content);
        var secretsSection = result.Substring(result.IndexOf("secrets-list"));
        var liCount = secretsSection.Split("<li>", StringSplitOptions.RemoveEmptyEntries).Length - 1;
        Assert.Equal(1, liCount);
        Assert.DoesNotContain("\n", result);
    }

    [Fact]
    public void FormatRound1Content_MultipleSpacesCollapsed()
    {
        var content = "INTERACTIONS & REVEAL CLUES:\n• Item   with   extra   spaces";
        var result = RoundContentFormatter.FormatRound1Content(content);
        Assert.DoesNotContain("  ", result);
    }

    [Fact]
    public void FormatRound1Content_NewlinesRemovedFromOutput()
    {
        var content = "INTERACTIONS & REVEAL CLUES:\n• Item one\n• Item two\nCONCEALED SECRETS:\n• Secret one";
        var result = RoundContentFormatter.FormatRound1Content(content);
        Assert.DoesNotContain("\n", result);
        Assert.DoesNotContain("\r", result);
    }
}
