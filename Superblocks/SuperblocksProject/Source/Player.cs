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
        
    public void AddPoints(int points) {
      score += points;
    }
    
    public void DecrementLives()
    {
      lives--;
    }
    
    public void IncrementLives()
    {
      lives++;
    }
    
    public int Score { get { return score; } }
    public int Lives { get { return lives; } }
  }
}

