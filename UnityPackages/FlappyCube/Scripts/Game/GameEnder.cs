using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameEnder : IDisposable, ITickable
{
    private const string ScoreKey = "Score";

    private readonly IGame game;
    private readonly IControls controls;
    private readonly DeathSignal deathSignal;
    private readonly ScoreLabelController scoreLabel;
    private readonly EndGameLabelController endGameLabel;

    private bool ended;

    public GameEnder(IGame game, IControls controls, DeathSignal deathSignal,
        ScoreLabelController scoreLabel, EndGameLabelController endGameLabel)
    {
        this.game = game;
        this.controls = controls;
        this.deathSignal = deathSignal + Restart;
        this.scoreLabel = scoreLabel;
        this.endGameLabel = endGameLabel;
    }

    private void Restart()
    {
        if (!PlayerPrefs.HasKey(ScoreKey) || PlayerPrefs.GetInt(ScoreKey) < game.Score)
        {
            PlayerPrefs.SetInt(ScoreKey, game.Score);
        }

        scoreLabel.View.Hide();
        endGameLabel.SetScore(game.Score, PlayerPrefs.GetInt(ScoreKey));
        ended = true;
    }

    public void Tick()
    {
        if (ended && controls.IsAction())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Dispose()
    {
        deathSignal.Unlisten(Restart);
    }
}
