#region Using Statements
using System;
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
  public class LevelScene : Scene
  {
    private Game game;
    private Pad pad;
    private UI ui;

    public LevelScene (Game game)
    {
      this.game = game;
      this.pad = new Pad();
      this.ui = new UI();
    }

    protected override void CreateScene()
    {
      EntityManager.Add(new FixedCamera2D ("Camera2D"));
      EntityManager.Add(pad.Entity);
      
      EntityManager.Add(new Border("Left", -31, 0, 90, true, false).Entity);
      EntityManager.Add(new Border("Right", WaveServices.Platform.ScreenWidth + 31, 0, 90, true, false).Entity);
      EntityManager.Add(new Border("Top", 0, -20, 0, false, false).Entity);
      EntityManager.Add(new Border("Bottom", 0, WaveServices.Platform.ScreenHeight + 40, 0, false, true).Entity);
      
      EntityManager.Add(ui.Background);
      EntityManager.Add(ui.Score);
      EntityManager.Add(ui.Lives);
      
      game.CurrentLevel.Init ();
    }

    protected override void Start ()
    {
      base.Start ();
    }

    public Game Game { get { return game; } }
    public UI UI { get { return ui; } }
  }
}

