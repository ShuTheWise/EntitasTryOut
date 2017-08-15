//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public HexagonTypeComponent hexagonType { get { return (HexagonTypeComponent)GetComponent(GameComponentsLookup.HexagonType); } }
    public bool hasHexagonType { get { return HasComponent(GameComponentsLookup.HexagonType); } }

    public void AddHexagonType(HexagonType newValue) {
        var index = GameComponentsLookup.HexagonType;
        var component = CreateComponent<HexagonTypeComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceHexagonType(HexagonType newValue) {
        var index = GameComponentsLookup.HexagonType;
        var component = CreateComponent<HexagonTypeComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveHexagonType() {
        RemoveComponent(GameComponentsLookup.HexagonType);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherHexagonType;

    public static Entitas.IMatcher<GameEntity> HexagonType {
        get {
            if (_matcherHexagonType == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.HexagonType);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHexagonType = matcher;
            }

            return _matcherHexagonType;
        }
    }
}