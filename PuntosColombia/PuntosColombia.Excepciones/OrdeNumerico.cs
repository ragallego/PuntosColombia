using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntosColombia.Excepciones
{
    public static class OrdeNumerico
    {
        public static int[] missingNumbers(int[] arr, int[] brr, out int diff)
        {
            try
            {
                //Group the values and add the Count field as the number of times repeated in the array
                var array1 = arr.GroupBy(c => c)
                             .Select(group => new
                             {
                                 Value = group.Key,
                                 Count = group.Count()
                             }).ToList();

                var array2 = brr.GroupBy(c => c)
                             .Select(group => new
                             {
                                 Value = group.Key,
                                 Count = group.Count()
                             }).ToList();

                //Produces the set difference of two sequences by using the default equality comparer to compare values
                var result = array1.Except(array2).ToList();
                var result2 = array2.Except(array1).ToList();

                //Add the result of the two arrays
                var result3 = result.Concat(result2).Select(t => t.Value).Distinct().ToList();

                //The difference between maximum and minimum number in the second list is less than or equal to 100
                diff = array2.Max(k => k.Value) - array2.Min(k => k.Value);

                return result3.Select(k => k).OrderBy(k => k).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
