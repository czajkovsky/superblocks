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
    private const float MAX_IMPULSE = 25f;
    private const float INITIAL_IMPULSE = 9f;
    private const float MIN_IMPULSE = 5f;
    
    private const int NONE = 0;
    private const int LEFT = -1;
    private const int RIGHT = 1;
        
    private PadState currentState, lastState;
    private enum PadState { Idle, Left, Right };
   
    private float impulse;
    
    public PadBehaviour (Pad pad)
    {
      this.currentState = PadState.Idle;
      this.impulse = INITIAL_IMPULSE;
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
        impulse = INITIAL_IMPULSE;
      else {
        if (lastState == currentState)
          incrementImpuls (0.02f);
        switch (currentState) {
          case PadState.Left:
            direction -= Vector2.UnitX * impulse;
            break;
          case PadState.Right:
            direction += Vector2.UnitX * impulse;
            break;
        }
        body.ApplyLinearImpulse (direction);
      }
      lastState = currentState;      
    }
    
    private void incrementImpuls(float diff)
    {
      impulse += diff;
      if (impulse > MAX_IMPULSE)
        impulse = MAX_IMPULSE;
      if (impulse < MIN_IMPULSE)
        impulse = MIN_IMPULSE;
    }
  }
}
