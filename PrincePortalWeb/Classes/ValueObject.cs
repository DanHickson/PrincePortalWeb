using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using System.Collections;

namespace PrincePortalWeb.Classes
{
 
public class Valueobjects
{
    public class CustomerCollection
    {
        public List<customerObject> Customers { get; set; }
           
    }
    [Serializable()]
     public class customerObject
    {

        private string _address1;
        private string _address2;
        private string _address3;
        private string _category;
        private string _country;
        private string _county;
        private string _custcode;
        private string _fullname;
        private string _int_rep_hou;
        private string _int_rep_key;
        private double _lat;
        private double _lng;
        private string _postcode;
        private string _rep_code;
        private string _telephone;
        private int _filternumber;
        private string _pcbspend;
        private string _off_spend;
        private string _lastvisit;
        private string _novisit;
        private string _custtype;
        private string _ytd;
        private string _ytd2;
        private string _ytd3;
        private string _intrep;
        

        public customerObject()
        {
        }

            public string Intrep
            {
                get { return _intrep; }
                set { _intrep = value; }
            }

            public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        public string Address2
        {
            get {return _address2;}

            set { _address2 = value; }
        }

        public string Address3 
        { 
            get { return _address3; } 
            set { _address3 = value; }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public string Country 
        { 
            get { return _country; } 
            set { _country = value; } 
        }

        public string County 
        { 
            get { return _county; } 
            set { _county = value; } 
        }

        public string Custcode
        {
            get { return _custcode; }
            set { _custcode = value; }
        }

        public string Fullname
        {
            get { return _fullname; }
            set { _fullname = value; }
        }

        public string Int_rep_hou
        {
            get { return _int_rep_hou; }
            set { _int_rep_hou = value; }
        }

        public string Int_rep_key
        {
            get { return _int_rep_key; }
            set { _int_rep_key = value; }
        }

        public double Lat
        { 
            get { return _lat; } 
            set { _lat = value; } 
        }

        public double Lng 
        { 
            get { return _lng; } 
            set { _lng = value; }
        }

        public string Postcode 
        { 
            get { return _postcode; } 
            set { _postcode = value; }
        }

        public string Rep_code
        {
            get { return _rep_code; }
            set { _rep_code= value; }
        }
        public string Telephone 
        { 
            get { return _telephone; }
            set { _telephone = value; } 
    
        }

        public int FilterNumber
        {
            get { return _filternumber; }
            set { _filternumber = value; }

        }


        public string PcbSpend
        {
            get { return _pcbspend; }
            set { _pcbspend = value; }

        }

        public string OffSpend
        {
            get { return _off_spend; }
            set { _off_spend = value; }

        }

        public string LastVisit
        {
            get { return _lastvisit; }
            set { _lastvisit = value; }

        }

        public string NoVisit
        {
            get { return _novisit; }
            set { _novisit = value; }

        }

        public string CustType
        {
            get { return _custtype; }
            set {_custtype=value; }


        }

        public string Ytd
        {
            get { return _ytd; }
            set { _ytd = value; }
        }

          public string Ytd2
        {
            get { return _ytd2; }
            set { _ytd2 = value; }
        }


      public string Ytd3
        {
            get { return _ytd3; }
            set { _ytd3 = value; }
        }
}
}}

    [Serializable()]
    public class postcodeitem
    {
        private string _postcodeitem;
        private string _area;

        public string _PostCode
        {
            get { return _postcodeitem; }
            set { _postcodeitem = value; }


        }

        public string _Area
        {
            get { return _area; }
            set { _area = value; }


        }


    }












