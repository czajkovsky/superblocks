#region Using Statements
using System;
using System.IO;
using System.Collections.Generic;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Components.Cameras;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Components.Graphics3D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Resources;
using WaveEngine.Framework.Services;
using WaveEngine.Framework.Physics2D;
#endregion

namespace SuperblocksProject
{
  public class BlocksManager
  {
    Level level;
    private int count;
    private Dictionary<string, Block> blocks = new Dictionary<string, Block>();

    public BlocksManager (Level level)
    {
      this.level = level;
      this.blocks = new LevelParser(level.Id).Generate();
      this.count = blocks.Keys.Count;
    }
    
    public void Init()
    {
      foreach (Block block in blocks.Values)
        level.Game.CurrentScene.EntityManager.Add(block.Entity);
    }
    
    public void RemoveBlock(string blockName)
    {
      count--;
      level.Game.CurrentScene.EntityManager.Remove (blockName);
      if (count == 0)
        level.Game.NextLevel();
    }
  }
}