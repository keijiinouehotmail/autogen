// Copyright (c) Microsoft Corporation. All rights reserved.
// DelegateStreamingMiddleware.cs

using System.Collections.Generic;
using System.Threading;

namespace AutoGen.Core;

internal class DelegateStreamingMiddleware : IStreamingMiddleware
{
    public delegate IAsyncEnumerable<IStreamingMessage> MiddlewareDelegate(
        MiddlewareContext context,
        IStreamingAgent agent,
        CancellationToken cancellationToken);

    private readonly MiddlewareDelegate middlewareDelegate;

    public DelegateStreamingMiddleware(string? name, MiddlewareDelegate middlewareDelegate)
    {
        this.Name = name;
        this.middlewareDelegate = middlewareDelegate;
    }

    public string? Name { get; }

    public IAsyncEnumerable<IStreamingMessage> InvokeAsync(
               MiddlewareContext context,
               IStreamingAgent agent,
               CancellationToken cancellationToken = default)
    {
        var messages = context.Messages;
        var options = context.Options;

        return this.middlewareDelegate(context, agent, cancellationToken);
    }
}

