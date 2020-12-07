using Entitas;
using Entitas.Unity;
using TMPro;
using UnityEngine;

public class PositionListener: MonoBehaviour, IEventListener, IPositionListener
{
    private GameEntity _entity;
    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddPositionListener(this);
        if (_entity.hasPosition) transform.position = _entity.position.value;
    }

    public void OnPosition(GameEntity entity, Vector2 value) => transform.position = value;
}