using Entitas;
using UnityEngine;

public class HandlingInputSystem : IInitializeSystem, IExecuteSystem  {
    private InputContext _inputContexts;
    private GameContext _gameContexts;
    private InputEntity _clickEntity;
    private GameEntity _gameInputStateEntity;
    public HandlingInputSystem(Contexts contexts) {
        _gameContexts = contexts.game;
        _inputContexts = contexts.input;
    }
    
    public void Initialize()
    {
        _clickEntity = _inputContexts.CreateEntity();
        _gameInputStateEntity = _gameContexts.CreateEntity();
    }
    
    public void Execute() {
        if (InputService.isScreenHoldingClick())
        {
            _clickEntity.ReplaceMousePosition(InputService.clickPosition);
            _clickEntity.isHoldingClick = true;
        }
        else
            _clickEntity.isHoldingClick = false;
    }
}