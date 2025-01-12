// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Yarp.ReverseProxy.Service.RuntimeModel.Transforms;

namespace Yarp.ReverseProxy.Abstractions.Config
{
    /// <summary>
    /// State used when building transforms for the given route.
    /// </summary>
    public class TransformBuilderContext
    {
        /// <summary>
        /// Application services that can be used to construct transforms.
        /// </summary>
        public IServiceProvider Services { get; init; }

        /// <summary>
        /// The route these transforms will be associated with.
        /// </summary>
        public ProxyRoute Route { get; init; }

        /// <summary>
        /// The cluster config the route is associated with.
        /// </summary>
        public Cluster Cluster { get; init; }

        /// <summary>
        /// Indicates if request headers should all be copied to the proxy request before transforms are applied.
        /// </summary>
        public bool? CopyRequestHeaders { get; set; }

        /// <summary>
        /// Indicates if response headers should all be copied to the client response before transforms are applied.
        /// </summary>
        public bool? CopyResponseHeaders { get; set; }

        /// <summary>
        /// Indicates if response trailers should all be copied to the client response before transforms are applied.
        /// </summary>
        public bool? CopyResponseTrailers { get; set; }

        /// <summary>
        /// Indicates if default x-fowarded-* transforms should be added to this route. Disable this if you do not want
        /// x-forwarded-* headers or have configured your own.
        /// </summary>
        public bool? UseDefaultForwarders { get; set; }

        /// <summary>
        /// Add request transforms here for the given route.
        /// </summary>
        public IList<RequestTransform> RequestTransforms { get; } = new List<RequestTransform>();

        /// <summary>
        /// Add response transforms here for the given route.
        /// </summary>
        public IList<ResponseTransform> ResponseTransforms { get; } = new List<ResponseTransform>();

        /// <summary>
        /// Add response trailers transforms here for the given route.
        /// </summary>
        public IList<ResponseTrailersTransform> ResponseTrailersTransforms { get; } = new List<ResponseTrailersTransform>();
    }
}
