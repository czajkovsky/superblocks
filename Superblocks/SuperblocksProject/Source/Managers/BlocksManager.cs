#region Using Statements
using System;
using System.IO;
using System.Collections;
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
    private ArrayList blocks = new ArrayList();

    public BlocksManager (Level level)
    {
      this.level = level;
      this.count = 0;
      parseFile();
    }
    
    public void Init()
    {
      foreach (Block block in blocks)
        level.Game.CurrentScene.EntityManager.Add(block.Entity);
    }
    
    private void parseFile()
    {
      int i = 0, blockValue;
      String input = File.ReadAllText ("levels/" + level.Id + ".txt");
      foreach (var row in input.Split('\n')) {
        if (row.Length > 0) {
          foreach (var col in row.Trim().Split(' ')) {
            blockValue = int.Parse (col);
            if (blockValue > 0) {
              count++;
              blocks.Add (new Block (count, i % 10, i / 10, blockValue));
            }
            i++;
          }
        }
      }
    }
    
    public ArrayList Blocks { get { return blocks; } }
  }
}