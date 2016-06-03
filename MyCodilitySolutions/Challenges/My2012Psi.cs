using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCodilitySolutions.Challenges
{
    public class My2012Psi
    {
        //codility.com/programmers/task/wire_burnouts/
        //有一个N*N的矩阵，ABC都是长度为M的数组。
        //电流可以从（0,0）到达（N-1，N-1）
        //在第T秒，如果 C[T] = 0 ， 那么  (A[T], B[T]) 到(A[T], B[T] + 1) 不通
        //如果C[T] = 1 ， 那么  (A[T], B[T]) 到(A[T] + 1, B[T]) 不通
        //求解第？秒时，电流无法从（0，0）到达（N-1，N-1）
        // 时间复杂度 O(N^2 * logN) ，空间 复杂度O(N^2)。

        //使用union-find算法。倒过来做，把第T个时间烧断的线路接上，如果（0，0）和（N-1，N-1）有连接，说明T+1断。
        //为每个点命名。点（0，0）命名为0，点（N-1，N-1）命名为N * N -1，点（i，j）命名为 i* N + j 

      
        private int[][] f;
        public int GetWireBurnouts(int N, int[] A, int[] B, int[] C)
        {
            int numbers = N*N;
            int i = 0;

            //边
            int[][] e = new int[N][];
            for (i = 0; i < N; ++i)
            {
                e[i] = new int[N];
            }
            for (i = 0; i < A.Length; ++i)
            {
                if (C[i] == 1)
                {
                    e[A[i]][B[i]] &= 11;
                    e[A[i] + 1][B[i]] &= 14;
                }
                else
                {
                    e[A[i]][B[i]] &= 13;
                    e[A[i]][B[i] + 1] &= 7;
                }
            }  

            f = new int[numbers][];  
            for (; i < numbers; i++)
            {
                f[i] = new int[]{i, -1, -1, -1 };
            }

            //for (i = 0; i < N; ++i)
            //{
            //    for (int j = 0; j < N; ++j)
            //    {
            //        if ((i + 1 < N) && (e[i][j] & 4))
            //        {
            //            MakeUnion(i * N + j, (i + 1) * N + j);
            //        }
            //        if ((j + 1 < N) && (e[i][j] & 2))
            //        {
            //            MakeUnion(i * N + j, i * N + j + 1);
            //        }
            //    }

            //}
            if (IsConnected(0, numbers - 1))
            {
                return -1;
            }  

            //倒过来看，如果时间 i 被烧掉的点被加回来，0到N就链接起来了，说明i+1就是不连接的时间。
            i = A.Length - 1;
            for (; i >= 0; i--)
            {
                if (C[i] == 0)
                    MakeUnion(A[i]* N + B[i], A[i + 1]* N + B[i]);
                else if(C[i] == 1)
                    MakeUnion(A[i]* N + B[i], A[i]* N + B[i + 1]);

                if (IsConnected(0, numbers - 1))
                    break;
            }
            return i+1;
        }

        private void MakeUnion(int x, int y)
        {
            if (!IsConnected(x, y))
            {
                //f[x] = y;
            }  
        }

        /// <summary>
        /// X 和 Y 是否连接
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private bool IsConnected(int x, int y)
        {
            //return (x == f[x]) ? x : (f[x] = Find(f[x]));
            return false;
        }

    }
}
