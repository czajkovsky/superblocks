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
    Player player;
    Level level;

    public LevelScene (Player player, Level level)
    {
      this.player = player;
      this.level = level;
    }

    protected override void CreateScene()
    {
      EntityManager.Add(new FixedCamera2D ("Camera2D"));
      EntityManager.Add(level.Ball.Entity);
      EntityManager.Add(level.Pad.Entity);

      foreach (Block block in level.Blocks)
        EntityManager.Add(block.Entity);

      foreach (Border border in level.Borders)
        EntityManager.Add(border.Entity);

      Entity background = createBackground();
      EntityManager.Add(background);
    }

    protected override void Start ()
    {
      base.Start ();
    }

    private Entity createBackground()
    {
      Entity background = new Entity("background")
        .AddComponent(new Transform2D() { Y = 10 })
        .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
        .AddComponent(new Sprite("textures/background.wpk"));
      return background;
    }
  }
}

