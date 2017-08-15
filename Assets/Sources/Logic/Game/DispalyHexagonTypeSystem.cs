using Entitas;
using System.Collections.Generic;
public class DispalyHexagonTypeSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public DispalyHexagonTypeSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        UnityEngine.Debug.Log("Creating " + nameof(DispalyHexagonTypeSystem));
    }

    protected override void Execute(List<GameEntity> entities)
    {
        UnityEngine.Debug.Log("Executing " + nameof(DispalyHexagonTypeSystem));
    
        foreach (var item in entities)
        {
         //   item.hexagonType.value = HexagonType.Empty;
            item.view.value.GetComponent<HexagonViewBehaviour>().SetType(item.hexagonType.value);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView && entity.hasHexagonType;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.HexagonType);
    }
}

