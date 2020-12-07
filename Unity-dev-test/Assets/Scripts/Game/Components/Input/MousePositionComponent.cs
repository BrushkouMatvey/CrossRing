using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Input]
public class MousePositionComponent : IComponent
{
    public Vector2 value;
}