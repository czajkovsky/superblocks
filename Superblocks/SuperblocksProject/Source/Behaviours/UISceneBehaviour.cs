#region Using Statements
using System;
using WaveEngine.Common.Input;
using WaveEngine.Framework;
using WaveEngine.Framework.Services;
#endregion

namespace SuperblocksProject
{
  public class UISceneBehaviour : SceneBehavior
  {
    public UISceneBehaviour ()
    {
      Console.WriteLine ("handle");
    }
    
    protected override void ResolveDependencies()
    {
    }
    
    protected override void Update(TimeSpan gameTime)
    {
      var keyboard = WaveServices.Input.KeyboardState;      
      if (keyboard.Space == ButtonState.Pressed)
        Console.WriteLine ("STAAART!");
    }
  }
}

