
using PrincePortalWeb.Common;

namespace PrincePortalWeb.Common
{
	/// <summary>
	/// Collection of BrokenRule Structures.
	/// </summary>
	public class Rules
	{
		/// <summary>
		/// Singleton validation exception
		/// </summary>
		public CustomValidationException CustomValidationException
		{
			get
			{
				if(_CustomValidationException == null)
				{
					_CustomValidationException = new CustomValidationException();
				}
				return _CustomValidationException;
			}
			set
			{
				_CustomValidationException = value;
			}
		}
		private CustomValidationException _CustomValidationException;


	    /// <summary>
		/// Asserts a statement, and adds a broken rule if assertation fails
		/// </summary>
		/// <param name="isTrue"></param>
		/// <param name="field"></param>
		/// <param name="message"></param>
		public void Assert(bool isTrue, string field, string message)
		{
			if(!isTrue)
			{
				CustomValidationException.BrokenRules.Add(field, message);
			}
		}

		/// <summary>
		/// Asserts a statement, and adds a broken rule if assertation fails
		/// </summary>
		/// <param name="isTrue"></param>
		/// <param name="message"></param>
		public void Assert(bool isTrue, string message)
		{
			if(!isTrue)
			{
				CustomValidationException.BrokenRules.Add(message);
			}
		}

		public void ValidateAssertedRules()
		{
			if(CustomValidationException.BrokenRules.Count > 0)
			{
				throw CustomValidationException;
			}
		}
	}
}
