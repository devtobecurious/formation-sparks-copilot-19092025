using GameSessionApi.Models;
using Xunit;

namespace GameSessionApi.Tests;

public class GameSessionTests
{
    [Fact]
    public void GameSession_CanBeCreated_WithRequiredFields()
    {
        // Arrange & Act
        var session = new GameSession
        {
            Id = 1,
            GameTitle = "The Legend of Code",
            PlayerName = "Alice",
            StartTime = DateTime.UtcNow
        };

        // Assert
        Assert.Equal(1, session.Id);
        Assert.Equal("The Legend of Code", session.GameTitle);
        Assert.Equal("Alice", session.PlayerName);
        Assert.Equal(SessionStatus.Active, session.Status);
        Assert.Null(session.EndTime);
        Assert.Null(session.Score);
        Assert.Null(session.Notes);
    }

    [Fact]
    public void Duration_IsNull_WhenEndTimeIsNull()
    {
        // Arrange
        var session = new GameSession
        {
            GameTitle = "Test Game",
            PlayerName = "Bob",
            StartTime = DateTime.UtcNow,
            EndTime = null
        };

        // Act & Assert
        Assert.Null(session.Duration);
    }

    [Fact]
    public void Duration_IsCorrect_WhenEndTimeIsAfterStartTime()
    {
        // Arrange
        var start = DateTime.UtcNow;
        var end = start.AddHours(1).AddMinutes(15);

        var session = new GameSession
        {
            GameTitle = "Test Game",
            PlayerName = "Bob",
            StartTime = start,
            EndTime = end
        };

        // Act & Assert
        Assert.Equal(TimeSpan.FromMinutes(75), session.Duration);
    }

    [Fact]
    public void Duration_IsNull_WhenEndTimeIsBeforeStartTime()
    {
        // Arrange
        var start = DateTime.UtcNow;
        var end = start.AddMinutes(-30);

        var session = new GameSession
        {
            GameTitle = "Test Game",
            PlayerName = "Bob",
            StartTime = start,
            EndTime = end
        };

        // Act & Assert
        Assert.Null(session.Duration);
    }

    [Fact]
    public void Status_DefaultsToActive()
    {
        // Arrange & Act
        var session = new GameSession
        {
            GameTitle = "Test Game",
            PlayerName = "Charlie",
            StartTime = DateTime.UtcNow
        };

        // Assert
        Assert.Equal(SessionStatus.Active, session.Status);
    }

    [Fact]
    public void CanSetAndGetScoreAndNotes()
    {
        // Arrange & Act
        var session = new GameSession
        {
            GameTitle = "Test Game",
            PlayerName = "Dana",
            StartTime = DateTime.UtcNow,
            Score = 9001,
            Notes = "Personal best!"
        };

        // Assert
        Assert.Equal(9001, session.Score);
        Assert.Equal("Personal best!", session.Notes);
    }

    [Theory]
    [InlineData(SessionStatus.Active)]
    [InlineData(SessionStatus.Completed)]
    [InlineData(SessionStatus.Paused)]
    [InlineData(SessionStatus.Abandoned)]
    public void CanSetAndGetSessionStatus(SessionStatus status)
    {
        // Arrange & Act
        var session = new GameSession
        {
            GameTitle = "Test Game",
            PlayerName = "Eve",
            StartTime = DateTime.UtcNow,
            Status = status
        };

        // Assert
        Assert.Equal(status, session.Status);
    }

    [Fact]
    public void Duration_IsZero_WhenEndTimeEqualsStartTime()
    {
        // Arrange
        var startTime = DateTime.UtcNow;
        var session = new GameSession
        {
            GameTitle = "Test Game",
            PlayerName = "Frank",
            StartTime = startTime,
            EndTime = startTime
        };

        // Act & Assert
        Assert.Equal(TimeSpan.Zero, session.Duration);
    }
}