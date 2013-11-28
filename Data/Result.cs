using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MowChat.Data
{
	abstract class ResultCollection<TCollection>
	{
		public TCollection Records { get; set; }
		public Metadata Meta { get; set; }

		public static implicit operator TCollection(ResultCollection<TCollection> result)
		{
			return result.Records;
		}
	}

	class Metadata
	{
		public int Total { get; set; }
	}

	class ResultList<TRecord> : ResultCollection<List<TRecord>>, IEnumerable<TRecord>
	{
		public IEnumerator<TRecord> GetEnumerator()
		{
			return Records.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return Records.GetEnumerator();
		}
	}

	class ResultMap<TRecord> : ResultCollection<Dictionary<string, TRecord>>, IEnumerable<TRecord>
	{
		public IEnumerator<TRecord> GetEnumerator()
		{
			return Records.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return Records.Values.GetEnumerator();
		}
	}
}
