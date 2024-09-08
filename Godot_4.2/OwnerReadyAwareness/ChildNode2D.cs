using Godot;
using System;

public partial class ChildNode2D : Node2D
{
    public override void _Ready()
    {
        if (Owner.IsInsideTree())
        {
            OnParentNodeReady();
        }
        else
        {
            Owner.Ready += OnParentNodeReady;
        }
    }

    private void OnParentNodeReady()
    {
        Owner.Ready -= OnParentNodeReady;

        string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");   
        GD.Print($"[{nameof(ChildNode2D)}] {this.Name}: Hello dad {Owner.Name}.. I see you are ready! - {timestamp}");
    }
}
