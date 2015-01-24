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
  public class SideBorderBehaviour : Behavior
  {
    private enum BorderState { Pre, Iniatited };
    private BorderState currentState;
    private Border border;

    public SideBorderBehaviour (Border border)
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
      if (args.Body2DB.Owner.Name.StartsWith("Ball")) {
        BallCollider collider = new BallCollider(args.Body2DB);
        collider.AdjustY ();
      }
    }
  }
}