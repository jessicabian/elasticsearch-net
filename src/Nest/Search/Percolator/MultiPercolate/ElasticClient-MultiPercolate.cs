﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	using MultiPercolateConverter = Func<IElasticsearchResponse, Stream, MultiPercolateResponse>;
	
	public partial class ElasticClient
	{
		/// <inheritdoc />
		public IMultiPercolateResponse MultiPercolate(Func<MultiPercolateDescriptor, MultiPercolateDescriptor> multiPercolateSelector)
		{
			multiPercolateSelector.ThrowIfNull("MultiPercolateSelector");
			var descriptor = multiPercolateSelector(new MultiPercolateDescriptor());
			return this.Dispatcher.Dispatch<MultiPercolateDescriptor, MultiPercolateRequestParameters, MultiPercolateResponse>(
				descriptor,
				(p, d) =>
				{
					var json = Serializer.SerializeMultiPercolate(d);
					return this.LowLevelDispatch.MpercolateDispatch<MultiPercolateResponse>(p, json);
				}
			);
		}

		/// <inheritdoc />
		public IMultiPercolateResponse MultiPercolate(IMultiPercolateRequest multiRequest)
		{
			return this.Dispatcher.Dispatch<IMultiPercolateRequest, MultiPercolateRequestParameters, MultiPercolateResponse>(
				multiRequest,
				(p, d) =>
				{
					var json = Serializer.SerializeMultiPercolate(d);
					return this.LowLevelDispatch.MpercolateDispatch<MultiPercolateResponse>(p, json);
				}
			);
		}

		/// <inheritdoc />
		public Task<IMultiPercolateResponse> MultiPercolateAsync(Func<MultiPercolateDescriptor, MultiPercolateDescriptor> multiPercolateSelector)
		{
			multiPercolateSelector.ThrowIfNull("MultiPercolateSelector");
			var descriptor = multiPercolateSelector(new MultiPercolateDescriptor());
			return this.Dispatcher.DispatchAsync<MultiPercolateDescriptor, MultiPercolateRequestParameters, MultiPercolateResponse, IMultiPercolateResponse>(
				descriptor,
				(p, d) =>
				{
					var json = Serializer.SerializeMultiPercolate(d);
					return this.LowLevelDispatch.MpercolateDispatchAsync<MultiPercolateResponse>(p, json);
				}
			);
		}

		/// <inheritdoc />
		public Task<IMultiPercolateResponse> MultiPercolateAsync(IMultiPercolateRequest multiPercolateRequest)
		{
			return this.Dispatcher.DispatchAsync<IMultiPercolateRequest, MultiPercolateRequestParameters, MultiPercolateResponse, IMultiPercolateResponse>(
				multiPercolateRequest,
				(p, d) =>
				{
					var json = Serializer.SerializeMultiPercolate(d);
					return this.LowLevelDispatch.MpercolateDispatchAsync<MultiPercolateResponse>(p, json);
				}
			);
		}


		
	}
}