using Entitas;
using UnityEngine;

public class TimerSystem : IExecuteSystem  {
    private Contexts _contexts;
    private IGroup<GameEntity> runningTimers;
    public TimerSystem(Contexts contexts) {
        _contexts = contexts;
    }

    public void Execute() {
        var delta = Time.deltaTime;
        runningTimers = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Timer));
        
        foreach (var e in runningTimers.GetEntities())
        {
            if (e.isTimerState = true)
            {
                e.timer.remainingTime -= delta;
                if (e.timer.remainingTime <= 0.0f)
                {
                    e.timer.remainingTime = 0.0f;
                    e.isTimerState = false;
                }
            }
        }
		
    }
}