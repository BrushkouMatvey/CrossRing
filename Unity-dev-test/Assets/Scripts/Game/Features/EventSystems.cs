using Entitas;

public class EventSystems : Feature  {
    public EventSystems(Contexts contexts) {
        //Listeners
        Add(new RotationEventSystem(contexts));
        Add(new PositionEventSystem(contexts));
        Add(new MoveEventSystem(contexts));
        Add(new DestroyEventSystem(contexts));
        Add(new ScoreEventSystem(contexts));
    }	
}