using Entitas;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AddMoveSystem : ReactiveSystem<GameEntity> {
    private Contexts _contexts;
    private IGroup<GameEntity> ringGroup;

	public AddMoveSystem (Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
        ringGroup = _contexts.game.GetGroup(GameMatcher.Ring);
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
		return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Ball, GameMatcher.MoveListener));
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isBall && entity.hasMoveListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		var ring = ringGroup.GetEntities().First();
		foreach (var ball in entities) {
			var direction =  ring.position.value - ball.position.value;
			direction.Normalize();
			ball.ReplaceMove(direction, 170);
		}
	}
}