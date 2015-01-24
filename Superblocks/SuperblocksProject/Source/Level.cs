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
    private ArrayList blocks = new ArrayList();
    private Pad pad;
    private BallsManager ballsManager;
    private BlocksManager blocksManager;
    private Game game;
    
    private ArrayList borders = new ArrayList();
    
    public Level(int id, Game game)
    {
      this.id = id;
      this.game = game;
      this.pad = new Pad();
      this.ballsManager = new BallsManager(this);
      this.blocksManager = new BlocksManager(this);
      createBorders();
    }
    
    public void Restart()
    {
      game.Player.DecrementLives();
      ballsManager.AddBall();
    }
    
    public void Init()
    {
      ballsManager.AddBall();
      blocksManager.Init();
    }

    private void createBorders()
    {
      borders.Add(new Border("Left", -31, 0, 90, true, false));
      borders.Add(new Border("Right", WaveServices.Platform.ScreenWidth + 31, 0, 90, true, false));
      borders.Add(new Border("Top", 0, -20, 0, false, false));
      borders.Add(new Border("Bottom", 0, WaveServices.Platform.ScreenHeight + 40, 0, false, true));
    }
      
    
    public int Id { get { return id; } }
    public Pad Pad { get { return pad; } private set { pad = value; } }
    public BallsManager BallsManager { get { return ballsManager; } }
    public BlocksManager BlocksManager { get { return blocksManager; } }
    public ArrayList Borders { get { return borders; } }
    public Game Game { get { return game; } }
  }
}

