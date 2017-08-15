//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ButtonNumberComponent buttonNumber { get { return (ButtonNumberComponent)GetComponent(GameComponentsLookup.ButtonNumber); } }
    public bool hasButtonNumber { get { return HasComponent(GameComponentsLookup.ButtonNumber); } }

    public void AddButtonNumber(int newValue) {
        var index = GameComponentsLookup.ButtonNumber;
        var component = CreateComponent<ButtonNumberComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceButtonNumber(int newValue) {
        var index = GameComponentsLookup.ButtonNumber;
        var component = CreateComponent<ButtonNumberComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveButtonNumber() {
        RemoveComponent(GameComponentsLookup.ButtonNumber);
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

    static Entitas.IMatcher<GameEntity> _matcherButtonNumber;

    public static Entitas.IMatcher<GameEntity> ButtonNumber {
        get {
            if (_matcherButtonNumber == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ButtonNumber);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherButtonNumber = matcher;
            }

            return _matcherButtonNumber;
        }
    }
}
