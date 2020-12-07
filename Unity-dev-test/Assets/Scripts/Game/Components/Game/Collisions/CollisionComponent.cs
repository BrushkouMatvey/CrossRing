using Entitas;
using UnityEngine;

[Game]
public class CollisionComponent : IComponent
{
    public GameEntity first;
    public GameEntity second;
}