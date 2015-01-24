﻿#region Using Statements
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
      initialVector += Vector2.UnitX * 0.15f;
      initialVector += Vector2.UnitY * 0.1f;
    }
         
    protected override void Update(TimeSpan gameTime)
    {
      RigidBody2D body = Owner.FindComponent<RigidBody2D>();
      
      if (body != null) {
        if (currentState == BallState.Idle) {
          body.ApplyLinearImpulse (initialVector);
          currentState = BallState.Running;
        } else if (currentState == BallState.Running) {
        }
      }
    }
  }
}
