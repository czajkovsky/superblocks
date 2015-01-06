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
    private const int MAX_SPEED = 8;
    private const int INITIAL_SPEED = 5;
    private const int MIN_SPEED = 3;
    
    private const int NONE = 0;
    private const int LEFT = -1;
    private const int RIGHT = 1;
        
    private PadState currentState, lastState;
    private enum PadState { Idle, Left, Right };
    
    private Pad pad;
    private Vector2 horizontalDirection;
    private float multiplicator = 2f;
    
    public PadBehaviour (Pad pad)
    {
      this.currentState = PadState.Idle;
      this.pad = pad;
    }
    
    protected override void Initialize()
    {
      base.Initialize();
      horizontalDirection = -Vector2.UnitX * multiplicator;
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
      if (currentState != lastState) {
        Console.WriteLine("time to change");
        switch (currentState) {
        case PadState.Idle:
          break;
        case PadState.Left:
          direction += horizontalDirection;
          break;
        case PadState.Right:
          direction -= horizontalDirection;
          break;
        }
      }
      
      if (direction != Vector2.Zero)
        body.ApplyLinearImpulse (direction);
      
      lastState = currentState;      
    }
  }
}

