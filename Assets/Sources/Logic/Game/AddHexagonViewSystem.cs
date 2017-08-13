using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.UI;
public class AddHexagonViewSystem : ReactiveSystem<GameEntity>
{
    private Contexts m_contexts;
    private IntVector2 m_gridSize;
    public AddHexagonViewSystem(Contexts contexts, IntVector2 gridSize) : base(contexts.game)
    {
        m_contexts = contexts;
        m_gridSize = gridSize;
    }

    protected override void Execute(List<GameEntity> entities)
    {

        var hexagonPrefab = m_contexts.game.globals.value.hexagonPrefab;
        var uiRoot = m_contexts.game.uIRoot.value;
        var globals = m_contexts.game.globals.value;
        foreach (var entity in entities)
        {
            var hexagon = UnityEngine.Object.Instantiate(hexagonPrefab, uiRoot);
            entity.AddView(hexagon);
            var rectTransform = hexagon.GetComponent<RectTransform>();
            var pos = new Vector2((entity.position.value.x - m_gridSize.x / 2f) * globals.widthSpacing, (entity.position.value.y - m_gridSize.y / 2f) * globals.heightSpacing);
            var isEven = entity.position.value.x % 2 == 0;
            var image = hexagon.GetComponent<Image>();
            if (isEven)
            {
                image.color = globals.evenColor;
            }
            else
            {
                pos.y += globals.heightOffset;
                image.color = globals.oddColor;
            }
            rectTransform.anchoredPosition = pos;
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isHexagon && entity.hasPosition;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Hexagon, GameMatcher.Position));
    }
}
