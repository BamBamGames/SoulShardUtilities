namespace SoulShard.Utils
{
    /// <summary>
    /// provides multiple basic math functions, not included in UnityEngine.mathf
    /// </summary>
    public partial struct MathUtility
    {
        public static uint PositiveMod(int value, uint m)
        {
            int mod = value % (int)m;
            if (mod < 0)
                mod += (int)m;
            return (uint)mod;
        }
        public static int PositiveMod(int value, int m)
        {
            int mod = value % m;
            if (mod < 0)
                mod += m;
            return mod;
        }
        public static float PositiveMod(float value, float m)
        {
            float mod = value % m;
            if (mod < 0)
                mod += m;
            return mod;
        }
    }
}
