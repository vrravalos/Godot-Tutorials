using Godot;
using System;

public partial class ParentMain2D : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
        GD.Print($"[{nameof(ParentMain2D)}] {this.Name}: Hello world, my children! - {timestamp}");
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
