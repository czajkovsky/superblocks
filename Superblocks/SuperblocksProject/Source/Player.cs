﻿using System;

namespace SuperblocksProject
{
  public class Player
  {
    int score, lives;
    public Player()
    {
      this.lives = 3;
      this.score = 0;
    }
    
    public void Describe()
    {
      Console.WriteLine ("score: " + this.score + ", lives: " + this.lives);
    }  
  }
}
