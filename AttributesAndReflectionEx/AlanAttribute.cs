using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributesAndReflectionEx
{
    [AttributeUsage(AttributeTargets.Property)]

    public class AlanAttribute:Attribute
    {
        private string _alanAdi;
        private bool _identity;
        private bool _nullICerebilir;

        public string AlanAdi
        {
            get { return _alanAdi; }
            set { _alanAdi = value; }
        }

        public bool Identity
        {
            get { return _identity; }
            set { _identity = value; }
        }

        public bool NullIcerebilir
        {
            get { return _nullICerebilir; }
            set { _nullICerebilir = value; }
        }

        public AlanAttribute(string alaninAdi):this(alaninAdi,false)
        {
           
        }

        public AlanAttribute(string alaninAdi,bool  IdentityMi)
            :this(alaninAdi,IdentityMi,true)
        {
            
        }

        public AlanAttribute(string alaninAdi,bool IdentityMi,bool nullIcerirMi)
        {
            Identity = IdentityMi;
            NullIcerebilir = nullIcerirMi;
            AlanAdi = alaninAdi;
        }

        public AlanAttribute()
        {
                
        }
    }
}
