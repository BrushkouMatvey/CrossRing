using Entitas;

public class LoseMenuInitSystem : IInitializeSystem  {
	private Contexts _contexts;

    public LoseMenuInitSystem(Contexts contexts) {
    	_contexts = contexts;
    }

	public void Initialize()
	{
		var entity = _contexts.game.CreateEntity();
		}		
}