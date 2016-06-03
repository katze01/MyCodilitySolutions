using System;
using System.Collections.Generic;

namespace MyCodilitySolutions.Challenges
{
    public class My2014Natrium
    {
        //codility.com/programmers/task/max_distance_monotonic/
        //长度为N的数组A中找到满足 A[P] <= A[Q] 且0<=P<=Q<N的P和Q，求解最大的Q-P
        //时间和空间复杂度都是N

        //思路：最大的Q-P就是从头到尾。所以，以第一个数为基准，找到一个递减的数组candidates。
        //然后从数组的尾巴开始循环，取一个数A和candidates对比（从最小的也是位置最靠后的）
        //若满足条件，则是一个可能的解，然后这个candidate可以丢掉了，因为如果在数A之前的数和这个candidate也是一个可能的解，它可能没有A和candidate的距离长。
        public int GetMaxDistanceMonotonic(int[] A)
        {
            List<int> candidates = new List<int>();
            candidates.Add(0);
            int lastIndex = 0;
            for (int i = 0; i < A.Length; i++)
            {
                lastIndex = candidates.Count - 1;
                if (A[i] < A[candidates[lastIndex]])
                    candidates.Add(i);
            }
            int max = 0;
            for (int i = A.Length - 1; i >= 0 && candidates.Count > 0; i--)
            {
                lastIndex = candidates.Count - 1;
                while (candidates.Count > 0 && A[i] >= A[candidates[lastIndex]])
                {
                    max = Math.Max(max, i - candidates[lastIndex]);
                    candidates.RemoveAt(lastIndex);
                    lastIndex = candidates.Count - 1;
                }
            }
            return max;
        }

        public int GetMaxDistanceMonotonic_Stack(int[] A)
        {
            Stack<int> candidates = new Stack<int>();
            candidates.Push(0);
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < A[candidates.Peek()])
                    candidates.Push(i);
            }
            int max = 0;
            for (int i = A.Length - 1; i >= 0 && candidates.Count > 0; i--)
            {
                while (candidates.Count > 0 && A[i] >= A[candidates.Peek()])
                {
                    max = Math.Max(max, i - candidates.Peek());
                    candidates.Pop();
                }
            }
            return max;
        }

        //N^2
        public int GetMaxDistanceMonotonic_BadPerformance(int[] A)
        {
            int max = 0;
            for(int i = 0; i < A.Length; i++)
            {
                for (int j = A.Length - 1; j >= i+max; j--)
                {
                    if (A[j] >= A[i])
                    {
                        max = Math.Max(max, j - i);
                        break;
                    }
                }
            }
            return max;
        }


    }
}
