using Godot;

namespace DungeonRPG.Character.Player;

public partial class PlayerRunning : Node
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
            var characterNode = GetOwner<Player>();
            characterNode.AnimationPlayer.Play(Constants.AnimRunning);
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
        if (_characterNode.MoveInput == Vector2.Zero)
        {
            _characterNode.StateMachineNode.SwitchState<PlayerIdle>();
            return;
        }
        
        // Set the velocity of the CharacterBody3D
        // It is a property of the sub class.
        _characterNode.Velocity = new Vector3(_characterNode.MoveInput.X, 0, _characterNode.MoveInput.Y);
        _characterNode.Velocity *= 5;

        // Not necessary to provide delta time when using MoveAndSlide
        // When this is called, delta time is already being used underneath the hood
        _characterNode.MoveAndSlide();
        
        _characterNode.Flip();
    }
    
    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(Constants.InputDash))
        {
            _characterNode.StateMachineNode.SwitchState<PlayerDash>();
        }
    }
}