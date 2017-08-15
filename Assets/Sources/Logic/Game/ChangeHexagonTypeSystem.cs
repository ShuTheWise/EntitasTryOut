using Entitas;
using System.Collections.Generic;
public class ChangeHexagonTypeSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public ChangeHexagonTypeSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var item in entities)
        {
            var hexes = _contexts.game.GetEntitiesWithPosition(item.position.value);
            foreach (var hex in hexes)
            {
                if (hex.hasHexagonType)
                {
                    var newType = (int)hex.hexagonType.value;
                    newType++;
                    newType %= 5;
                    hex.ReplaceHexagonType((HexagonType)newType);
                }
            }
            item.Destroy();
            //_context.game.DestroyEntity(item);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isClickInput && entity.hasPosition && entity.hasButtonNumber && entity.buttonNumber.value == 0;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ClickInput);
    }
}

