#region Using Statements
using System;
using WaveEngine.Common.Input;
using WaveEngine.Common.Math;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Services;
using WaveEngine.Framework.Physics2D;
#endregion

namespace SuperblocksProject
{
  public class PadBehaviour : Behavior
  {
    private const float MAX_SPEED = 15f;
    private const float INITIAL_SPEED = 5f;
    private const float MIN_SPEED = 1.5f;
    
    private const int NONE = 0;
    private const int LEFT = -1;
    private const int RIGHT = 1;
        
    private PadState currentState, lastState;
    private enum PadState { Pre, Idle, Left, Right };
   
    private float impulse;
    
    public PadBehaviour (Pad pad)
    {
      this.currentState = PadState.Pre;
      this.impulse = INITIAL_SPEED;
    }
        
    protected override void Update(TimeSpan gameTime)
    {
      var keyboard = WaveServices.Input.KeyboardState;      
      Vector2 direction = Vector2.Zero;
      RigidBody2D body = Owner.FindComponent<RigidBody2D>();
      
      if (body != null && currentState == PadState.Pre) {
        body.OnPhysic2DCollision += onCollision;
        currentState = PadState.Idle;
      }
      
      currentState = PadState.Idle;
      if (keyboard.Left == ButtonState.Pressed)
        currentState = PadState.Left;
      else if (keyboard.Right == ButtonState.Pressed)
        currentState = PadState.Right;
      
      if (currentState == PadState.Idle) {
        impulse = INITIAL_SPEED;
        body.LinearVelocity = direction;
      }
      else {
        if (lastState == currentState)
          incrementImpuls (0.05f);
        switch (currentState) {
          case PadState.Left:
            direction -= Vector2.UnitX * impulse;
            break;
          case PadState.Right:
            direction += Vector2.UnitX * impulse;
            break;
        }
        body.LinearVelocity = direction;
      }
      lastState = currentState;      
    }
    
    private void onCollision(object sender, Physic2DCollisionEventArgs args)
    {
      if (args.Body2DB.Owner.Name.StartsWith("Ball")) {
        BallCollider collider = new BallCollider(args.Body2DB);
        collider.AdjustX ();
      }
    }
    
    private void incrementImpuls(float diff)
    {
      impulse += diff;
      if (impulse > MAX_SPEED)
        impulse = MAX_SPEED;
      if (impulse < MIN_SPEED)
        impulse = MIN_SPEED;
    }
  }
}
