using Entitas.Unity;
using UnityEngine;

public class EmitCollisionController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        var firstLink = gameObject.GetEntityLink().entity;
        var secondLink = other.gameObject.GetEntityLink().entity;
        var entity = Contexts.sharedInstance.game.CreateEntity();
        entity.isBorderCollisionFlag = true;
        entity.AddCollision((GameEntity)firstLink,(GameEntity)secondLink);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var firstLink = gameObject.GetEntityLink().entity;
        var secondLink = other.gameObject.GetEntityLink().entity;
        var entity = Contexts.sharedInstance.game.CreateEntity();
        entity.isHitCollisionFlag = true;
        entity.AddCollision((GameEntity)firstLink,(GameEntity)secondLink);
    }
}
