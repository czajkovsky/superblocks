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
  public class BorderBehaviour : Behavior
  {
    private enum BorderState { Pre, Iniatited, Destroyed };
    private BorderState currentState;
    private Border border;

    public BorderBehaviour (Border border)
    {
      this.currentState = BorderState.Pre;
      this.border = border;
    }

    protected override void Update(TimeSpan gameTime)
    {
      RigidBody2D body = Owner.FindComponent<RigidBody2D>();

      if (body != null && currentState == BorderState.Pre) {
        body.OnPhysic2DCollision += onCollision;
        currentState = BorderState.Iniatited;
      }
    }

    private void onCollision(object sender, Physic2DCollisionEventArgs args)
    {
      RigidBody2D ball = args.Body2DB;
      Vector2 impulse = Vector2.Zero;
      
      if (Math.Abs (ball.LinearVelocity.Y) < 0.3f) {
        float factor = 0.07f;
        float impulseY = factor * ((ball.LinearVelocity.Y > 0) ? 1f : -1f);
        float impulseX = changeX (ball.LinearVelocity.X, ball.LinearVelocity.Y, factor);
        impulse += Vector2.UnitX * impulseX;
        impulse += Vector2.UnitY * impulseY;
    
        float x = ball.LinearVelocity.X, y = ball.LinearVelocity.Y;
        float f1 = x * x + y * y;
        x += impulse.X;
        y += impulse.Y;
        float f2 = x * x + y * y;
        float episolon = 0.05f;
        if (Math.Abs (f1 - f2) < episolon)
          ball.ApplyLinearImpulse (impulse);
      }
    }
    
    private void quadraticEquation(float a, float b, float c, out float result1, out float result2)
    {
      float delta = b * b - 4 * a * c;
      result1 = (-1f * b - (float)Math.Sqrt((double)delta)) / 2 / a;
      result2 = (-1f * b + (float)Math.Sqrt((double)delta)) / 2 / a;
    }
    
    private float changeX(float x, float y, float factor)
    {
      float c = (float)Math.Pow ((double)(y + factor), 2) - y * y;
      float result1, result2;
      quadraticEquation(1f, 2f * x, c, out result1, out result2);
      Console.WriteLine ("x1: " + result1 + ", x2: " + result2);
      return (Math.Abs(result1) > Math.Abs(result2) ? result2 : result1);
    }
  }
}