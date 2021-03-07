using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using Developer.WebApi.FilterEngine;

namespace Developer.WebApi.Providers
{
    public class FilterModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (context.Metadata.ContainerType == typeof(FilterModel))
                return null;
            //return context.Metadata.ModelType == typeof(String) ? new FilterModelBinder() : null;


            if (context.Metadata.ModelType == typeof(FilterModel))
            {
                return new BinderTypeModelBinder(typeof(FilterModelBinder));
            }

            return null;
        }
    }
}
