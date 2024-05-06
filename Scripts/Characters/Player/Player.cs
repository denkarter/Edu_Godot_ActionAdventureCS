using Godot;

namespace ActionAdventureCS.Scripts.Characters.Player
{
    public class Player : KinematicBody
    {
        private Vector2 _direction = new Vector2();
        // Declare member variables here. Examples:
        // private int a = 2;
        // private string b = "text";

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
        
        }

        public override void _PhysicsProcess(float delta)
        {
            base._PhysicsProcess(delta);
            Vector3 velocity = new Vector3(_direction.x, 0, _direction.y) * 5;
            MoveAndSlide(velocity);
        }

        public override void _Input(InputEvent @event)
        {
            base._Input(@event);
            _direction = Input.GetVector("MoveLeft", "MoveRight", "MoveForward", "MoveBackward");
        }

        //  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
    }
}
