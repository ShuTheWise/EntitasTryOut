using Entitas;
using UnityEngine;
public class InitializeHexagonGridSystem : IInitializeSystem
{
    private Contexts m_contexts;
    private IntVector2 m_gridSize;
    public InitializeHexagonGridSystem(Contexts contexts, IntVector2 gridSize)
    {
        m_contexts = contexts;
        m_gridSize = gridSize;       
    }
    public void Initialize()
    {
        Debug.Log($"Starting a {nameof(InitializeHexagonGridSystem)}");

        for (int i = 0; i < m_gridSize.x; i++)
        {
            for (int j = 0; j < m_gridSize.y; j++)
            {
                var entity = m_contexts.game.CreateEntity();
                entity.AddPosition(new IntVector2(i,j));
                entity.isHexagon = true;
                entity.AddHexagonType(HexagonType.Empty);
                entity.AddHexagonRotation(0);
            }
        }
    }
}
