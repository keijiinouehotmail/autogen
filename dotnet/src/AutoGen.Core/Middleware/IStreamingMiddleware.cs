﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// IStreamingMiddleware.cs

using System.Collections.Generic;
using System.Threading;

namespace AutoGen.Core;

/// <summary>
/// The streaming middleware interface
/// </summary>
public interface IStreamingMiddleware
{
    public string? Name { get; }

    public IAsyncEnumerable<IStreamingMessage> InvokeAsync(
        MiddlewareContext context,
        IStreamingAgent agent,
        CancellationToken cancellationToken = default);
}
