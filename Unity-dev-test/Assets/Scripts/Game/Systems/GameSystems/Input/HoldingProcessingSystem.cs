using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class HoldingProcessingSystem : IExecuteSystem  {
	private Contexts _contexts;
    private IGroup<GameEntity> rings;
    private IGroup<InputEntity> inputs;

    public HoldingProcessingSystem(Contexts contexts) {
    	_contexts = contexts;
    }

	public void Execute() {
        rings = _contexts.game.GetGroup(GameMatcher.Ring);
        inputs = _contexts.input.GetGroup(InputMatcher.HoldingClick);
        foreach (var r in rings) {
            foreach (var i in inputs)
            {
                Vector2 direction = i.mousePosition.value - r.position.value;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                if (angle >-90+24 && angle < 90+24)
					r.ReplaceRotation(Quaternion.AngleAxis(angle, Vector3.forward), 200);
            }
        }
	}
}
