using Entitas;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnBallSystem : IExecuteSystem  {
	private Contexts _contexts;  
	private List<Vector2> spawnCoordinates;
	private GameEntity _timer;
	private int _score;
	public SpawnBallSystem(Contexts contexts) {
    	_contexts = contexts;
        Camera camera = Camera.main;
        Vector2 screenTopRight = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        Vector2 screenTopLeft = camera.ViewportToWorldPoint(new Vector3(1, 0, camera.nearClipPlane));
        Vector2 screenBottomRight = camera.ViewportToWorldPoint(new Vector3(0, 1, camera.nearClipPlane));
        Vector2 screenBottomLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        Vector2 screenBottomCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, 0));
        Vector2 screenTopCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height));
        
        spawnCoordinates = new List<Vector2>();
        spawnCoordinates.Add(screenTopRight);
        spawnCoordinates.Add(screenTopLeft);
        spawnCoordinates.Add(screenBottomRight);
        spawnCoordinates.Add(screenBottomLeft);
        spawnCoordinates.Add(screenBottomCenter);
        spawnCoordinates.Add(screenTopCenter);
    }

	public void Execute()
	{
		if (_contexts.game.GetGroup(GameMatcher.Timer).GetEntities().Length != 0 &&
		    _contexts.game.GetGroup(GameMatcher.Score).GetEntities().Length != 0)
		{
			_timer = _contexts.game.GetGroup(GameMatcher.Timer).GetEntities().First();
			_score = _contexts.game.GetGroup(GameMatcher.Score).GetEntities().First().score.value;
			if (_timer.isTimerState == false)
			{
				var ballEntity = _contexts.game.CreateEntity();
				ballEntity.isBall = true;

				var random = new System.Random();
				var ballStartPosition = spawnCoordinates[random.Next(spawnCoordinates.Count)];
				ballEntity.AddPosition(ballStartPosition);
				ballEntity.ReplaceResource(_contexts.game.globals.value.ballPrefab);

				float timerValue;
				if (_score > 25)
				{
					timerValue = 0.5f;
					_timer.ReplaceTimer(timerValue);
				}
				else
				{
					int dif = _score / 5;
					timerValue = 1.6f - (float) (dif * 0.2);
					_timer.ReplaceTimer(timerValue);
				}
				_timer.isTimerState = true;
			}
		}
		
	}
}
