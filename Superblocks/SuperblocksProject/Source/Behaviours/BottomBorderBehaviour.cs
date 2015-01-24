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
  public class BottomBorderBehaviour : Behavior
  {
    private enum BorderState { Pre, Iniatited };
    private BorderState currentState;
    private Border border;

    public BottomBorderBehaviour (Border border)
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
        LevelScene scene = (LevelScene)args.Body2DB.Owner.Scene;
        scene.Game.CurrentLevel.BallsManager.RemoveBall(args.Body2DB.Owner.Name);
      }
    }
  }
}