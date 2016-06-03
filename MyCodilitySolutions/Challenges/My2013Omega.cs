using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCodilitySolutions.Challenges
{
    public class My2013Omega
    {
        //codility.com/programmers/challenges/omega2013/
        //长度为N的数组A代表N个圆环，A[i]代表第i个环的直径。圆环的厚度为1
        //长度为M的数组B代表M个盘子，B[i]代表第i个盘子的直径。盘子的厚度也为1.
        //有个高度为N的井，把圆环按顺序从井底往上放,A[N]在井底，A[0]在顶上
        //把盘子按顺序扔进井里，如果圆环的直径大于等于盘子的直径，那么盘子可以穿过圆环，否则，会叠在圆环上。
        //求第几个盘子可以刚好放入井里。
        //时间和空间复杂度都是O（N）

        //思路：用数组A标记多大的盘子可以到达A[i]位置，这样对每个往下落的盘子，从最底部开始判断
        public int GetFallingDisks(int[] A, int[] B)
        {
            int[] fall = new int[A.Length];
            fall[0] = A[0];
            for (int i = 1; i < A.Length; i++)
                fall[i] = Math.Min(fall[i-1], A[i]);

            int height = A.Length;
            int k = 0;
            for (; k < B.Length && height>0; k++)
            {
                while (height>0 && fall[height-1] < B[k])
                {
                    height--;
                }
                if (height > 0)
                    height--;
                else if (height == 0)
                    return k;
            }
            return k;
        }
    }
}
