using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    public Globals globals;
    public RectTransform uiRoot;

    private Systems m_systems;
    // Use this for initialization
    void Start()
    {
        var contexts = Contexts.sharedInstance;
        contexts.game.SetGlobals(globals);
        contexts.game.SetUIRoot(uiRoot);
        m_systems = CreateSystems(contexts);
        m_systems.Initialize();
    }

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Game")
            .Add(new InitializeHexagonGridSystem(contexts, globals.gridSize))
           .Add(new CheckClickInputSystem(contexts))
            .Add(new AddHexagonViewSystem(contexts, globals.gridSize));
    }

    // Update is called once per frame
    void Update()
    {
        m_systems.Execute();
    }
}
