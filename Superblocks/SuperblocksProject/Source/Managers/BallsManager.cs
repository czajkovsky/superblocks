#region Using Statements
using System;
using System.Collections;
using WaveEngine.Framework.Services;
#endregion

namespace SuperblocksProject
{
  public class BallsManager
  {
    Level level;
    private ArrayList balls = new ArrayList();
    private int count, sequence;
    
    public BallsManager (Level level)
    {
      this.level = level;
      this.count = 0;
      this.sequence = 0;
    }
    
    public void AddBall() {
      count++;
      sequence++;
      this.balls.Add(new Ball(sequence));
    }
    
    public void RemoveBall(string ballName) {
    }
    
    public ArrayList Balls { get { return balls; } private set { balls = value; } }
  }
}

