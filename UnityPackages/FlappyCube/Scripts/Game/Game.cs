using System;
using UnityEngine;
using Zenject;

public class Game : IGame, IDisposable, ITickable
{
    private const float Speed = 10;

    private readonly GameStartSignal gameStartSignal;
    private readonly AddScoreSignal addScoreSignal;
    private readonly DeathSignal deathSignal;

    private bool isStarted;
    private int score;
    private float distance;

    public bool IsStarted
    {
        get
        {
            return isStarted;
        }
    }

    public int Score
    {
        get
        {
            return score;
        }
    }

    public float Distance
    {
        get
        {
            return distance;
        }
    }
    
    public Game(GameStartSignal gameStartSignal, AddScoreSignal addScoreSignal, DeathSignal deathSignal)
    {
        this.gameStartSignal = gameStartSignal + Start;
        this.addScoreSignal = addScoreSignal + AddScore;
        this.deathSignal = deathSignal + Stop;
    }

    private void Start()
    {
        isStarted = true;
    }

    private void AddScore()
    {
        score++;
    }

    private void Stop()
    {
        isStarted = false;
    }

    public void Tick()
    {
        if (isStarted)
        {
            distance += Time.deltaTime * Speed;
        }
    }

    public void Dispose()
    {
        gameStartSignal.Unlisten(Start);
        addScoreSignal.Unlisten(AddScore);
        deathSignal.Unlisten(Stop);
    }
}
