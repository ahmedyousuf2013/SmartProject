﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartProject.Model.Common.Networking
{
    public class InvocationDescriptor
    {
        /// <summary>
        /// Gets or sets the name of the remote method.
        /// </summary>
        /// <value>The name of the remote method.</value>
        [JsonProperty("methodName")]
        public string MethodName { get; set; }

        /// <summary>
        /// Gets or sets the arguments passed to the method.
        /// </summary>
        /// <value>The arguments passed to the method.</value>
        [JsonProperty("arguments")]
        public object[] Arguments { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier used to associate return values with this call.
        /// </summary>
        /// <value>The unique identifier of the invocation.</value>
        [JsonProperty("identifier")]
        public Guid Identifier { get; set; } = Guid.Empty;
    }
}
