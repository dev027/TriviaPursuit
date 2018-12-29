using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Linq;

namespace Tp.Website.Helpers
{
    public static class ModelStateHelper
    {

        public static string SerializeErrors(this ModelStateDictionary modelState)
        {
            var errors = modelState.ToDictionary(kvp => kvp.Key,
                    kvp => kvp.Value.Errors
                        .Select(e => e.ErrorMessage).ToArray())
                .Where(m => m.Value.Any());

            return JsonConvert.SerializeObject(errors);
        }
        ////public static string SerializeErrors(this ModelStateDictionary modelState)
        ////{
        ////    var errors = modelState.ToDictionary(kvp => kvp.Key,
        ////            kvp => kvp.Value.Errors
        ////                .Select(e => e.ErrorMessage).ToArray())
        ////        .Where(m => m.Value.Any());

        ////    return JsonConvert.SerializeObject(errors);
        ////}

    }
}