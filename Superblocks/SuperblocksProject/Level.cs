﻿using System;

namespace SuperblocksProject
{
  public class Level
  {
    int id;
    
    public Level(int id)
    {
      this.id = id;
      CreateBlocks();
    }
    
    private void CreateBlocks()
    {
      Console.WriteLine ("creating blocks...");
      int[] blocksArray = { 1, 1, 1, 0, 1, 1, 0, 1, 1, 1,
                            2, 2, 3, 3, 1, 1, 3, 3, 2, 2 };
      
    }
  }
}

