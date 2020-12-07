using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public sealed class ScoreComponent : IComponent
{
    public int value;
}