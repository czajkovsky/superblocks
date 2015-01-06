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
    private const float MAX_SPEED = 8f;
    private const float INITIAL_SPEED = 0.09f;
    private const float MIN_SPEED = 1f;
    
    private const int NONE = 0;
    private const int LEFT = -1;
    private const int RIGHT = 1;
        
    private PadState currentState, lastState;
    private enum PadState { Idle, Left, Right };
   
    private float speed;
    
    public PadBehaviour (Pad pad)
    {
      this.currentState = PadState.Idle;
      this.speed = INITIAL_SPEED;
    }
        
    protected override void Update(TimeSpan gameTime)
    {
      currentState = PadState.Idle;
      RigidBody2D body = Owner.FindComponent<RigidBody2D> ();
      
      var keyboard = WaveServices.Input.KeyboardState;
      if (keyboard.Left == ButtonState.Pressed)
        currentState = PadState.Left;
      else if (keyboard.Right == ButtonState.Pressed)
        currentState = PadState.Right;
      
      Vector2 direction = Vector2.Zero;
      
      switch (currentState) {
        case PadState.Idle:
          speed = INITIAL_SPEED;
          break;
        case PadState.Left:
          if (lastState == currentState)
            incrementSpeed (0.0002f);
            direction -= Vector2.UnitX * speed;
          break;
        case PadState.Right:
          if (lastState == currentState)
            incrementSpeed (0.0002f);
          direction += Vector2.UnitX * speed;
          break;
      }
      
      if (direction != Vector2.Zero)
        body.ApplyLinearImpulse (direction);
      
      lastState = currentState;      
    }
    
    private void incrementSpeed(float diff)
    {
      speed += diff;
      Console.WriteLine (speed);
    }
  }
}

