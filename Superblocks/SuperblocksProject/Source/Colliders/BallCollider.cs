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
  public class BallCollider
  {
    private RigidBody2D body;
    private const float correlationFactorY = 0.11f;
    
    public BallCollider (RigidBody2D body)
    {
      this.body = body;
    }
    
    public void AdjustY()
    {
      if (Math.Abs (body.LinearVelocity.Y) > 0.3f) 
        return;
      Vector2 impulse = correlationYImpulse();
      if (correlationImpulseInRange (impulse))
        body.ApplyLinearImpulse (impulse);
    }
    
    private Vector2 correlationYImpulse()
    {
      Vector2 impulse = Vector2.Zero;
      float impulseY = correlationFactorY * ((body.LinearVelocity.Y > 0) ? 1f : -1f);
      float impulseX = correlateX (body.LinearVelocity.X, body.LinearVelocity.Y, correlationFactorY);
      
      impulse += Vector2.UnitX * impulseX;
      impulse += Vector2.UnitY * impulseY;
      return impulse;
    }
    
    private float correlateX(float x, float y, float factor)
    {
      float c = (float)Math.Pow ((double)(y + factor), 2) - y * y;
      float result1, result2;
      MathHelpers.SquareEquation(1f, 2f * x, c, out result1, out result2);
      return (Math.Abs(result1) > Math.Abs(result2) ? result2 : result1);
    }
    
    private bool correlationImpulseInRange(Vector2 impulse)
    {
      float x = body.LinearVelocity.X, y = body.LinearVelocity.Y;
      float v1 = MathHelpers.VectorLength (x, y);
      float v2 = MathHelpers.VectorLength (x + impulse.X, y + impulse.Y);
      return (MathHelpers.EpsilonEqual (v1, v2));
    }
  }
}

