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
  public class BlockBehaviour : Behavior
  {
    private enum BlockState { Pre, Running, Destroyed };
    private BlockState currentState;
    private Block block;
    
    public BlockBehaviour (Block block)
    {
      this.currentState = BlockState.Pre;
      this.block = block;
    }
    
    protected override void Update(TimeSpan gameTime)
    {
      RigidBody2D body = Owner.FindComponent<RigidBody2D>();

      if (body != null && currentState == BlockState.Pre) {
        body.OnPhysic2DCollision += onCollision;
        currentState = BlockState.Running;
      }
    }

    private void onCollision(object sender, Physic2DCollisionEventArgs args)
    {
      if (this.block.Hit())
        this.Owner.Scene.EntityManager.Remove (block.Name);
    }
  }
}