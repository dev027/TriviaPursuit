using System.Collections.Generic;

namespace Tp.Common.Extensions.IListExtensions
{
    public static class IListExtensions
    {
        public static void AddRange<T>(this IList<T> list, IList<T> items)
        {
            if (items != null)
            {
                foreach (var item in items)
                {
                    list.Add(item);
                }
            }
        }
    }
}