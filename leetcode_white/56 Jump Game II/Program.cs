using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _56_Jump_Game_II
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 1, 1, 1 };
            Solution3 solution = new Solution3();
            int ret = solution.Jump(nums);
            Console.WriteLine(ret);
            Console.ReadLine();
        }
    }
    public class Solution
    {
        public int Jump(int[] nums)
        {
            //这次变成最小的步数了。。。。
            //每次优先选择用光油的位置，然后选择留一点油的位置，然后选择，留两点油的位置。
            //上面那一个是判断能不能到，这次是判断怎样步数最少。（每次选择最大的）
            int CurrentPosition = 0;
            int CurrentMax = nums[0];
            int StepNum = 0;
            //你可以假设你你自己总是可以到达最后的位置？？？？
            //局部最优问题_局部最小的结果也是全局最优化的结果，你只需要让局部得到最优解就行了
            //在本题中，也就是用尽可能小的步数到达某个位置。
            for (int i = 0; i < nums.Length - 1; i++)
            {
                //你虽然理论上可以循环这么多次数，但是实际情况是，你可以中途用条件判断终止循环，也就是CurrentLength ==nums.Length-1;
                //相对于上一个题的不同，就是要统计步数。
                if (CurrentPosition == nums.Length - 1)
                {
                    break;
                }
                //如果碰上一个0，就直接退出循环
                if (CurrentPosition + CurrentMax >= nums.Length - 1)
                {
                    StepNum++;
                    break;
                }
                int NextMax = nums[CurrentPosition + CurrentMax];
                int NextPosition = CurrentMax + CurrentPosition;
                int j = 0;

                //总是有index out of range的情况
                for (j = CurrentMax - 1; j > 0; j--)
                {
                    ///增加条件，专门应对10 9 8 问题，也就是，如果你当前步长的位置其实是小于等于其余步长
                    if (nums[CurrentPosition + j] + j <= CurrentMax + nums[CurrentPosition + CurrentMax])
                    {
                        continue;
                    }
                    //正常的核心逻辑语句
                    if ((nums[CurrentPosition + j] <= NextMax)) continue;
                    //[10,9,8,7,6,5,4,3,2,1,1,0]这种问题，就很麻烦，因为我们会遇到说，其实第一步就是最优解走一步，再走9步 和 走一下子走10步之间的差距。。。。这种情况，必须单独处理
                    else if (nums[CurrentPosition + j] > NextMax)
                    {
                        NextMax = nums[CurrentPosition + j];
                        NextPosition = CurrentPosition + j;
                    }
                }
                //进行数据的更新，全部移动到下一个位置
                CurrentPosition = NextPosition;
                CurrentMax = nums[CurrentPosition];
                StepNum++;
            }
            return StepNum;
        }
    }

    public class Solution2
    {
        public int Jump(int[] nums)
        {

            //这次变成最小的步数了。。。。
            //每次优先选择用光油的位置，然后选择留一点油的位置，然后选择，留两点油的位置。
            //上面那一个是判断能不能到，这次是判断怎样步数最少。（每次选择最大的）
            int CurrentPosition = 0;
            int CurrentMax = nums[0];
            int StepNum = 0;
            //你可以假设你你自己总是可以到达最后的位置？？？？
            //局部最优问题_局部最小的结果也是全局最优化的结果，你只需要让局部得到最优解就行了
            //在本题中，也就是用尽可能小的步数到达某个位置。
            for (int i = 0; i < nums.Length - 1; i++)
            {
                //你虽然理论上可以循环这么多次数，但是实际情况是，你可以中途用条件判断终止循环，也就是CurrentLength ==nums.Length-1;
                //相对于上一个题的不同，就是要统计步数。
                if (CurrentPosition == nums.Length - 1)
                {
                    break;
                }
                //一种情况是，刚才已经到了最后index

                if (CurrentPosition + CurrentMax >= nums.Length - 1)
                {
                    StepNum++;
                    break;
                }
                //一种情景是，只需要再走一步就会到达最后的位置。
                int NextMax = nums[CurrentPosition + CurrentMax];
                int NextPosition = CurrentMax + CurrentPosition;
                int j = 0;

                //总是有index out of range的情况
                for (j = CurrentMax - 1; j > 0; j--)
                {
                    ///增加条件，专门应对10 9 8 问题，也就是，如果你当前步长的位置其实是小于等于其余步长
                    if (nums[CurrentPosition + j] + j < CurrentMax + nums[CurrentPosition + CurrentMax])
                    {
                        continue;
                    }
                    //正常的核心逻辑语句
                    if ((nums[CurrentPosition + j] <= NextMax)) continue;
                    //[10,9,8,7,6,5,4,3,2,1,1,0]这种问题，就很麻烦，因为我们会遇到说，其实第一步就是最优解走一步，再走9步 和 走一下子走10步之间的差距。。。。这种情况，必须单独处理
                    else if (nums[CurrentPosition + j] > NextMax)
                    {
                        NextMax = nums[CurrentPosition + j];
                        NextPosition = CurrentPosition + j;
                    }
                }
                //进行数据的更新，全部移动到下一个位置
                CurrentPosition = NextPosition;
                CurrentMax = nums[CurrentPosition];
                StepNum++;
            }
            return StepNum;
        }
    }

    //[2,3,5,9,0,9,7,2,7,9,1,7,4,6,2,1,0,0,1,4,9,0,6,3] 这种问题很难处理。。。。。

    //处理12111问题
    //最大是3，我们返回的是4



        //成功的4号方案，
    public class Solution4
    {
        public int Jump(int[] nums)
        {
            if (nums.Length < 2)
            {
                return 0;
            }

            int StepNum = 0;
            //统一的用绝对位置进行标注
            int CurrentIndex = 0;

            int MinIndex = 1 + CurrentIndex;
            int MaxIndex = nums[CurrentIndex] + CurrentIndex;

            int NextIndex = MinIndex;
            int NextMax = nums[MinIndex] + MinIndex;
            //可以获得的最小的Index和最大的Index
            //nums.Length-1是最后一个index

            //处理不了出现0的问题。因为出现0之后，MinRange和MaxRange会相互冲突
            while (CurrentIndex < nums.Length - 1)
            {
                if (MaxIndex >= nums.Length - 1)
                {
                    StepNum++;
                    return StepNum;
                }
                for (int i = MinIndex; i <= MaxIndex; i++)
                {
                    if (NextMax < nums[i] + i)
                    {
                        NextMax = nums[i] + i;
                        NextIndex = i;
                    }
                    //走原来的那一步和走新的这一步，其实最后的步数和到达的Edge都是一样的位置。
                    else if (NextMax >= nums[i] + i)
                    {
                        continue;
                    }
                }
                StepNum++;
                //在找到最大的之后，就是直接将NextIndex进行赋值操作。
                CurrentIndex = NextIndex;
                //CurrentIndex的下一个就是nums.Length-1
                if (CurrentIndex == nums.Length - 2)
                {
                    StepNum++;
                    return StepNum;
                }
                else if (CurrentIndex >= nums.Length - 1)
                {
                    return StepNum;
                }
                MinIndex = CurrentIndex + 1;
                MaxIndex = CurrentIndex + nums[CurrentIndex];

                NextIndex = MinIndex;
                NextMax = nums[MinIndex] + MinIndex;
            }
            return StepNum;
        }
    }
    //现在的问题就是为什么会出现越界的情况1？
}
