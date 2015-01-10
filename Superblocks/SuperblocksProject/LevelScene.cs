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
      player.Describe();
      EntityManager.Add(new FixedCamera2D ("Camera2D"));
      EntityManager.Add(level.Ball.Entity);
      EntityManager.Add(level.Pad.Entity);
      
      foreach (Block block in level.Blocks)
        EntityManager.Add(block.Entity);
        
      foreach (Border border in level.Borders)
        EntityManager.Add(border.Entity);
    }

    protected override void Start ()
    {
      base.Start ();
    }
  }
}

