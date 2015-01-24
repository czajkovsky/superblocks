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
    private Player player;
    private Level currentLevel;
    private LevelScene currentScene;
    private int levelId;
    
    public override void Initialize (IApplication application)
    {
      base.Initialize (application);

      ViewportManager vm = WaveServices.ViewportManager;
      vm.Activate (1280, 720, ViewportManager.StretchMode.Uniform);

      levelId = 1;
      player = new Player();
      currentLevel = new Level(levelId, this);
      currentScene = new LevelScene(this);
      
      ScreenContext screenContext = new ScreenContext(currentScene);	
      WaveServices.ScreenContextManager.To (screenContext);
    }
    
    public void NextLevel() {
      levelId++;
      currentLevel.Finish();
      currentLevel = new Level(levelId, this);
      currentLevel.Init();
    }
    
    public LevelScene CurrentScene { get { return currentScene; } }
    public Level CurrentLevel { get { return currentLevel; } }
    public Player Player { get { return player; } }
  }
}

