#region Using Statements
using System;
#endregion

namespace SuperblocksProject
{
  public class ToggleBlock : Block
  {
    public ToggleBlock(int count, int offsetX, int offsetY) : base(count, offsetX, offsetY)
    {
      this.points = 8;
      this.body.Draw("textures/toggleBlock1.wpk");
      this.type = 4;
    }

    public override void Hit(BlocksManager manager) 
    {
      harmed = !harmed;
      if (harmed)
        body.ChangeTexture("textures/toggleBlock0.wpk");
      else
        body.ChangeTexture("textures/toggleBlock1.wpk");
      if (manager.CheckLine(line, type) == 0)
        manager.RemoveLine(line, type);
    }
  }
}