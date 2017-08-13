using Entitas;
using UnityEngine;
using System.Linq;
public class CheckClickInputSystem : IExecuteSystem
{
    private Contexts m_contexts;
    private IGroup<GameEntity> m_hexesGroup;

    public CheckClickInputSystem(Contexts contexts)
    {
        m_contexts = contexts;
        m_hexesGroup = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Hexagon, GameMatcher.View));
    }

    public void Execute()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var hexes = m_hexesGroup.GetEntities();
            var mousePos = Input.mousePosition;

           
            var clickHex = hexes
                .OrderBy(x => (x.view.value.transform.position - mousePos).sqrMagnitude)
                .FirstOrDefault(x => (x.view.value.transform.position - mousePos).magnitude < m_contexts.game.globals.value.clickRadius);
            Debug.Log(clickHex);
        }
    }
}