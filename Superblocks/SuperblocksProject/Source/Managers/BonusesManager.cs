#region Using Statements
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
#endregion

namespace SuperblocksProject
{
  public class BonusesManager
  {
    private Level level;
    
    public BonusesManager (Level level)
    {
      this.level = level;
    }
    
    public void CreateBonus(float x, float y)
    {
      Console.WriteLine (x + " " + y);
      
    }
  }
}

