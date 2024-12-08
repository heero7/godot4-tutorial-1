using Godot;

namespace DungeonRPG.Character.Player;

public partial class PlayerIdle : Node
{
    private Player _characterNode;
    public override void _Ready()
    {
        _characterNode = GetOwner<Player>();
        SetPhysicsProcess(false);
        SetProcessInput(false);
    }

    public override void _Notification(int what)
    {
        base._Notification(what);
        
        if (what == 5001)
        {
            _characterNode.AnimationPlayer.Play(Constants.AnimIdle);
            SetPhysicsProcess(true);
            SetProcessInput(true);
        }
        else if (what == 5002)
        {
            SetPhysicsProcess(false); 
            SetProcessInput(false);
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        if (_characterNode.MoveInput != Vector2.Zero)
        {
            _characterNode.StateMachineNode.SwitchState<PlayerRunning>();
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(Constants.InputDash))
        {
            _characterNode.StateMachineNode.SwitchState<PlayerDash>();
        }
    }
}