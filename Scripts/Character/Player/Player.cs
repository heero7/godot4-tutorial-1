using Godot;

namespace DungeonRPG.Character.Player;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] private AnimationPlayer _animationPlayerNode;
    [Export] private Sprite3D _spriteNode;
    [Export] private StateMachine _stateMachineNode;

    public AnimationPlayer AnimationPlayer => _animationPlayerNode;

    public Vector2 MoveInput { get; private set; }
    
    public StateMachine StateMachineNode => _stateMachineNode;

    private Node _idle;
    private Node _running;

    // _Ready = Start
    public override void _Ready()
    {
        // This method (_Ready) is similar to the Start method in Unity.
        
        // GD.Print($"Name of {_animationPlayerNode.Name}");
        // GD.Print($"Name of {_spriteNode.Name}");
        // GD.Print($"{Name} is ready!");
        //
        // _idle = GetNode<PlayerIdle>("Idle");
        // _running = GetNode<PlayerRunning>("Running");
        //
        // GD.Print($"{_idle == null}?");
        base._Ready();
    }

    // _PhysicsProcess = FixedUpdate
    public override void _PhysicsProcess(double delta)
    {
    }

    // _Process = Update
    public override void _Process(double delta)
    {
        base._Process(delta);
    }

    public override void _Input(InputEvent @event)
    {
        // Each string corresponds to the input defined in the project settings.
        // You can define them however you want.
        // In this example:
        // MoveLeft = Left Dpad, so when that is pressed the value -1 is shown when this is pressed.
        MoveInput = Input.GetVector(
            Constants.InputMoveLeft,
            Constants.InputMoveRight,
            Constants.InputMoveForward,
            Constants.InputMoveBackward
        );

        // if (MoveInput != Vector2.Zero)
        // {
        //     _idle.SetProcess(false);
        //     _running.SetProcess(true);
        // }
        // else
        // {
        //     _idle.SetProcess(true);
        //     _running.SetProcess(false);
        // }
    }


    public void Flip()
    {
        var directionX = Mathf.Sign(MoveInput.X);

        if (directionX == 1)
        {
            _spriteNode.FlipH = false;
        } else if (directionX == -1)
        {
            _spriteNode.FlipH = true;
        }
    }
}