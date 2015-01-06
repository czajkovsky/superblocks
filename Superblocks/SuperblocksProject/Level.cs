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
    }
      
    private void createBlocks()
    {
      int[] blocksArray = { 1, 1, 1, 0, 1, 1, 0, 1, 1, 1,
                            2, 2, 3, 3, 1, 1, 3, 3, 2, 2 };
      
      int block_id = 0;
      foreach (int i in blocksArray) {
        blocks.Add (new Block (block_id, block_id % 10, block_id / 10));
        block_id++;
      }
    }
    
    public ArrayList Blocks { get { return blocks; } private set { blocks = value; } }
    public Pad Pad { get { return pad; } private set { pad = value; } }
    public Ball Ball { get { return ball; } private set { ball = value; } }
    public ArrayList Borders { get { return borders; } }
  }
}

