﻿#region Using Statements
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
      player.Describe();
      
      var camera2D = new FixedCamera2D("Camera2D")
      {
        BackgroundColor = Color.CornflowerBlue
      };
      EntityManager.Add(camera2D);

      Entity borderTop = new Entity("borderTop")
        .AddComponent(new Transform2D() { X = 0, Y = 720, Origin = Vector2.Center, XScale = 15f })
        .AddComponent(new Sprite("textures/groundSprite.wpk"))
        .AddComponent(new RectangleCollider())
        .AddComponent(new RigidBody2D() { PhysicBodyType = PhysicBodyType.Static })
        .AddComponent(new SpriteRenderer(DefaultLayers.Opaque));
      
      Entity circle = new Entity("Circle")
        .AddComponent(new Transform2D() { X = 950, Origin = Vector2.Center })
        .AddComponent(new Sprite("textures/circleSprite.wpk"))
        .AddComponent(new CircleCollider())
        .AddComponent(new RigidBody2D())
        .AddComponent(new SpriteRenderer(DefaultLayers.Alpha));
      
      Block block = new Block (); 

      EntityManager.Add(circle);
      EntityManager.Add(block.Entity);
      EntityManager.Add(borderTop);
    }

    protected override void Start ()
    {
      base.Start ();
    }
  }
}

