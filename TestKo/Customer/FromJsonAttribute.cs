using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace System.Web.Mvc
{
    public class FromJsonAttribute : CustomModelBinderAttribute
    {
        private readonly static JavaScriptSerializer serializer = new JavaScriptSerializer();

        public override IModelBinder GetBinder()
        {
            return new JsonModelBinder();
        }

        private class JsonModelBinder: IModelBinder
        {
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                var stringfied = controllerContext.HttpContext.Request[bindingContext.ModelName];
                if(string.IsNullOrEmpty(stringfied)){
                    return null;
                }

                return serializer.Deserialize(stringfied, bindingContext.ModelType);
            }
        }
    }
}