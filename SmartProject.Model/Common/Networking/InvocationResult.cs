using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartProject.Model.Common.Networking
{
    public class InvocationResult
    {
        /// <summary>
        /// Gets or sets the unique identifier associated with the invocation.
        /// </summary>
        /// <value>The unique identifier of the invocation.</value>
        [JsonProperty("identifier")]
        public Guid Identifier { get; set; }

        /// <summary>
        /// Gets or sets the result of the method call.
        /// </summary>
        /// <value>The result of the method call.</value>
        [JsonProperty("result")]
        public object Result { get; set; }

        /// <summary>
        /// Gets or sets the remote exception the method call caused.
        /// </summary>
        /// <value>The remote exception of the method call.</value>
        [JsonProperty("exception")]
        public RemoteException Exception { get; set; }
    }
}
