#region Using Statements
using System;
#endregion

namespace SuperblocksProject
{
  public class LineBlock : Block
  {
    public LineBlock(int count, int offsetX, int offsetY) : base(count, offsetX, offsetY)
    {
      body.Draw("textures/lineBlock1.wpk");
    }

    public override void Hit(BlocksManager manager) 
    {
      harmed = true;
      body.ChangeTexture("textures/lineBlock0.wpk");
      if (manager.CheckLine(line) == 0)
        manager.RemoveLine(line);
    }
  }
}