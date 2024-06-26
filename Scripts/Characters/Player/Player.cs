using ActionAdventureCS.Scripts.Constants;
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
            _animationPlayerNode = this.GetNode<AnimationPlayer>("AnimationPlayer");
            _spriteNode = this.GetNode<Sprite3D>("Sprite3D");
            //GD.Print(_animationPlayerNode.Name);
            _animationPlayerNode.Play(PlayerConstants.AnimIdle);
        }

        public override void _PhysicsProcess(float delta)
        {
            base._PhysicsProcess(delta);
            Vector3 velocity = new Vector3(_direction.x, 0, _direction.y) * 5;
            MoveAndSlide(velocity);
            if (velocity == Vector3.Zero)
                _animationPlayerNode.Play(PlayerConstants.AnimIdle);
            else
                _animationPlayerNode.Play(PlayerConstants.AnimMove);
            
            Flip();
        }

        public override void _Input(InputEvent @event)
        {
            base._Input(@event);
            _direction = Input.GetVector(PlayerConstants.InputMoveLeft, PlayerConstants.InputMoveRight,
                PlayerConstants.InputMoveForward, PlayerConstants.InputMoveBackward);
        }

        public void Flip()
        {
            bool isNotMovingHorizontally = _direction.x == 0;
            if (isNotMovingHorizontally)
                return;

            bool isMovingLeft = _direction.x < 0;
            _spriteNode.FlipH = isMovingLeft;
        }

        //  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
    }
}
