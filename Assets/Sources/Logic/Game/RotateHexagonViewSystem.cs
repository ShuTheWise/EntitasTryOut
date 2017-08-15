using Entitas;
using System;
using System.Collections.Generic;
using UnityEngine;

public class RotateHexagonViewSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public RotateHexagonViewSystem(Contexts context) : base(context.game)
    {
        _contexts = context;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var item in entities)
        {
            var angle = item.hexagonRotation.value *- 60f;
            item.view.value.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasHexagonRotation && entity.hasView;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.HexagonRotation);
    }
}

