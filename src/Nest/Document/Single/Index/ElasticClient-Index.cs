﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public partial class ElasticClient
	{
		/// <inheritdoc />
		public IIndexResponse Index<T>(T @object, Func<IndexDescriptor<T>, IndexDescriptor<T>> indexSelector = null)
			where T : class
		{
			@object.ThrowIfNull("object");
			indexSelector = indexSelector ?? (s => s);
			var descriptor = indexSelector(new IndexDescriptor<T>().IdFrom(@object));
			return this.Dispatcher.Dispatch<IndexDescriptor<T>, IndexRequestParameters, IndexResponse>(
				descriptor,
				(p, d) => this.LowLevelDispatch.IndexDispatch<IndexResponse>(p, @object));
		}

		/// <inheritdoc />
		public IIndexResponse Index<T>(IIndexRequest<T> indexRequest)
			where T : class
		{
			return this.Dispatcher.Dispatch<IIndexRequest<T>, IndexRequestParameters, IndexResponse>(
				indexRequest,
				(p, d) => this.LowLevelDispatch.IndexDispatch<IndexResponse>(p, indexRequest.Document));
		}

		/// <inheritdoc />
		public Task<IIndexResponse> IndexAsync<T>(T @object, Func<IndexDescriptor<T>, IndexDescriptor<T>> indexSelector = null)
			where T : class
		{
			@object.ThrowIfNull("object");
			indexSelector = indexSelector ?? (s => s);
			var descriptor = indexSelector(new IndexDescriptor<T>().IdFrom(@object));
			return this.Dispatcher.DispatchAsync<IndexDescriptor<T>, IndexRequestParameters, IndexResponse, IIndexResponse>(
				descriptor,
				(p, d) => this.LowLevelDispatch.IndexDispatchAsync<IndexResponse>(p, @object));
		}

		/// <inheritdoc />
		public Task<IIndexResponse> IndexAsync<T>(IIndexRequest<T> indexRequest)
			where T : class
		{
			return this.Dispatcher.DispatchAsync<IIndexRequest<T>, IndexRequestParameters, IndexResponse, IIndexResponse>(
				indexRequest,
				(p, d) => this.LowLevelDispatch.IndexDispatchAsync<IndexResponse>(p, indexRequest.Document));
		}

	}
}