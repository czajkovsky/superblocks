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
      var camera2D = new FixedCamera2D("Camera2D")
      {
        BackgroundColor = Color.CornflowerBlue
      };
      EntityManager.Add(camera2D);


      Entity ground = new Entity("ground")
        .AddComponent(new Transform2D() { X = 400, Y = 400, Origin = Vector2.Center })
        .AddComponent(new Sprite("groundSprite.wpk"))
        .AddComponent(new RectangleCollider())
        .AddComponent(new RigidBody2D() { PhysicBodyType = PhysicBodyType.Static })
        .AddComponent(new SpriteRenderer(DefaultLayers.Opaque));
      
      player.Describe();

      EntityManager.Add(ground);
    }

    protected override void Start ()
    {
      base.Start ();
    }
  }
}

