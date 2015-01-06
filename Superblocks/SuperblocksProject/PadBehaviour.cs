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
    private const float MAX_SPEED = 0.25f;
    private const float INITIAL_SPEED = 0.09f;
    private const float MIN_SPEED = 0.05f;
    
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
      RigidBody2D body = Owner.FindComponent<RigidBody2D>();
      
      var keyboard = WaveServices.Input.KeyboardState;
      if (keyboard.Left == ButtonState.Pressed)
        currentState = PadState.Left;
      else if (keyboard.Right == ButtonState.Pressed)
        currentState = PadState.Right;
      
      Vector2 direction = Vector2.Zero;
      
      if (currentState == PadState.Idle)
        speed = INITIAL_SPEED;
      else
      {
        if (lastState == currentState)
          incrementSpeed (0.0002f);
        switch (currentState) {
          case PadState.Left:
            direction -= Vector2.UnitX * speed;
            break;
          case PadState.Right:
            direction += Vector2.UnitX * speed;
            break;
        }
        body.ApplyLinearImpulse (direction);
      }
      lastState = currentState;      
    }
    
    private void incrementSpeed(float diff)
    {
      speed += diff;
      if (speed > MAX_SPEED)
        speed = MAX_SPEED;
      if (speed < MIN_SPEED)
        speed = MIN_SPEED;
    }
  }
}
