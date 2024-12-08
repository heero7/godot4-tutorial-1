using Godot;

namespace DungeonRPG.Character;

public partial class StateMachine : Node
{
    [Export] private Node _current;
    [Export] private Node[] _states;

    public override void _Ready()
    {
        _current.Notification(5001);
    }

    public void SwitchState<T>()
    {
        Node nextState = null;

        foreach (var state in _states)
        {
            if (state is T)
            {
                nextState = state;
            }
        }

        if (nextState == null) { return; }

        _current.Notification(5002);
        _current = nextState;
        _current.Notification(5001);
    }
}