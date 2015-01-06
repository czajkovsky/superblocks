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
  public class BallBehaviour : Behavior
  {
    private BallState currentState;
    private enum BallState { Idle, Running };
    private Vector2 initialVector, initialSpeed;

    public BallBehaviour ()
    {
      this.currentState = BallState.Idle;
    }
    
    protected override void Initialize() {
      initialVector += Vector2.UnitX * 1f;
      Console.WriteLine (initialVector);
    }
         
    protected override void Update(TimeSpan gameTime)
    {
      RigidBody2D body = Owner.FindComponent<RigidBody2D>();
      
      if ((body != null) && (currentState == BallState.Idle)) {
        body.ApplyLinearImpulse (initialVector);
        initialSpeed = body.LinearVelocity;
        currentState = BallState.Running;
      }
      if (currentState == BallState.Running) {
        Vector2 change = Vector2.Zero;
         change += Vector2.UnitX * changeSpeedOnAxis(body.LinearVelocity.X);
         body.LinearVelocity = change;
        
      }
      
      Console.WriteLine (body.LinearVelocity);
    }
    
    private float changeSpeedOnAxis(float current)
    {
      float speed = 3f;
      if (current < 0)
        speed *= -1f;
      
      return speed;
    }
  }
}

