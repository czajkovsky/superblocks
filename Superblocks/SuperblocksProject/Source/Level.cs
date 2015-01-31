#region Using Statements
using System;
using System.IO;
using System.Text;
using System.Collections;
using WaveEngine.Framework.Services;
#endregion

namespace SuperblocksProject
{
  public class Level
  {
    private int id;
    private BallsManager ballsManager;
    private BlocksManager blocksManager;
    private BonusesManager bonusesManager;
    private Game game;
    
    public Level(int id, Game game)
    {
      this.id = id;
      this.game = game;
      this.ballsManager = new BallsManager(this);
      this.blocksManager = new BlocksManager(this);
      this.bonusesManager = new BonusesManager(this);
    }
    
    public void Restart()
    {
      game.Player.DecrementLives();
      game.LevelScene.UI.SetLives(game.Player.Lives);
      if (game.Player.Lives > 0) {
        ballsManager.AddBall ();
      } else {
        game.End();
      }
    }
    
    public void Init()
    {
      ballsManager.AddBall();
      blocksManager.Init();
    }
    
    public void AddBall()
    {
      ballsManager.AddBall();
    }
    
    public void AddLive()
    {
      game.Player.IncrementLives();
      game.LevelScene.UI.SetLives(game.Player.Lives);
    }
    
    public void Finish() {
      ballsManager.removeAllBalls();
    }

    public int Id { get { return id; } }
    public BallsManager BallsManager { get { return ballsManager; } }
    public BlocksManager BlocksManager { get { return blocksManager; } }
    public BonusesManager BonusesManager { get { return bonusesManager; } }
    public Game Game { get { return game; } }
  }
}

