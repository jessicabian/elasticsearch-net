﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public partial class ElasticClient
	{
		/// <inheritdoc />
		public IIndicesOperationResponse CreateIndex(Func<CreateIndexDescriptor, CreateIndexDescriptor> createIndexSelector)
		{
			var descriptor = createIndexSelector(new CreateIndexDescriptor(this._connectionSettings)); 
			return this.Dispatcher.Dispatch<ICreateIndexRequest, CreateIndexRequestParameters, IndicesOperationResponse>(
				descriptor,
				(p, d) => this.LowLevelDispatch.IndicesCreateDispatch<IndicesOperationResponse>(p, d.IndexSettings)
			);
		} 

		/// <inheritdoc />
		public IIndicesOperationResponse CreateIndex(ICreateIndexRequest createIndexRequest)
		{
			return this.Dispatcher.Dispatch<ICreateIndexRequest, CreateIndexRequestParameters, IndicesOperationResponse>(
				createIndexRequest,
				(p, d) => this.LowLevelDispatch.IndicesCreateDispatch<IndicesOperationResponse>(p, d.IndexSettings)
			);
		} 

		/// <inheritdoc />
		public Task<IIndicesOperationResponse> CreateIndexAsync(Func<CreateIndexDescriptor, CreateIndexDescriptor> createIndexSelector)
		{
			var descriptor = createIndexSelector(new CreateIndexDescriptor(this._connectionSettings)); 
			return this.Dispatcher.DispatchAsync<ICreateIndexRequest, CreateIndexRequestParameters, IndicesOperationResponse, IIndicesOperationResponse>(
					descriptor,
					(p, d) => this.LowLevelDispatch.IndicesCreateDispatchAsync<IndicesOperationResponse>(p, d.IndexSettings)
				);
		}

		/// <inheritdoc />
		public Task<IIndicesOperationResponse> CreateIndexAsync(ICreateIndexRequest createIndexRequest)
		{
			return this.Dispatcher.DispatchAsync<ICreateIndexRequest, CreateIndexRequestParameters, IndicesOperationResponse, IIndicesOperationResponse>(
				createIndexRequest,
				(p, d) => this.LowLevelDispatch.IndicesCreateDispatchAsync<IndicesOperationResponse>(p, d.IndexSettings)
			);
		}

	}
}