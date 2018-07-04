using System;
using System.Data;
using System.Reflection;

namespace PrincePortalWeb.Common
{
    //'*********************************************************************
    //'
    //' Null Class
    //'
    //' Class for dealing with the translation of database null values
    //'
    //'*********************************************************************
    //-- based on class taken from DotNetNuke: www.dotnetnuke.com --//

    public class Null
    {
        //' define application encoded null values
        public static int NullInteger
        {
            get
            {
                return -1;
            }

        }
        //' define application encoded null values
        public static long NullLong
        {
            get
            {
                return -1L;
            }
        }

        public static DateTime NullDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }

        public static string NullString
        {
            get
            {
                return String.Empty;
            }
        }

        public static bool NullBoolean
        {
            get
            {
                return false;
            }
        }

        public static Guid NullGuid
        {
            get
            {
                return Guid.Empty;
            }
        }

        private static Byte[] _nullTimeStamp;
        public static Byte[] NullTimeStamp
        {
            get
            {
                if (_nullTimeStamp == null)
                {
                    _nullTimeStamp = new Byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                }
                return _nullTimeStamp;
            }
        }

        /// <summary>
        /// Overloaded the method below to throw an error by default if the type is unknown
        /// </summary>
        /// <param name="objField"></param>
        /// <returns></returns>
        /// <remarks>
        /// This overload is to stay compatible with the
        /// equivelant DNN code
        /// </remarks>
        public static object SetNull(object objField)
        {
            return SetNull(objField, true);
        }


        /// <summary>
        /// sets a field to an application encoded null value
        /// </summary>
        /// <param name="objField"></param>
        /// <param name="throwNullIfUnknown"></param>
        /// <returns></returns>
        public static object SetNull(object objField, bool throwNullIfUnknown)
        {
            if (objField != null)
            {
                if (objField is int)
                {
                    return NullInteger;
                }
                if (objField is float)
                {
                    return NullInteger;
                }
                if (objField is double)
                {
                    return NullInteger;
                }
                if (objField is decimal)
                {
                    return NullInteger;
                }
                if (objField is DateTime)
                {
                    return NullDate;
                }
                if (objField is string)
                {
                    return NullString;
                }
                if (objField is bool)
                {
                    return NullBoolean;
                }
                if (objField is Guid)
                {
                    return NullGuid;
                }
                if (objField is Byte[])
                {
                    return NullTimeStamp;
                }
                if (throwNullIfUnknown)
                {
                    throw new NullReferenceException();
                }
                return NullString;
            }
            return NullString;
        }

        public static object SetNull(PropertyInfo objPropertyInfo)
        {
            return SetNull(objPropertyInfo.PropertyType);
        }


        /// <summary>
        /// Overloaded the method below to throw an error by default if the type is unknown
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <remarks>
        /// This overload is to stay compatible with the
        /// equivelant DNN code
        /// </remarks>
        public static object SetNull(Type type)
        {
            return SetNull(type);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="throwNullIfUnknown"></param>
        /// <returns></returns>
        public static object SetNull(Type type, bool throwNullIfUnknown)
        {
            string typeString = type.ToString();

            if (typeString.Equals("System.Int16")
                || typeString.Equals("System.Int32")
                || typeString.Equals("System.Int64")
                || typeString.Equals("System.Single")
                || typeString.Equals("System.Double")
                || typeString.Equals("System.Decimal"))
            {
                return NullInteger;
            }
            if (typeString.Equals("System.DateTime"))
            {
                return NullDate;
            }
            if (typeString.Equals("System.String")
                || typeString.Equals("System.Char"))
            {
                return NullString;
            }
            if (typeString.Equals("System.Boolean"))
            {
                return NullBoolean;
            }
            if (typeString.Equals("System.Guid"))
            {
                return NullGuid;
            }
            if (typeString.Equals("System.Byte[]"))
            {
                return NullTimeStamp;
            }
            if (type.BaseType.Equals(typeof(Enum)))
            {
                Array objEnumValues = Enum.GetValues(type);
                Array.Sort(objEnumValues);
                return Enum.ToObject(type, objEnumValues.GetValue(0));
            }
            if (throwNullIfUnknown)
            {
                throw new NullReferenceException();
            }

            //if we have made it here just return null
            return null;
        }


        public static object GetNull(object field)
        {
            return GetNull(field, DBNull.Value);
        }


        /// <summary>
        /// Overloaded the method below to throw an error by default if the type is unknown
        /// </summary>
        /// <param name="objField"></param>
        /// <param name="objDBNull"></param>
        /// <returns></returns>
        /// <remarks>
        /// This overload is to stay compatible with the
        /// equivelant DNN code
        /// </remarks>
        public static object GetNull(object objField, object objDBNull)
        {
            return GetNull(objField, objDBNull, true);
        }

        /// <summary>
        /// This function gets a TypedDataset equivelant of a null value for a given field
        /// </summary>
        /// <param name="objField"></param>
        /// <param name="objDBNull"></param>
        /// <param name="throwNullIfUnknown"></param>
        /// <returns></returns>
        public static object GetNull(object objField, object objDBNull, bool throwNullIfUnknown)
        {
            object returnObject = objField;

            if (objField == null)
            {
                returnObject = objDBNull;
            }
            else if (objField is int)
            {
                if (Convert.ToInt32(objField) == NullInteger)
                {
                    returnObject = objDBNull;
                }
            }
            else if (objField is float)
            {
                if (Convert.ToSingle(objField) == NullInteger)
                {
                    returnObject = objDBNull;
                }
            }
            else if (objField is double)
            {
                if (Convert.ToDouble(objField) == NullInteger)
                {
                    returnObject = objDBNull;
                }
            }
            else if (objField is decimal)
            {
                if (Convert.ToDecimal(objField) == NullInteger)
                {
                    returnObject = objDBNull;
                }
            }
            else if (objField is DateTime)
            {
                if (Convert.ToDateTime(objField) == NullDate)
                {
                    returnObject = objDBNull;
                }
            }
            else if (objField is string)
            {
                if (objField.ToString() == NullString)
                {
                    returnObject = objDBNull;
                }
            }
            else if (objField is bool)
            {
                //no real way to tell if a bool was 
                //initially null or initially false
                //so just return whatever the value is

                returnObject = objField;

                #region removed
                //if (Convert.ToBoolean(objField) == NullBoolean) 
                //{ 
                //	returnObject =  objDBNull; 
                //} 
                #endregion // removed

            }
            else if (objField is Guid)
            {
                if (((Guid)objField).Equals(NullGuid))
                {
                    returnObject = objDBNull;
                }
            }
            else if (objField is Array)
            {
                //keep current array  
            }
            else if (throwNullIfUnknown)
            {
                throw new NullReferenceException();
            }

            return returnObject;
        }


        /// <summary>
        /// This function loops through all fields in a dataset and
        /// sets all the null fields to dbNull so that an error isnt
        /// thrown if they are attempted to be accessed
        /// </summary>
        /// <param name="ds"></param>
        public static void MakeDtoNullSafe(DataSet ds)
        {
            foreach (DataTable dt in ds.Tables)
            {
                MakeTableNullSafe(dt);
            }
        }

        public static void MakeTableNullSafe(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                MakeRowNullSafe(dr);
            }
        }

        public static void MakeRowNullSafe(DataRow dr)
        {
            for (int i = 0; i < dr.ItemArray.Length; i++)
            {
                try
                {
                    if (dr[i] == null || dr[i].Equals(DBNull.Value))
                    {
                        dr[i] = SetNull(dr.Table.Columns[i].DataType, false);
                    }
                }
                catch (NullReferenceException)
                {
                }
            }
        }

        public static bool IsNull(object obj)
        {
            try
            {
                if (obj == null || obj.Equals(DBNull.Value) || obj.Equals(SetNull(obj, false)))
                {
                    return true;
                }
                return false;
            }
            catch (NullReferenceException)
            {
                // if null reference exception is thrown by SetNull
                // it means it doesn't know what type it is
                // and so it throws a nullrefereneexception... which
                // means it is not null!
                return false;
            }
        }
    }
}
