using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using NexBusiness.Validation.Core;
using NexBusiness.Wcf.Common;

namespace NexBusiness.Wcf.Core
{
	[DataContract]
	public abstract class Response : IResponse
	{
		protected Response()
		{
			Errors = new List<IValidationError>();
			Type = ResponseType.Success;
		}

		[DataMember]
		public ResponseType Type { get; set; }

		[DataMember]
		public IEnumerable<IValidationError> Errors { get; set; }

		public bool IsValid
		{
			get { return !Errors.Any(); }
		}
	}
}