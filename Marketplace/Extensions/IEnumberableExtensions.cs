using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marketplace.Extensions
{
    public static class IEnumberableExtensions
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();

        public static T GetRandom<T>(this IEnumerable<T> list)
        {
            lock (syncLock)
            {
                return list.ElementAt<T>(random.Next(list.Count<T>()));
            }
        }

        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
        {
            lock (syncLock)
            {
                return source.OrderBy<T, int>((item) => random.Next());
            }
        }
    }
}
