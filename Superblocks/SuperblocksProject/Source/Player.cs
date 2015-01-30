using System;

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
    
    public void AddPoints(int points) {
      score += points;
    }
    
    public void DecrementLives()
    {
      lives--;
      if (lives == 0)
        Console.WriteLine("GAME OVER");
    }
    
    public void IncrementLives()
    {
      lives++;
    }
    
    public int Score { get { return score; } }
    public int Lives { get { return lives; } }
  }
}

