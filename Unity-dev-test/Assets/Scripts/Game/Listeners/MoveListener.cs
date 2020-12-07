using Entitas;
using Entitas.Unity;
using UnityEngine;

public class MoveListener: MonoBehaviour, IEventListener, IMoveListener
{
    private GameEntity _entity;
    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddMoveListener(this);
    }

    public void OnMove(GameEntity entity, Vector2 direction, float force)
    {
        var r = GetComponent<Rigidbody2D>();
        r.AddForce(direction * force);
    }
}