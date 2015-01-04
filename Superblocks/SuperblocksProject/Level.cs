using System;
using System.Collections;

namespace SuperblocksProject
{
  public class Level
  {
    private int id;
    private ArrayList blocks = new ArrayList();
    private Pad pad;
    
    public Level(int id)
    {
      this.id = id;
      this.pad = new Pad();
      createBlocks();
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
  }
}

