using Entitas;

public class ViewSystems : Feature  {
    public ViewSystems(Contexts contexts)
    {
        Add(new LoadPrefabSystem(contexts));
    }	
}