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
  public class UIScene : Scene
  {
    private Game game;
    private string texture;

    public UIScene (Game game, String texture)
    {
      this.game = game;
      this.texture = texture;
    }

    protected override void CreateScene()
    {
      EntityManager.Add(new FixedCamera2D("Camera2D"));
      Entity background = new Entity("background")
        .AddComponent(new Transform2D() { Y = 10, DrawOrder = 1f })
        .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
        .AddComponent(new Sprite("textures/" + texture + ".wpk"));
      EntityManager.Add(background);
      AddSceneBehavior(new UISceneBehaviour(game), SceneBehavior.Order.PreUpdate);
    }

    protected override void Start ()
    {
      base.Start ();
    }
    
    public Game Game { get { return game; } }
  }
}

