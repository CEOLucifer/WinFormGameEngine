using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Com.WWZ.WinFormGameEngine
{
    /// <summary>
    /// 提供数学函数和常量
    /// </summary>
    public static class Mathf
    {
        public const float Deg2Rad = 0.01745329f;
        public const float Rad2Deg = 57.2957795f;

        private static Random r = new Random();

        public static float Lerp(float begin, float end, float t)
        {
            return begin + (end - begin) * t;
        }

        public static Vector2 Lerp(Vector2 begin, Vector2 end, float t)
        {
            Vector2 dir = end - begin;

            float magnitude = (float)Mathf.MagnitudeOfVector2(dir);

            // 如果magnitude为0，则返回begin。避免后面单位化dir时是零向量
            if (magnitude == 0.0f)
                return begin;

            return begin + Vector2.Normalize(dir) * magnitude * t;
        }

        public static double MagnitudeOfVector2(Vector2 vector)
        {
            return Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2));
        }

        /// <summary>
        /// 旋转一个向量
        /// </summary>
        /// <param name="v"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static Vector2 RotateVector2(Vector2 v, float angle)
        {
            Matrix4x4 m1 = Matrix4x4.CreateRotationZ(-angle * Deg2Rad);
            Matrix4x4 m2 = CreateVectorMatrix(v);
            Matrix4x4 m3 = m1 * m2;
            return new Vector2(m3.M11, m3.M21);
        }

        public static float Sin(float value)
        {
            return (float)Math.Sin(value * Deg2Rad);
        }

        public static float Cos(float value)
        {
            return (float)Math.Cos(value * Deg2Rad);
        }

        /// <summary>
        /// 创建点的4x4矩阵
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Matrix4x4 CreatePointMatrix(Vector2 v)
        {
            return new Matrix4x4
            (
                v.X, 0, 0, 0,
                v.Y, 0, 0, 0,
                0, 0, 0, 0,
                1, 0, 0, 0
            );
        }

        /// <summary>
        /// 创建向量的4x4矩阵
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Matrix4x4 CreateVectorMatrix(Vector2 v)
        {
            return new Matrix4x4
            (
                v.X, 0, 0, 0,
                v.Y, 0, 0, 0,
                0, 0, 0, 0,
                0, 0, 0, 0
            );
        }

        /// <summary>
        /// 创建平移矩阵
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Matrix4x4 CreateTranslation(Vector2 v)
        {
            return new Matrix4x4
                          (
                              1, 0, 0, v.X,
                              0, 1, 0, v.Y,
                              0, 0, 1, 0,
                              0, 0, 0, 1
                          );
        }

        /// <summary>
        /// 创建旋转矩阵
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static Matrix4x4 CreateRotation(float angle)
        {
            return Matrix4x4.CreateRotationZ(-angle * Mathf.Deg2Rad);
        }

        /// <summary>
        /// 随机产生一定范围内的float
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float RandomRangeFloat(float min, float max)
        {
            return (float)(min + (max - min) * r.NextDouble());
        }

        public static int RandomRangeInt(int min, int max)
        {
            return r.Next(min, max + 1);
        }

        public static int ScrollUpInt(int cur, int min, int max)
        {
            cur++;
            if (cur > max)
                cur = min;
            return cur;
        }

        public static int ScrollDownInt(int cur, int min, int max)
        {
            cur--;
            if (cur < min)
                cur = max;
            return cur;
        }
    }
}
