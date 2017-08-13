using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;
[Game, Unique]
public class UIRootComponent : IComponent
{
    public RectTransform value;
}