#region Using Statements
using System;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Framework;
using WaveEngine.Framework.Services;
#endregion

namespace SuperblocksProject
{
  public class Game : WaveEngine.Framework.Game
  {
    Player player;
    Level currentLevel;
    LevelScene currentScene;
    
    public override void Initialize (IApplication application)
    {
      base.Initialize (application);

      ViewportManager vm = WaveServices.ViewportManager;
      vm.Activate (1280, 720, ViewportManager.StretchMode.Uniform);

      player = new Player();
      currentLevel = new Level(1, this);
      currentScene = new LevelScene(player, currentLevel);
      
      ScreenContext screenContext = new ScreenContext(currentScene);	
      WaveServices.ScreenContextManager.To (screenContext);
    }
    
    public LevelScene CurrentScene { get { return currentScene; } }
    public Player Player { get { return player; } }
  }
}

