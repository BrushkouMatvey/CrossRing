using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Event(EventTarget.Self)]
public class RotationComponent : IComponent
{
    public Quaternion quaternion;
    public float speed;
}