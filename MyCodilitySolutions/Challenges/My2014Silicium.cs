using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCodilitySolutions.Challenges
{
    public class My2014Silicium
    {
        //codility.com/programmers/task/cutting_the_cake/
        //有一个X*Y 的矩形，数组A和数组B的长度都为N， 数组A 表示在边X上切N刀，每刀的位置用A[I]表示， 数组B 表示在边Y上切N刀，每刀的位置用B[I]表示，切完之后，矩形变成了（N+1）^2 片，按面积从大到小排序，求第K片的面积。
        //时间复杂度O(N*log(N+X+Y));
        //空间复杂度O(N)

        //思路：可以计算出若干个长方形的长的数组，宽的数组，从小到大排序，然后二分法求面积大于X的有多少个。
        //难点在于怎么找出面积大于X的长方形的个数。
        //长和宽两个数组，一个从头扫，一个从尾扫，因为都是从小到大排序，因此，当i-1 * j 大于给定的面积，i * j一定也大于给定的面积。
        public int GetCuttingTheCake(int X, int Y, int K, int[] A, int[] B)
        {
            int[] widthArray = new int[A.Length + 1];
            widthArray[0] = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                widthArray[i] = A[i] - A[i - 1];
            }
            widthArray[widthArray.Length - 1] = X - A[A.Length - 1];

            int[] heightArray = new int[B.Length + 1];
            heightArray[0] = B[0];
            for (int i = 1; i < B.Length; i++)
            {
                heightArray[i] = B[i] - B[i - 1];
            }

            heightArray[heightArray.Length - 1] = Y - B[B.Length - 1];

            Array.Sort(widthArray);
            Array.Sort(heightArray);

            //切片的面积最小为1，最大为最长的长和宽相乘;
            int max = widthArray[widthArray.Length - 1] * heightArray[heightArray.Length - 1];
            int min = widthArray[0] * heightArray[0];
            int mid = 0;
            if (min == max || K == (widthArray.Length) * (heightArray.Length))
                return min;
            if (K == 1)
                return max;

            while (min <= max)
            {
                //取个中间值，如果面积比mid大的切片大于K，说明第K大的切片的面积在mid和max之间。反之亦然。
                mid = (max + min) / 2;
                int num = NumberOfGreater(widthArray, heightArray, mid);
                if (num >= K)
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                }
            }
            return max+1;
        }

        private int NumberOfGreater(int[] widthArray, int[] heightArray, int size)
        {
            int count = 0;

            for (int i = 0, j = heightArray.Length - 1; i < widthArray.Length; ++i)
            {
                for (; (j >= 0) && (widthArray[i]*heightArray[j] > size); j--)
                    ;
                count += widthArray.Length - 1 - j;
            }
            return count;
        }
    }
}
