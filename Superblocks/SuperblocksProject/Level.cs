#region Using Statements
using System;
using System.Collections;
using WaveEngine.Framework.Services;
#endregion

namespace SuperblocksProject
{
  public class Level
  {
    private int id;
    private ArrayList blocks = new ArrayList();
    private Pad pad;
    private Ball ball;
    private ArrayList borders = new ArrayList();
    
    public Level(int id)
    {
      this.id = id;
      this.pad = new Pad();
      this.ball = new Ball();
     
      createBlocks();
      createBorders();
    }
    
    private void createBorders()
    {
      borders.Add(new Border("Left", -31, 0, 90));
      borders.Add(new Border("Right", WaveServices.Platform.ScreenWidth + 31, 0, 90));
      borders.Add(new Border("Top", 0, -20, 0));
      borders.Add(new Border("Bottom", 0, WaveServices.Platform.ScreenHeight + 20, 0));
    }
      
    private void createBlocks()
    {
      int[] blocksArray = { 1, 1, 1, 0, 1, 1, 0, 1, 1, 1,
                            2, 2, 0, 1, 1, 1, 1, 0, 2, 2 };
      
      int blockId = 0, blockCount = 0;
      foreach (int i in blocksArray) {
        if (i > 0) {
          blocks.Add (new Block (blockId, blockCount % 10, blockCount / 10, i));
          blockId++;
        }
        blockCount++;
      }
    }
    
    public ArrayList Blocks { get { return blocks; } private set { blocks = value; } }
    public Pad Pad { get { return pad; } private set { pad = value; } }
    public Ball Ball { get { return ball; } private set { ball = value; } }
    public ArrayList Borders { get { return borders; } }
  }
}

