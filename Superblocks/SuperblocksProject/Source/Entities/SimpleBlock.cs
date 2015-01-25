#region Using Statements
using System;
using System.Collections.Generic;
using WaveEngine.Common.Math;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Resources;
using WaveEngine.Framework.Services;
using WaveEngine.Framework.Physics2D;
#endregion

namespace SuperblocksProject
{
  public class SimpleBlock : Block
  {
    public SimpleBlock(int count, int offsetX, int offsetY) : base(count, offsetX, offsetY)
    {
      body.Draw("textures/block_t1_l1.wpk");
    }
    
    public override void Hit(BlocksManager manager) 
    {
      manager.RemoveBlock(Name);
    }
  }
}

