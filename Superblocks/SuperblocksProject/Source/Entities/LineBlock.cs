#region Using Statements
using System;
#endregion

namespace SuperblocksProject
{
  public class LineBlock : Block
  {
    public LineBlock(int count, int offsetX, int offsetY) : base(count, offsetX, offsetY)
    {
      body.Draw("textures/block_t2_l2.wpk");
    }

    public override void Hit(BlocksManager manager) 
    {
      harmed = true;
      body.ChangeTexture("textures/block_t2_l1.wpk");
      if (manager.CheckLine(line) == 0)
        manager.RemoveLine(line);
    }
  }
}