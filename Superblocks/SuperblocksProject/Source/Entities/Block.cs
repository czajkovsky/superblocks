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
    private int id, lives, type;
    private int[] blockInitialLives = { 0, 1, 2 };
    private BlockBody body;
    
    public Block(int id, int offsetX, int offsetY, int type)
    {
      this.id = id;
      this.lives = blockInitialLives[type];
      this.type = type;
      this.body = new BlockBody(offsetX, offsetY, this);
    }
      
    public bool Hit() 
    {
      lives--;
      if (lives > 0) {
        body.ChangeTexture();
        return false;
      }
      return true;
    }

    public string Name { get { return "block" + id; } }
    public int Type { get { return type; } }
    public int Lives { get { return lives; } }
    public Entity Entity { get { return body.Entity; } }
  }
}

