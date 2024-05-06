using Godot;

namespace ActionAdventureCS.Scripts.Characters.Player
{
    public class Player : KinematicBody
    {
        // [ExportGroup("Required Nodes")]
        private AnimationPlayer _animationPlayerNode;
        private Sprite3D _spriteNode;
        
        private Vector2 _direction = new Vector2();
        
        public override void _Ready()
        {
            base._Ready();
            //int index = this.GetChildCount();
            //_animationPlayerNode = this.GetChild<AnimationPlayer>();
            _animationPlayerNode = this.GetNode<AnimationPlayer>("AnimationPlayer");
            GD.Print(_animationPlayerNode.Name);
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
