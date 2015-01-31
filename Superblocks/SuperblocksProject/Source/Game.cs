#region Using Statements
using System;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Framework;
using WaveEngine.Common.Input;
using WaveEngine.Framework.Services;
#endregion

namespace SuperblocksProject
{
  public class Game : WaveEngine.Framework.Game
  {
    private Player player;
    private Level currentLevel;
    private LevelScene levelScene;
    private int levelId;
    
    public override void Initialize (IApplication application)
    {
      base.Initialize (application);

      ViewportManager vm = WaveServices.ViewportManager;
      vm.Activate (1280, 720, ViewportManager.StretchMode.Uniform);     
      setScene(new UIScene(this, "intro"));
    }
    
    public void Start()
    {
      levelId = 1;
      player = new Player();
      currentLevel = new Level(levelId, this);
      levelScene = new LevelScene(this);
      setScene(levelScene);
    }
    
    public void NextLevel() {
      levelId++;
      currentLevel.Finish();
      currentLevel = new Level(levelId, this);
      currentLevel.Init();
    }
    
    public void End()
    {
      setScene(new UIScene(this, "gameover"));
    }
    
    private void setScene(Scene scene)
    {
      ScreenContext screenContext = new ScreenContext (scene);  
      WaveServices.ScreenContextManager.To(screenContext);
    }
    
    public LevelScene LevelScene { get { return levelScene; } }
    public Level CurrentLevel { get { return currentLevel; } }
    public Player Player { get { return player; } }
  }
}

