using Entitas;
using System.Collections.Generic;
public class RotateHexagonSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public RotateHexagonSystem(Contexts context) : base(context.game)
    {
        _contexts = context;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        UnityEngine.Debug.Log("Executing " + nameof(RotateHexagonSystem));
        foreach (var entity in entities)
        {
            var hexagons = _contexts.game.GetEntitiesWithPosition(entity.position.value);
            foreach (var hex in hexagons)
            {
                if (hex.hasHexagonRotation)
                {
                    UnityEngine.Debug.Log("Changing rotation");
                    var newRot = hex.hexagonRotation.value;
                    newRot++;
                    newRot %= 6;
                    hex.ReplaceHexagonRotation(newRot);
                }
//                hex.Destroy
            //    hex.Destroy();
            }
                entity.isDestroyed = true;
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasButtonNumber && entity.buttonNumber.value == 1;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.ClickInput, GameMatcher.Position, GameMatcher.ButtonNumber));
    }
}

