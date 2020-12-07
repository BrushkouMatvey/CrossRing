using Entitas;

public class InputSystems : Feature  {
    public InputSystems(Contexts contexts): base("Game Systems") 
    {
        Add(new HandlingInputSystem(contexts));
        Add(new HoldingProcessingSystem(contexts));
    }	
}