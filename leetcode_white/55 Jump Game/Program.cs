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
}
