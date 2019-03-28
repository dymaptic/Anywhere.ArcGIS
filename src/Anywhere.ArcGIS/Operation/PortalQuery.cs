using Anywhere.ArcGIS.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

namespace Anywhere.ArcGIS.Operation
{
    public class PortalQuery : ArcGISServerOperation
    {
        public PortalQuery(string relativeUrl, Action beforeRequest = null, Action afterRequest = null)
            : this(relativeUrl.AsPortalEndpoint(), beforeRequest, afterRequest)
        { }

        /// <summary>
        /// Represents a request for a query against a Portal service resource
        /// </summary>
        /// <param name="endpoint">Resource to apply the query against</param>
        public PortalQuery(ArcGISPortalEndpoint endpoint, Action beforeRequest = null, Action afterRequest = null)
            : base(endpoint, beforeRequest, afterRequest)
        {
        }
        
    }

    public class PortalQueryResponse : PortalResponse
    {
        //[DataMember(Name = "type")]
        //public string Type { get; set; }

        [DataMember(Name = "jsonObject")]
        public string JsonObject { get; set; }
    }
}
