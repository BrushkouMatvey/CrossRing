using System;
using System.Collections.Generic;
using Entitas;

public class LoadPrefabSystem : ReactiveSystem<GameEntity>, IInitializeSystem  {
    readonly Contexts _contexts;
    IViewService _viewService;

    public LoadPrefabSystem(Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
    }

    public void Initialize()
    {
        _viewService = _contexts.game.viewService.instance;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Resource);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasResource;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            _viewService.LoadPrefab(_contexts, e);
        }
    }
}