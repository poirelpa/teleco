using System;
using System.Threading.Tasks;

namespace Teleco
{
    public class Button
    {
        public int Id { get; set; }

        public bool Repeatable { get; set; }

        public string Url { get; set; }

        public int[] IR { get; set; }
    }
}