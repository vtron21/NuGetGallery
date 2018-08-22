// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NuGet.Services.Search.Client
{
    public class ServiceResponse<T>
    {
        private readonly Func<Task<T>> _reader;

        public ServiceResponse(HttpResponseMessage httpResponse)
            : this(httpResponse, () => httpResponse.Content.ReadAsAsync<T>())
        {
        }

        public ServiceResponse(HttpResponseMessage httpResponse, Func<Task<T>> reader)
        {
            HttpResponse = httpResponse;
            _reader = reader;
        }

        public HttpResponseMessage HttpResponse { get; }
        public HttpStatusCode StatusCode => HttpResponse.StatusCode;
        public bool IsSuccessStatusCode => HttpResponse.IsSuccessStatusCode;
        public string ReasonPhrase => HttpResponse.ReasonPhrase;

        public Task<T> ReadContent()
        {
            return _reader();
        }
    }
}
