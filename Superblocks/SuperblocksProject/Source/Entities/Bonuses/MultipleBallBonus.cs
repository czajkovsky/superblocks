using System;

namespace SuperblocksProject
{
  public class MultipleBallBonus : Bonus
  {
    public MultipleBallBonus (int id, float offsetX, float offsetY) : base(id, offsetX, offsetY, "bonusMultipleBall") {}

    public override void Apply(Level level)
    {
      level.AddBall();
      level.AddBall();
    }
  }
}

