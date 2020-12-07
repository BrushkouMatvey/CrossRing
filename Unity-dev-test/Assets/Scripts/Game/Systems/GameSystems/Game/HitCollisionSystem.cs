using Entitas;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using UnityEngine;

public class HitCollisionSystem : ReactiveSystem<GameEntity> {
    private Contexts _contexts;

    public HitCollisionSystem (Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Collision));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCollision && entity.isHitCollisionFlag;
    }

    protected override void Execute(List<GameEntity> entities) {
        
        foreach (var e in entities)
        {     
            var score = _contexts.game.GetGroup(GameMatcher.Score).GetEntities().First();
            score.ReplaceScore(score.score.value + 1);
            // Debug.Log(score.score.value);
        }
    }
}