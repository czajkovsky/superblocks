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
    private Vector2 initialVector;

    public BallBehaviour ()
    {
      this.currentState = BallState.Idle;
    }
    
    protected override void Initialize() {
      System.Random random = new System.Random ();
      float valX = 0.1f + (float)random.Next(0, 10) / 100f;
      float dirX = (random.Next(0, 3) > 1) ? -1f : 1f;
      float valY = (float)Math.Sqrt(Math.Pow(0.3, 2) - Math.Pow((double)valX, 2));
      initialVector += Vector2.UnitX * valX * dirX;
      initialVector += Vector2.UnitY * valY * -1f;
    }
         
    protected override void Update(TimeSpan gameTime)
    {
      RigidBody2D body = Owner.FindComponent<RigidBody2D>();
      
      if (body != null) {
        if (currentState == BallState.Idle) {
          body.ApplyLinearImpulse (initialVector);
          initialVector.X = body.LinearVelocity.X;
          initialVector.Y = body.LinearVelocity.Y;
          currentState = BallState.Running;
        } else if (currentState == BallState.Running) {
          adjustSpeed(body);
        }
      }
    }
    
    private void adjustSpeed(RigidBody2D body)
    {
      float currentSpeed = MathHelpers.VectorLength (body.LinearVelocity.X, body.LinearVelocity.Y);
      float initialSpeed = MathHelpers.VectorLength (initialVector.X, initialVector.Y);
      float factor =  initialSpeed / currentSpeed;
      Vector2 impulse = Vector2.Zero;
      impulse.X = factor * body.LinearVelocity.X;
      impulse.Y = factor * body.LinearVelocity.Y;
      body.LinearVelocity = impulse;
    }
  }
}

