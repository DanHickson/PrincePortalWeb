using System.Collections;

namespace PrincePortalWeb.Common
{
    public class UserMessages : CollectionBase
    {
        public virtual UserMessageItem this[int index]
        {
            get
            {
                return (UserMessageItem)this.List[index];
            }
            set
            {
                this.List[index] = value;
            }
        }

        public virtual int Add(UserMessageItem item)
        {
            return this.List.Add(item);
        }

        public virtual int Add(string userMessage)
        {
            return this.List.Add(new UserMessageItem(userMessage));
        }
    }

    public struct UserMessageItem
    {
        string _message;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserMessageItem"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        internal UserMessageItem(string message)
        {
            _message = message;
        }


        public string MessageText
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
            }
        }
    }
}
