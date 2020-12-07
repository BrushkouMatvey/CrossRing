using Entitas;
using Entitas.Unity;
using UnityEngine;
using UnityEngine.UI;

public class RotationListener: MonoBehaviour, IEventListener, IRotationListener
{
    private GameEntity _entity;
    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddRotationListener(this);
    }
    public void OnRotation(GameEntity entity, Quaternion quaternion, float speed)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, quaternion, speed);
    }
}