using System.Collections;
using System.Collections.Generic;
using Entitas;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Globals gameSetup;
    private Systems _startSystems;
    private Systems _gameSystems;
    private Systems _resultSystems;
    private Services _services;
    // Start is called before the first frame update
    private void Start()
    {
        var _contexts = Contexts.sharedInstance;
        _services = new Services(new UnityViewService());
        _contexts.game.SetGlobals(gameSetup);
        _contexts.input.SetGlobals(gameSetup);
        _gameSystems = CreateSystems(_contexts);
        _gameSystems.Initialize();
    }

    private void Update()
    {
        _gameSystems.Execute();
        _gameSystems.Cleanup();
    }

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Systems")
            .Add(new GameSystems(contexts))
            .Add(new EventSystems(contexts))
            .Add(new ServiceRegistrationSystems(contexts, _services))
            .Add(new ViewSystems(contexts))
            .Add(new InputSystems(contexts))
            .Add(new CommonSystems(contexts));

    }
}

