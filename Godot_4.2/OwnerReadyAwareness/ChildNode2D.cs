using Godot;
using System;

public partial class ChildNode2D : Node2D
{
    private string childNameID;

    public override async void _Ready()
    {
        // just for the example, we are safe here because we know the expected child name format
        childNameID = this.Name.ToString().Split('#')[1]; 

        // example for ChildNode2D#1 using async/await
        if (childNameID == "1")
        {
            if (!Owner.IsInsideTree())
            {
                await ToSignal(Owner, "ready");
            }

            PrintHelloMessage();
            return;
        }

        // example for ChildNode2D#2 using event
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
        PrintHelloMessage();
    }

    private void PrintHelloMessage()
    {
        string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
        GD.Print($"[{nameof(ChildNode2D)}] {this.Name}: Hello dad '{Owner.Name}'.. I see you are ready! - {timestamp}");
    }
}