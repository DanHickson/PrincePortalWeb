using System;
using System.Collections;

namespace Common
{
    /// <summary>
    /// Collection of BrokenRule Structures.
    /// </summary>
    public class BrokenRules : CollectionBase
    {

        public virtual bool IsFixed
        {
            get
            {
                return false;
            }
        }

        public virtual bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public virtual BrokenRule this[int index]
        {
            get
            {
                return (BrokenRule)this.List[index];
            }
            set
            {
                this.List[index] = value;
            }
        }

        public virtual int IndexOf(BrokenRule item)
        {
            return this.List.IndexOf(item);
        }

        public virtual int Add(BrokenRule item)
        {
            return this.List.Add(item);
        }

        //		public virtual int Add(string name, string description, string property) 
        //		{
        //			return this.List.Add(new BrokenRule(name, description, property));
        //		}

        public virtual int Add(string name, string description)
        {
            return this.List.Add(new BrokenRule(name, description));
        }

        public virtual int Add(string description)
        {
            return this.List.Add(new BrokenRule(description));
        }

        public virtual void Remove(BrokenRule item)
        {
            this.List.Remove(item);
        }

        public virtual void CopyTo(Array array, int index)
        {
            this.List.CopyTo(array, index);
        }

        public virtual void AddRange(BrokenRules collection)
        {
            this.InnerList.AddRange(collection);
        }

        public virtual void AddRange(BrokenRule[] collection)
        {
            this.InnerList.AddRange(collection);
        }

        public virtual bool Contains(BrokenRule item)
        {
            return this.List.Contains(item);
        }

        public virtual void Insert(int index, BrokenRule item)
        {
            this.List.Insert(index, item);
        }

        public string GetListOfBrokenRuleDescriptions(string newLineCharactersToUse)
        {
            string descriptions = string.Empty;

            for (int i = 0; i < this.Count; i++)
            {
                descriptions += this[i].Description + newLineCharactersToUse;
            }

            return descriptions;
        }
    }

    /// <summary>
    /// Stores details about a specific broken business rule.
    /// </summary>
    public struct BrokenRule
    {
        //string _name;
        string _description;
        string _property;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="description"></param>
        public BrokenRule(string description)
        {
            //_name = string.Empty;;
            _description = description;
            _property = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="description"></param>
        public BrokenRule(string property, string description)
        {
            //_name = name;
            _description = description;
            _property = string.Empty;
        }

        /// <summary>
        /// Provides access to the description of the broken rule.
        /// </summary>
        /// <remarks>
        /// This value is actually readonly, not readwrite. Any new
        /// value set into this property is ignored. The property is only
        /// readwrite because that is required to support data binding
        /// within Web Forms.
        /// </remarks>
        /// <value>The description of the rule.</value>
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                // the property must be read-write for Web Forms data binding
                // to work, but we really don't want to allow the value to be
                // changed dynamically so we ignore any attempt to set it
            }
        }

        /// <summary>
        /// Provides access to the property affected by the broken rule.
        /// </summary>
        /// <remarks>
        /// This value is actually readonly, not readwrite. Any new
        /// value set into this property is ignored. The property is only
        /// readwrite because that is required to support data binding
        /// within Web Forms.
        /// </remarks>
        /// <value>The property affected by the rule.</value>
        public string Property
        {
            get
            {
                return _property;
            }
            set
            {
                // the property must be read-write for Web Forms data binding
                // to work, but we really don't want to allow the value to be
                // changed dynamically so we ignore any attempt to set it
            }
        }
    }
}
