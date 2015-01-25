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
      this.count = 0;
      parseFile();
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
    
    private void addBlock(int blockType, int iterator)
    {
      count++;
      switch (blockType) {
        case 1:
          SimpleBlock block = new SimpleBlock(count, iterator % 10, iterator / 10);
          blocks.Add(block.Name, block);
          break;
      }
    }
     
    private void parseFile()
    {
      int i = 0;
      String input = File.ReadAllText ("levels/" + level.Id + ".txt");
      foreach (var row in input.Split('\n'))
        if (row.Length > 0)
          processRow(ref i, row);
    }
    
    private void processRow(ref int iterator, string row)
    {
      int blockType;
      foreach (var col in row.Trim().Split(' ')) {
        blockType = int.Parse (col);
        if (blockType > 0)
          addBlock (blockType, iterator);
        iterator++;
      }
    }
  }
}