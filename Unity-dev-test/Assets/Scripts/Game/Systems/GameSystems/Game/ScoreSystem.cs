using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ScoreSystem : IInitializeSystem
{
    readonly Contexts _contexts;

    public ScoreSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var scoreEntity = _contexts.game.CreateEntity();
        scoreEntity.AddResource(_contexts.game.globals.value.scorePrefab);
        scoreEntity.ReplacePosition(new Vector2(0, 2));
        scoreEntity.ReplaceScore(0);
    }
}