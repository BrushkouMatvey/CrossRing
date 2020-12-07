using Entitas;

public class MainMenuInitSystem : IInitializeSystem  {
	private Contexts _contexts;

    public MainMenuInitSystem(Contexts contexts) {
    	_contexts = contexts;
    }

	public void Initialize() {
		// Initialization code here
		
	}		
}