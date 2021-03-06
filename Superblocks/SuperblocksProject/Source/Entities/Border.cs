﻿#region Using Statements
using System;
using WaveEngine.Common.Math;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics2D;
using WaveEngine.Framework.Services;
#endregion

namespace SuperblocksProject
{
  public class Border
  {
    private Entity entity;
    
    public Border(string name, float x, float y, float rotation, bool isSide, bool isBottom)
    {
      this.entity = new Entity ("border" + name)
        .AddComponent (new Transform2D () { X = x, Y = y, Origin = Vector2.Center, XScale = 15f,
        Rotation = MathHelper.ToRadians (rotation)
       })
        .AddComponent (new Sprite ("textures/ground.wpk"))
        .AddComponent (new RectangleCollider ())
        .AddComponent (new RigidBody2D() {
          PhysicBodyType = PhysicBodyType.Static,
          Damping = 0,
          Restitution = 1.0f,
          Friction = 0f,
          CollisionCategories = Physic2DCategory.All
        })
        .AddComponent (new SpriteRenderer (DefaultLayers.Opaque));
       
        if (isSide)
          this.entity.AddComponent(new SideBorderBehaviour(this));
        else if (isBottom)
          this.entity.AddComponent(new BottomBorderBehaviour(this));
    }
        
    public Entity Entity { get { return entity; } }
  }
}

