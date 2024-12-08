using Godot;

namespace DungeonRPG.Character.Player;

public partial class PlayerDash : Node
{
    [Export] private Timer _dashTimerNode;
    
    private Player _characterNode;
    public override void _Ready()
    {
        _characterNode = GetOwner<Player>();
        SetPhysicsProcess(false);
        SetProcessInput(false);
        _dashTimerNode.Timeout += HandleTimeout;
    }

    public override void _Notification(int what)
    {
        base._Notification(what);
        
        if (what == 5001)
        {
            _characterNode.AnimationPlayer.Play(Constants.AnimDashing);
            _dashTimerNode.Start();
            SetPhysicsProcess(true);
            SetProcessInput(true);
        }
        else if (what == 5002)
        {
            SetPhysicsProcess(false); 
        }
    }
    
    private void HandleTimeout()
    {
        _characterNode.StateMachineNode.SwitchState<PlayerIdle>();
    }
}