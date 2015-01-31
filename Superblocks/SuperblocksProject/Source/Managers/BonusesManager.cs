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
    private int sequence;
    
    public BonusesManager (Level level)
    {
      this.level = level;
      this.sequence = 0;
    }
    
    public void CreateBonus(float x, float y)
    {
      System.Random random = new System.Random ();
      if (random.Next(0, 10) > -1) {
        Bonus bonus = new Bonus(this.sequence++);
        level.Game.LevelScene.EntityManager.Add(bonus.Entity);
      }
    }
  }
}

