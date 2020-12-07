using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Event(EventTarget.Self)]
public class MoveComponent : IComponent
{
    public Vector2 direction;
    public float force;
}