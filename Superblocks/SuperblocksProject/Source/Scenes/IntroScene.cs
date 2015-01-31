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
  public class IntroScene : Scene
  {
    private Game game;

    public IntroScene (Game game)
    {
      this.game = game;
    }

    protected override void CreateScene()
    {
      EntityManager.Add(new FixedCamera2D("Camera2D"));
      AddSceneBehavior(new UISceneBehaviour(), SceneBehavior.Order.PreUpdate);
    }

    protected override void Start ()
    {
      base.Start ();
      
    }
    
    public Game Game { get { return game; } }
  }
}

