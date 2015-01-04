using System;

namespace SuperblocksProject
{
  public class Player
  {
    int currentLevelId, score, lives;
    public Player (int startLevel)
    {
      this.currentLevelId = startLevel;
      this.lives = 3;
      this.score = 0;
    }
    
    public void Describe()
    {
      Console.WriteLine ("level: " + this.currentLevelId + ", score: " + this.score + ", lives: " + this.lives);
    }  
  }
}

