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
  public class Block
  {
    private Entity entity;
    private int id, lives, type;
    private int[] blockInitialLives = { 0, 1, 2 };
    private Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();
     
    public Block(int id, int offsetX, int offsetY, int type)
    {
      this.id = id;
      this.lives = blockInitialLives[type];
      this.type = type;
      createSprites();
            
      this.entity = new Entity("block" + this.id)
        .AddComponent(new Transform2D() {
          X = blockXOffset(offsetX),
          Y = blockYOffset(offsetY),
          Origin = Vector2.Center
        })
        .AddComponent(sprites[("block_t" + this.type + "_l" + this.lives)])
        .AddComponent(new RectangleCollider())
        .AddComponent(new RigidBody2D() { PhysicBodyType = PhysicBodyType.Static })
        .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
        .AddComponent(new BlockBehaviour(this));
    }
      
    private void createSprites() {
      sprites.Add("block_t1_l1", new Sprite ("textures/block_t1_l1.wpk"));
      sprites.Add("block_t2_l2", new Sprite ("textures/block_t2_l2.wpk"));
      sprites.Add("block_t2_l1", new Sprite ("textures/block_t2_l1.wpk"));
    }
        
    public bool Hit() 
    {
      lives--;
      if (lives > 0) {
        changeTexture();
        return false;
      }
      return false;
    }

    public string Name { get { return "block" + id; } }
    public Entity Entity { get { return entity; } private set { entity = value; } }
    
    private void changeTexture() 
    {
      this.entity
        .RemoveComponent<Sprite>()
        .AddComponent(sprites[("block_t" + type + "_l" + lives)])
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
  }
}

