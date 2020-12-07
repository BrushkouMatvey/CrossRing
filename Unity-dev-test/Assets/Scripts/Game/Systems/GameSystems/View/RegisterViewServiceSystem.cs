using Entitas;

public class RegisterViewServiceSystem : IInitializeSystem  {
    private Contexts _contexts;
    private IViewService _viewService;
    public RegisterViewServiceSystem(Contexts contexts, IViewService viewService) {
        _contexts = contexts;
        _viewService = viewService;
    }

    public void Initialize() {
        _contexts.game.ReplaceViewService(_viewService);
    }		
}