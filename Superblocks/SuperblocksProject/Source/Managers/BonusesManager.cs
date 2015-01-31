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
    private Dictionary<string, Bonus> bonuses = new Dictionary<string, Bonus>();
    
    public BonusesManager (Level level)
    {
      this.level = level;
      this.sequence = 0;
    }
    
    public void CreateBonus(float x, float y)
    {
      System.Random random = new System.Random ();
      if (random.Next(0, 10) > -1) {
        Bonus bonus = new Bonus(this.sequence++, x, y);
        level.Game.LevelScene.EntityManager.Add(bonus.Entity);
      }
    }
    
    public void RemoveBonus(string name)
    {
      level.Game.LevelScene.EntityManager.Remove(name);
      bonuses.Remove (name);
    }
  }
}

