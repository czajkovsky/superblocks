#region Using Statements
using System;
#endregion

namespace SuperblocksProject
{
  public class DoubleBlock : Block
  {
    public DoubleBlock(int count, int offsetX, int offsetY) : base(count, offsetX, offsetY)
    {
      body.Draw("textures/block_t2_l2.wpk");
      this.lives = 2;
    }

    public override void Hit(BlocksManager manager) 
    {
      lives--;
      if (lives == 0)
        manager.RemoveBlock(Name);
      else
        body.ChangeTexture("textures/block_t2_l1.wpk");
    }
  }
}

