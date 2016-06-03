using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCodilitySolutions.Challenges
{
    
    public class My2013Boron
    {
        //codility.com/programmers/task/flags/
        //长度为N的数组A中，如果A[i] > A[i - 1] && A[i] > A[i + 1]， A[i]为peak。
        //数组A中只有顶峰可以插旗
        //数组A中可以插K面旗，且旗子的间距大于K。
        //时间和控件复杂度都是N

        //思路： 辅助数组，指示下一个peak的位置。
        //循环数组，假设间隔从1 开始判断。因为N个旗子的间隔得大于N，所以只需要循环到interval * (interval - 1) <= A.Length
        public int GetFlag(int[] A)
        {
            int result = 0;
            int[] next = new int[A.Length];
            next[0] = -1;
            next[A.Length - 1] = -1;
            for (int i = A.Length - 2; i > 0; i--)
            {
                if (A[i] > A[i - 1] && A[i] > A[i + 1])
                {
                    next[i] = i;
                }
                else
                {
                    next[i] = next[i + 1];
                }
            }
            if(next.Length >1)
                next[0] = next[1];

            int interval = 1;
            while (interval * (interval - 1) <= A.Length)
            {
                int num = 0;
                int pos = 0;
                while (pos < A.Length && num < interval)
                {
                    pos = next[pos];
                    if (pos == -1)
                        break;
                    num += 1;
                    pos = pos + interval;
                }
                interval ++;
                result = Math.Max(result, num);
            }
            return result;
        }
    }
}
