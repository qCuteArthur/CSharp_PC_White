using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _55_Jump_Game
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Solution
    {
        public bool CanJump(int[] nums)
        {
            //不是简单的直接距离相加，每个位置是你当前可以跳的最远距离而不是唯一距离。
            int Length = nums.Length;
            int curPos = 0;
            while (curPos < Length - 1)
            {
                //如果遇到的是0，说明你这辈子是到不了最后的位置了。GG。
                if (nums[curPos] == 0)
                {
                    return false;
                }
                //距离肯定是一开始加最大的，如果最大的>=length-1,就肯定能到达最后。
                curPos = curPos + nums[curPos];
                if (curPos >= Length - 1)
                {
                    return true;
                }
            }
            //如果当前位置加最大，到不了最后的位置，并不能一定说明到不了在最后比如23104这种，2+1并不可以到达最后，反而是1+3可以到达最后位置。
            //难道应该从最后一个index开始？？？
            return (curPos == (Length - 1) ? true : false);
        }
    }
    public class Solution2
    {
        public bool CanJump(int[] nums)
        {
            //我想如果是从最后的位置开始是不是会有更好的结果？
            //因为从正面实在是费事
            if ((nums.Length < 2) && (nums[0] > 0))
            {
                return true;
            }
            if (nums.Length == 1)
            {
                return true;
            }
            int currentPosition = 0;
            int LeftToJump = nums[currentPosition];
            //一开始是2，我们先走一步如果新的位置的元素大于我们当前的剩余步数也就是说，通过本部+下一步，我们可以超过当前的一步。
            //我觉得，这种问题，局部最优解不太可能是全局最优解。

            //这个题，不是为了让走的步数最少，而是让你走的时候，尽可能的走到所有的位置，你走的位置越多越好。
            //比如一开始13 还是21，走13并不是真的13，很可能你走的是11，这个题，走过的位置越多越好，这就是核心
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    return false;
                }
                LeftToJump--;
                if (nums[i] > LeftToJump)
                {
                    LeftToJump = nums[i];
                }
                else if (nums[i] < LeftToJump)
                {
                    continue;
                }
            }
            return true;
            //理解为开车！
            //默认是一步一步的走，如果说，走了1步之后，发现当前的gas比你剩下的还多。。。。
        }
    }

    public class Solution3
    {
            public bool CanJump(int[] nums)
            {
                int Gas = nums[0];
                int currentLength = 0;
                for (int i = 1; i < nums.Length; i++)
                {
                    Gas--;
                    currentLength++;

                    if (currentLength == nums.Length)
                    {
                        return true;
                    }
                    if (Gas < 0)
                    {
                        return false;
                    }
                    //如果当前的station的gas大于整个历程，直接true
                    if (nums[i] < Gas)
                    {
                        continue;
                    }
                    //当前位置走了一个
                    if (Gas <= nums[i])
                    {
                        //如果当前加油站的Gas比你剩下的还多，直接排空油箱，换新油。
                        Gas = nums[i];
                    }
                }
                return true;
        }
    }
}
