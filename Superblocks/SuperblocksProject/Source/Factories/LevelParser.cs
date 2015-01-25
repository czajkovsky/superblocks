#region Using Statements
using System;
using System.IO;
using System.Collections.Generic;
#endregion

namespace SuperblocksProject
{
  public class LevelParser
  {
    private Dictionary<string, Block> blocks = new Dictionary<string, Block>();
    private int count, levelId;
    
    public LevelParser (int levelId)
    {
      this.levelId = levelId;
      this.count = 0;
    }
    
    public Dictionary<string, Block> Generate()
    {
      parseFile ();
      return blocks;
    }
    
    private void addBlock(int blockType, int iterator)
    {
      count++;
      Block block;
      switch (blockType) {
      case 2:
        block = new DoubleBlock(count, iterator % 10, iterator / 10);
        break;
      case 3:
        block = new LineBlock(count, iterator % 10, iterator / 10);
        break;
      default:
        block = new SimpleBlock (count, iterator % 10, iterator / 10);
        break;
      }
      blocks.Add(block.Name, block);
    }

    private void parseFile()
    {
      int i = 0;
      String input = File.ReadAllText ("levels/" + levelId + ".txt");
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

