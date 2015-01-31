using System;

namespace SuperblocksProject
{
  public class LiveBonus : Bonus
  {
    public LiveBonus (int id, float offsetX, float offsetY) : base(id, offsetX, offsetY, "bonusHeart") {}

    public override void Apply(Level level)
    {
      level.AddLive();
    }
  }
}

