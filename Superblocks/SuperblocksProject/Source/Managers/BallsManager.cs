#region Using Statements
using System;
using System.Collections;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Components.Cameras;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Components.Graphics3D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Resources;
using WaveEngine.Framework.Services;
using WaveEngine.Framework.Physics2D;
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
      Ball ball = new Ball (sequence);
      balls.Add (ball);
      level.Game.CurrentScene.EntityManager.Add(ball.Entity);
    }
    
    public void RemoveBall(string ballName) {
    }
    
    public ArrayList Balls { get { return balls; } private set { balls = value; } }
  }
}

