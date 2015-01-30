#region Using Statements
using System;
#endregion

namespace SuperblocksProject
{
  public class SimpleBlock : Block
  {
    public SimpleBlock(int count, int offsetX, int offsetY) : base(count, offsetX, offsetY)
    {
      this.type = 1;
      this.points = 1;
      this.body.Draw("textures/block_t1_l1.wpk");
    }
    
    public override void Hit(BlocksManager manager) 
    {
      manager.RemoveBlock(Name);
    }
  }
}

