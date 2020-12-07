using Entitas;

public class GameSystems : Feature  {
    public GameSystems(Contexts contexts): base("Game Systems")
    {
        Add(new ScoreSystem(contexts));
        Add(new InitLevelSystem(contexts));
        Add(new TimerSystem(contexts));
        Add(new SpawnBallSystem(contexts));
        Add(new AddMoveSystem(contexts));
        Add(new LoseCollisionSystem(contexts));
        Add(new HitCollisionSystem(contexts));
        
        // Add(new DestroySystem(contexts));

    }	
}