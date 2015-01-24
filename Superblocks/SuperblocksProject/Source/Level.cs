﻿#region Using Statements
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
    private BallsManager ballsManager;
    
    private ArrayList borders = new ArrayList();
    
    public Level(int id)
    {
      this.id = id;
      this.pad = new Pad();
      this.ballsManager = new BallsManager(this);   
      this.ballsManager.AddBall ();
      createBlocks();
      createBorders();
    }

    private void createBorders()
    {
      borders.Add(new Border("Left", -31, 0, 90, true, false));
      borders.Add(new Border("Right", WaveServices.Platform.ScreenWidth + 31, 0, 90, true, false));
      borders.Add(new Border("Top", 0, -20, 0, false, false));
      borders.Add(new Border("Bottom", 0, WaveServices.Platform.ScreenHeight + 40, 0, false, true));
    }
      
    private void createBlocks()
    {
      int[] blocksArray = { 1, 1, 1, 0, 2, 2, 0, 1, 1, 1,
                            2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
      
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
    public BallsManager BallsManager { get { return ballsManager; } }
    public ArrayList Borders { get { return borders; } }
  }
}

