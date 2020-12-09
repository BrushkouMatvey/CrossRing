using Entitas;
using UnityEngine;

public class HandlingInputSystem : IInitializeSystem, IExecuteSystem  {
    private InputContext _inputContexts;
    private GameContext _gameContexts;
    private InputEntity _clickEntity;
    private GameEntity _gameInputStateEntity;
    private InputService _input;
    public HandlingInputSystem(Contexts contexts) {
        _gameContexts = contexts.game;
        _inputContexts = contexts.input;
        _input = new InputService();
    }
    
    public void Initialize()
    {
        _clickEntity = _inputContexts.CreateEntity();
        _clickEntity.isMouse = true;
        _gameInputStateEntity = _gameContexts.CreateEntity();
    }
    
    public void Execute() {
        if (_inputContexts.GetEntities(InputMatcher.Mouse).Length != 0)
        {
            if (_input.IsScreenHoldingClick())
            {
                _clickEntity.ReplaceMousePosition(InputService.clickPosition);
                _clickEntity.isHoldingClick = true;
            }
            else
                _clickEntity.isHoldingClick = false;
        }
    }
}