using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var chips = new List<ColorChip>
            {
                new ColorChip(Color.Blue, Color.Yellow),
                new ColorChip(Color.Red, Color.Green),
                new ColorChip(Color.Yellow, Color.Red),
                new ColorChip(Color.Orange, Color.Purple),
                new ColorChip(Color.Blue, Color.Green),
                new ColorChip(Color.Purple, Color.Green),
                new ColorChip(Color.Purple, Color.Red),
                new ColorChip(Color.Orange, Color.Green),
                new ColorChip(Color.Green, Color.Orange)
            };

            var sortedChips = ChipSortingHelper.SortChips(chips);
            
            if (sortedChips.Any())
            {
                Console.Write("Blue ");
                foreach (var chip in sortedChips)
                {
                    Console.Write($"[{chip}] ");
                }
                Console.WriteLine("Green");
            }
            else
            {
                Console.WriteLine(Constants.ErrorMessage);
            }
        }
    }
}
