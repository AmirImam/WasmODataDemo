/*
*
* Generated At 02/15/2022 11:55:54 AM Amir Imam (ai_1583@hotmail.com)
*
*/

using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using WasmODataDemo.Entities;

namespace WasmODataDemo.API
{
    public static class ODataServerConfiguration
    {
        //You must call this method Like: services.AddControllers().ConfigOData();

        public static IMvcBuilder ConfigOData(this IMvcBuilder builder)
        {
            builder.AddOData(opt =>
            {
                opt.Select().Filter().Expand().Count().OrderBy().SetMaxTop(null);
                opt.AddRouteComponents("odata", GetOdataModel());
            });
            return builder;
        }
        private static IEdmModel GetOdataModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>(nameof(Product));

            return builder.GetEdmModel();
        }
    }
}