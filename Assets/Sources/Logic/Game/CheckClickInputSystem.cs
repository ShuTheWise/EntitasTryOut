using Entitas;
using UnityEngine;
using System.Linq;
public class ClickInputSystem : IExecuteSystem
{
    private Contexts m_contexts;
    private IGroup<GameEntity> m_hexesGroup;

    public ClickInputSystem(Contexts contexts)
    {
        m_contexts = contexts;
        m_hexesGroup = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Hexagon, GameMatcher.View));
    }

    public void Execute()
    {
        for (int i = 0; i < 2; i++)
        {
            if (Input.GetMouseButtonDown(i))
            {
                var hexes = m_hexesGroup.GetEntities();
                var mousePos = Input.mousePosition;


                var clickHex = hexes
                    .OrderBy(x => (x.view.value.transform.position - mousePos).sqrMagnitude)
                    .FirstOrDefault(x => (x.view.value.transform.position - mousePos).magnitude < m_contexts.game.globals.value.clickRadius);
                Debug.Log(clickHex);
                if (clickHex != null)
                {
                    var entity = m_contexts.game.CreateEntity();
                    entity.isClickInput = true;
                    entity.AddPosition(clickHex.position.value);
                    entity.AddButtonNumber(i);
                    //entity.add
                }

            }
        }
    }
}
