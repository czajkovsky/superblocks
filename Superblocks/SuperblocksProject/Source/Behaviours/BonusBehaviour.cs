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
  public class BonusBehaviour : Behavior
  {
    private enum BonusState { Pre, Running };
    private BonusState state;
    
    public BonusBehaviour () {
      this.state = BonusState.Pre;
    }
    protected override void Initialize() {}

    protected override void Update(TimeSpan gameTime)
    {
      RigidBody2D body = Owner.FindComponent<RigidBody2D>();

      if (body != null && state == BonusState.Pre) {
        Vector2 impulse = Vector2.Zero;
        impulse += Vector2.UnitY * 0.1f;
        body.ApplyLinearImpulse (impulse);
        state = BonusState.Running;
      }
    }
  }
}
