﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(FieldNameQueryJsonConverter<MatchQuery>))]
	public interface IMatchQuery : IFieldNameQuery
	{
		[JsonProperty(PropertyName = "query")]
		string Query { get; set; }

		[JsonProperty(PropertyName = "analyzer")]
		string Analyzer { get; set; }

		[JsonProperty(PropertyName = "fuzzy_rewrite")]
		[JsonConverter(typeof (StringEnumConverter))]
		RewriteMultiTerm? FuzzyRewrite { get; set; }

		[JsonProperty(PropertyName = "fuzziness")]
		IFuzziness Fuzziness { get; set; }

		[JsonProperty(PropertyName = "fuzzy_transpositions")]
		bool? FuzzyTranspositions { get; set; }

		[JsonProperty(PropertyName = "cutoff_frequency")]
		double? CutoffFrequency { get; set; }

		[JsonProperty(PropertyName = "lenient")]
		bool? Lenient { get; set; }

		[JsonProperty("minimum_should_match")]
		MinimumShouldMatch MinimumShouldMatch { get; set; }

		[JsonProperty(PropertyName = "operator")]
		Operator? Operator { get; set; }

		[JsonProperty(PropertyName = "zero_terms_query")]
		ZeroTermsQuery? ZeroTermsQuery { get; set; }
	}

	public class MatchQuery : FieldNameQueryBase, IMatchQuery
	{
		protected override bool Conditionless => IsConditionless(this);

		public string Query { get; set; }
		public string Analyzer { get; set; }
		public RewriteMultiTerm? FuzzyRewrite { get; set; }
		public IFuzziness Fuzziness { get; set; }
		public bool? FuzzyTranspositions { get; set; }
		public double? CutoffFrequency { get; set; }
		public bool? Lenient { get; set; }
		public MinimumShouldMatch MinimumShouldMatch { get; set; }
		public Operator? Operator { get; set; }
		public ZeroTermsQuery? ZeroTermsQuery { get; set; }

		internal override void InternalWrapInContainer(IQueryContainer c) => c.Match = this;

		internal static bool IsConditionless(IMatchQuery q) => q.Field.IsConditionless() || q.Query.IsNullOrEmpty();
	}

	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public class MatchQueryDescriptor<T>
		: FieldNameQueryDescriptorBase<MatchQueryDescriptor<T>, IMatchQuery, T>
		, IMatchQuery where T : class
	{
		protected virtual string MatchQueryType => null;
		protected override bool Conditionless => MatchQuery.IsConditionless(this);
		string IMatchQuery.Query { get; set; }
		string IMatchQuery.Analyzer { get; set; }
		MinimumShouldMatch IMatchQuery.MinimumShouldMatch { get; set; }
		RewriteMultiTerm? IMatchQuery.FuzzyRewrite { get; set; }
		IFuzziness IMatchQuery.Fuzziness { get; set; }
		bool? IMatchQuery.FuzzyTranspositions { get; set; }
		double? IMatchQuery.CutoffFrequency { get; set; }
		bool? IMatchQuery.Lenient { get; set; }
		Operator? IMatchQuery.Operator { get; set; }
		ZeroTermsQuery? IMatchQuery.ZeroTermsQuery { get; set; }

		public MatchQueryDescriptor<T> Query(string query) => Assign(a => a.Query = query);

		public MatchQueryDescriptor<T> Lenient(bool? lenient = true) => Assign(a => a.Lenient = lenient);

		public MatchQueryDescriptor<T> Analyzer(string analyzer) => Assign(a => a.Analyzer = analyzer);

		public MatchQueryDescriptor<T> Fuzziness(Fuzziness fuzziness) => Assign(a => a.Fuzziness = fuzziness);

		public MatchQueryDescriptor<T> FuzzyTranspositions(bool? fuzzyTranspositions = true) => Assign(a => a.FuzzyTranspositions = fuzzyTranspositions);

		public MatchQueryDescriptor<T> CutoffFrequency(double? cutoffFrequency) => Assign(a => a.CutoffFrequency = cutoffFrequency);

		public MatchQueryDescriptor<T> FuzzyRewrite(RewriteMultiTerm? rewrite) => Assign(a => a.FuzzyRewrite = rewrite);

		public MatchQueryDescriptor<T> MinimumShouldMatch(MinimumShouldMatch minimumShouldMatch) => Assign(a => a.MinimumShouldMatch = minimumShouldMatch);

		public MatchQueryDescriptor<T> Operator(Operator? op) => Assign(a => a.Operator = op);

		public MatchQueryDescriptor<T> ZeroTermsQuery(ZeroTermsQuery? zeroTermsQuery) => Assign(a => a.ZeroTermsQuery = zeroTermsQuery);
	}
}
