#region Using Statements
using System;
using System.Collections.Generic;
using WaveEngine.Common.Math;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Resources;
using WaveEngine.Framework.Services;
using WaveEngine.Framework.Physics2D;
#endregion

namespace SuperblocksProject
{
  public class BlockBody
  {
    private Entity entity;
    private Block block;
    
    public BlockBody (int offsetX, int offsetY, Block block)
    {
      this.block = block;
      this.entity = new Entity(block.Name)
        .AddComponent(new Transform2D() {
          X = blockXOffset(offsetX),
          Y = blockYOffset(offsetY),
          Origin = Vector2.Center
        })
        .AddComponent(new Sprite ("textures/block_t" + block.Type + "_l" + block.Lives + ".wpk"))
        .AddComponent(new RectangleCollider())
        .AddComponent(new RigidBody2D() { PhysicBodyType = PhysicBodyType.Static })
        .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
        .AddComponent(new BlockBehaviour(block));
    }
    
    public void ChangeTexture() 
    {
      this.entity
        .RemoveComponent<Sprite>()
        .AddComponent(new Sprite ("textures/block_t" + block.Type + "_l" + block.Lives + ".wpk"))
        .RefreshDependencies();
    }

    private float blockXOffset(int offsetX) {
      const int OFFSET_X = 20;
      const int GUTTER_X = 4;
      const int WIDTH = 116;
      return OFFSET_X + GUTTER_X + offsetX * (WIDTH + 2 * GUTTER_X) + (int)((float)WIDTH / 2f);
    }

    private float blockYOffset(int offsetY) {
      const int HEIGHT = 51;
      const int OFFSET_Y = 28;
      const int GUTTER_Y = 4;
      return OFFSET_Y + GUTTER_Y + offsetY * (HEIGHT + 2 * GUTTER_Y) + (int)((float)HEIGHT / 2f);
    } 
    
    public Entity Entity { get { return entity; } }
  }
}

