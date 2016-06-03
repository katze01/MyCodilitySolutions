using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCodilitySolutions.Challenges
{
    public class My2013Nitrogenium
    {
        //codility.com/programmers/challenges/nitrogenium2013/
        //长度为N的数组A代表海拔为A[i]的N个点
        //长度为M的数组B代表第i天水位上涨到B[i]
        //A[P] 到A[Q] 所有的点都大于H，且A[P-1]<=H && A[Q+1]>=H时，A[P] 到A[Q] 组成一个小岛
        //求每天有几个小岛。
        //思路：假设如果水位上涨到A[i]，有2种可能行，一个岛被分成了两个岛（也就是增加了一个岛），或者仍然是一个岛（岛的个数不变）。
        // 也就是，当A[i-1] > A[i] && A[i+1] > A[i]，岛的个数+1
        //当A[i-1] > A[i] && A[i+1] < A[i]，或者A[i-1] < A[i] && A[i+1] > A[i]，岛的个数不变。

        //每个小岛都会有一个最右边的点，所以，可以数有几个最右边的点来代表数几个小岛。
        // 如果A[i]是最右边的点，那么它必须满足：
        //1.  A[i] > A[i+1] 或者 i = N-1 
        //2.  A[i] > 水位线 > A[i+1]
        //设置一个辅助的island，island[i]表示以A[i]为右边的的小岛的个数。
        //扫描一遍数组A，如果A[i - 1] > A[i]，那么，以A[i - 1]为右点的小岛+1，以A[i]为右点的小岛-1
        //当水位=H时，小岛的个数 = 以海拔大于H 为右边的小岛的个数之和
        //方便计算，island 从尾巴做一次累加，island[i]表示水位落到i-1的时候小岛之和。
        public int[] GetFloodedIsland(int[] A, int[] B)
        {
            int[] result = new int[B.Length];
            int size = Math.Max(A.Max(), B.Max());
            int[] island = new int[size+2];

            //扫描一遍数组A，当水位线位于A[i - 1] 和 A[i]之间，如果A[i - 1] > A[i]，那么以A[i - 1]为右点的小岛+1，以A[i]为右点的小岛-1
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i - 1] > A[i])
                {
                    island[A[i - 1]] += 1;
                    island[A[i]] -= 1;
                }
            }
            island[A[A.Length - 1]] += 1;

            //当水位=H时，小岛的个数 = 以海拔大于H 为右边的小岛的个数之和
            //方便计算，island 从尾巴做一次累加，island[i]表示水位落到i-1的时候小岛之和。
            for (int i = size; i >= 0; i--)
                island[i] += island[i + 1];

            for (int i = 0; i < B.Length; i++)
                result[i] = island[B[i] + 1];

            return result;
        }
    }
}
