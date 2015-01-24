using System;

namespace SuperblocksProject
{
  public static class MathHelpers
  {
    public static void SquareEquation(float a, float b, float c, out float res1, out float res2)
    {
      float delta = b * b - 4 * a * c;
      res1 = (-1f * b - (float)Math.Sqrt((double)delta)) / 2 / a;
      res2 = (-1f * b + (float)Math.Sqrt((double)delta)) / 2 / a;
    }
    
    public static float VectorLength(float x, float y)
    {
      return x * x + y * y;
    }
    
    public static bool EpsilonEqual(float v1, float v2)
    {
      float epsilon = 0.05f;
      return (Math.Abs (v1 - v2) < epsilon);
    }
  }
}

