﻿using System;

namespace SuperblocksProject
{
  public class BallBonus : Bonus
  {
    public BallBonus (int id, float offsetX, float offsetY) : base(id, offsetX, offsetY, "bonusBall") {}
    
    public void Apply()
    {
      Console.WriteLine("apply");
    }
  }
}

