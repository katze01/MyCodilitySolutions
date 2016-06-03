using System.Collections.Generic;

namespace MyCodilitySolutions.Challenges
{
    public class My2014Oxygenium
    {
        //codility.com/programmers/task/count_bounded_slices/
        //长度为N的数组A，有这样的子数组，{ A[P], A[P+1], ... A[Q] }， 0 ≤ P ≤ Q < N，最大值和最小值的差 <= K
        // 求解A中这样的的数组的个数，超过1,000,000,000返回1,000,000,000。
        // 时间和空间复杂度都是N。

        //思路：设置两个数组，一个存放最小值，一个存放最大值
        //遍历一遍数组A，针对每个值A[i]，如果都会把它后面的数按小到大的顺序放进数组min，从大到小放入数组max
        //直到最大的max比最小的min大于K，此时对比到A[j]
        //那么我们可以得出结论，(i,j)，(i+1,j)， (i+2,j).... (j,j)都满足条件，因此有j-i 种。
        //如果最大值或者最小值正好等于A[i]，就要舍弃，因为下一次会寻找从A[i+1]往后的满足条件的数组
        public int GetCountBoundedSlices(int K, int[] A)
        {
            int result = 0;
            List<int> minList = new List<int>();
            List<int> maxList = new List<int>();

            int j = 0;
            int last = 0;
            for (int i = 0; i < A.Length; i++)
            {
                while (j < A.Length)
                {
                    last = minList.Count - 1;
                    while (minList.Count > 0 && (A[minList[last]] >= A[j]))
                    {
                        minList.RemoveAt(last);
                        last = minList.Count - 1;
                    }
                    minList.Add(j);

                    last = maxList.Count - 1;
                    while (maxList.Count > 0 && (A[maxList[last]] <= A[j]))
                    {
                        maxList.RemoveAt(last);
                        last = maxList.Count - 1;
                    }
                    maxList.Add(j);

                    if (A[maxList[0]] - A[minList[0]] <= K)
                    {
                        j++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (minList[0] == i)
                {
                    minList.RemoveAt(0);
                }

                if (maxList[0] == i)
                {
                    maxList.RemoveAt(0);
                }

                result += j - i;
                if (result >= 1000000000)
                {
                    return 1000000000;
                }
            }
            return result;
        }
    }
}
