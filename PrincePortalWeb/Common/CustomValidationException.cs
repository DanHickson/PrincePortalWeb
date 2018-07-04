using Common;
using System;
namespace PrincePortalWeb.Common
{
    /// <summary>
    /// Summary description for ValidationExceptions.
    /// </summary>
    public class CustomValidationException : ApplicationException
    {
        public BrokenRules BrokenRules
        {
            get
            {
                if (_brokenRules == null)
                {
                    _brokenRules = new BrokenRules();
                }
                return _brokenRules;
            }
            set { _brokenRules = value; }
        }

        private BrokenRules _brokenRules;

        public new Exception InnerException
        {
            get { return _innerException; }
        }

        private Exception _innerException;

        public CustomValidationException()
        {
        }

        public CustomValidationException(BrokenRules brokenRules)
        {
            _brokenRules = brokenRules;
        }

        public CustomValidationException(string errorMessage)
        {
            BrokenRules.Add(string.Empty, errorMessage);
        }

        public CustomValidationException(string name, string description)
        {
            BrokenRules.Add(name, description);
        }

        public CustomValidationException(string errorMessage, Exception ex)
        {
            BrokenRules.Add(string.Empty, errorMessage);
            _innerException = ex;
        }

        public override string Message
        {
            get { return _brokenRules.Count + " Validation Exceptions have occured<br>Please View the BrokenRules collection for details"; }
        }
    }
}
