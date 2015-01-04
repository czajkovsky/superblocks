#region Using Statements
using System;
using WaveEngine.Common.Input;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Services;
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
    
    [RequiredComponent]
    public Transform2D trans2D;
    
    private int direction, speed;
    private PadState currentState, lastState;
    private enum PadState { Idle, Left, Right };
    
    private Pad pad;
    
    public PadBehaviour (Pad pad)
    {
      this.direction = NONE;
      this.trans2D = null;
      this.currentState = PadState.Idle;
      this.speed = INITIAL_SPEED;
      this.pad = pad;
    }
    
    protected override void Update(TimeSpan gameTime)
    {
      currentState = PadState.Idle;

      var keyboard = WaveServices.Input.KeyboardState;
      if (keyboard.Left == ButtonState.Pressed)
        currentState = PadState.Left;
      else if (keyboard.Right == ButtonState.Pressed)
        currentState = PadState.Right;
      
      if (currentState != lastState)
        switch (currentState)
        {
          case PadState.Idle:
            direction = NONE;
            break;
          case PadState.Left:
            direction = LEFT;
            break;
          case PadState.Right:
            direction = RIGHT;
            break;
        }
      
      lastState = currentState;
      
      trans2D.X += direction * speed * (gameTime.Milliseconds / 10);
      
      if (trans2D.X < pad.Width / 2)
        trans2D.X = pad.Width / 2;
      else if (trans2D.X > WaveServices.Platform.ScreenWidth - pad.Width / 2)
        trans2D.X = WaveServices.Platform.ScreenWidth - pad.Width / 2;
    }
  }
}

