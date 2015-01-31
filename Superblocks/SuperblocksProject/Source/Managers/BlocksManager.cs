#region Using Statements
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
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
        level.Game.LevelScene.EntityManager.Add(block.Entity);
    }
    
    public int CheckLine(int line, int type)
    {
      int count = 0;
      foreach (Block block in blocks.Values)
        if (block.Line == line && block.Type == type && !block.Harmed)
          count++;
      return count;
    }
    
    public void RemoveLine(int line, int type)
    {
      ArrayList buffer = new ArrayList();
      foreach (Block block in blocks.Values)
        if (block.Line == line && block.Type == type)
          buffer.Add (block.Name);
      foreach (string name in buffer)
        RemoveBlock(name);
    }
    
    public void RemoveBlock(string blockName)
    {
      count--;
      level.Game.Player.AddPoints(blocks[blockName].Points);
      level.Game.LevelScene.UI.SetScore(level.Game.Player.Score);
      blocks.Remove(blockName);
      level.Game.LevelScene.EntityManager.Remove(blockName);
      if (count == 0)
        level.Game.NextLevel();
    }
  }
}