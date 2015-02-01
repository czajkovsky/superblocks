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
    private const float correlationFactorX = 0.2f;
    
    public BallCollider (RigidBody2D body)
    {
      this.body = body;
    }
    
    public void AdjustY()
    {
      if (Math.Abs (body.LinearVelocity.Y) > 0.3f) 
        return;
      Vector2 impulse = correlationYImpulse();
      if (correlationImpulseInRange(impulse))
        body.ApplyLinearImpulse(impulse);
    }
    
    public void AdjustX()
    {
      if (Math.Abs (body.LinearVelocity.X) > 0.03f) 
        return;
      Vector2 impulse = correlationXImpulse();
      body.ApplyLinearImpulse(impulse);
    }
    
    private Vector2 correlationXImpulse()
    {
      Vector2 impulse = Vector2.Zero;
      float impulseX = correlationFactorX;
      float impulseY = correlateValue(body.LinearVelocity.Y, body.LinearVelocity.X, correlationFactorX);
      
      impulse += Vector2.UnitX * impulseX;
      impulse += Vector2.UnitY * impulseY;
      return impulse;
    }
    
    private Vector2 correlationYImpulse()
    {
      Vector2 impulse = Vector2.Zero;
      float impulseY = correlationFactorY * ((body.LinearVelocity.Y > 0) ? 1f : -1f);
      float impulseX = correlateValue(body.LinearVelocity.X, body.LinearVelocity.Y, correlationFactorY);
      
      impulse += Vector2.UnitX * impulseX;
      impulse += Vector2.UnitY * impulseY;
      return impulse;
    }
    
    private float correlateValue(float x, float y, float factor)
    {
      float c = (float)Math.Pow((double)(y + factor), 2) - y * y;
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

