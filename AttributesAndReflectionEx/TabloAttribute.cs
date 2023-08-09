using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributesAndReflectionEx
{
    [AttributeUsage(AttributeTargets.Class)] //sadece class lara uygulanacak

    public class TabloAttribute:Attribute
    {
        private string _tabloAdi;
        private string _schemaAdi;

        public string TabloAdi
        {
            get { return _tabloAdi;}
            set { _tabloAdi = value;}
        }

        public string SchemaAdi
        {
            get { return _schemaAdi;}
            set { _schemaAdi = value;}
        }

        public TabloAttribute(string tablonunAdi):this(tablonunAdi,"dbo")
        {

        }

        public TabloAttribute(string tablonunAdi,string schemaAdi)
        {
            TabloAdi = tablonunAdi;
            SchemaAdi = schemaAdi;
        }

        public TabloAttribute()
        {
               
        }

    }
}
