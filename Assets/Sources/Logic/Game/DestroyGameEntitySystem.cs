using Entitas;
using System;
using System.Collections.Generic;

public class DestroyGameEntitySystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public DestroyGameEntitySystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }
    protected override bool Filter(GameEntity entity)
    {
        return entity.isDestroyed;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        UnityEngine.Debug.Log($"Executing {nameof(DestroyGameEntitySystem)}");
        foreach (var entity in entities)
        {
            entity.Destroy();
        }
    }
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Destroyed);
    }
}