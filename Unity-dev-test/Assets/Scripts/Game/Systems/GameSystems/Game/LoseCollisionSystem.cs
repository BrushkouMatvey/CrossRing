using Entitas;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollisionSystem : ReactiveSystem<GameEntity> {
    private Contexts _contexts;

	public LoseCollisionSystem (Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
		return context.CreateCollector(GameMatcher.Collision);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasCollision && entity.isBorderCollisionFlag;
	}

	protected override void Execute(List<GameEntity> entities) {

		foreach (var e in entities) {
			var first= e.collision.first;
			var second = e.collision.second;
			first.isDestroy = true;
			//_contexts.game.DestroyAllEntities();
			//Clear();
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}

	public void Clear()
	{
		foreach (var enGame in _contexts.input.GetGroup(InputMatcher.Globals))
		{
			enGame.Destroy();
		}
	}
}