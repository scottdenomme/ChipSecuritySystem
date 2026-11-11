using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    public static class ChipSortingHelper
    {
        public static IEnumerable<ColorChip> SortChips(IEnumerable<ColorChip> chips)
        {
            var startColor = Color.Blue;
            var endColor = Color.Green;
            var chipList = chips.ToList();

            List<int> best = null;

            var stack = new Stack<List<int>>();
            stack.Push(new List<int>());

            while (stack.Count > 0)
            {
                var chain = stack.Pop();
                var current = chain.Count == 0 ? startColor : chipList[chain.Last()].EndColor;

                if (chain.Count > 0 && current == endColor && (best == null || chain.Count > best.Count))
                    best = chain;

                for (int i = 0; i < chipList.Count; i++)
                {
                    if (chipList[i].StartColor == current && !chain.Contains(i))
                    {
                        var newChain = new List<int>(chain);
                        newChain.Add(i);
                        stack.Push(newChain);
                    }
                }
            }

            return best?.Select(c => chipList[c]).ToList() ?? new List<ColorChip>();
        }
    }
}