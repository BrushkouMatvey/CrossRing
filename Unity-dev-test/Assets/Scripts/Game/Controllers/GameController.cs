using System.Collections;
using System.Collections.Generic;
using Entitas;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Globals gameSetup;
    private Systems _startSystems;
    private Systems _gameSystems;
    private Systems _resultSystems;
    private Services _services;

    private Contexts _contexts;
    // Start is called before the first frame update
    private void Start()
    {
        _contexts = Contexts.sharedInstance;
        _services = new Services(new UnityViewService());
        
        
        if(!_contexts.game.hasGlobals)
            _contexts.game.SetGlobals(gameSetup);
        if (!_contexts.input.hasGlobals)
            _contexts.input.SetGlobals(gameSetup);
        _gameSystems = CreateSystems(_contexts);
        _gameSystems.Initialize();
    }

    private void Update()
    {
        if (_contexts.game.GetEntities(GameMatcher.LoseAction).Length != 0)
        {
            foreach (var ge in _contexts.game.GetEntities())
                ge.isDestroy = true;
            foreach (var ie in _contexts.input.GetEntities())
                ie.Destroy();
            _gameSystems.Execute();
            _gameSystems.Execute();
            _gameSystems.DeactivateReactiveSystems();
            _gameSystems.TearDown();
            _gameSystems.ClearReactiveSystems();
            _contexts.Reset();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        _gameSystems.Execute();
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

