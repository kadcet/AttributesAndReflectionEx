using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributesAndReflectionEx
{
    [Tablo("Production","Product")]
    public class UrunEntity
    {


        private int _urunId;
        private decimal _fiyat;
        private string _urunAdi;
        private DateTime _sonSatisTarihi;


        [Alan("SellStartDate",Identity =false,NullIcerebilir =false)]

        public DateTime SonSatisTarihi
        {
            get { return _sonSatisTarihi;}
            set { _sonSatisTarihi = value; }
        }
        [Alan("Name",false,false)]

        public string UrunAdi
        {
            get { return _urunAdi; }
            set { _urunAdi = value; }
        }
        [Alan("ListPrice",Identity =false,NullIcerebilir =false)]

        public decimal Fiyat
        {
            get { return _fiyat; }
            set { _fiyat = value; }
        }
        [Alan("ProductId",Identity =true,NullIcerebilir =false)]

        public int UrunId
        {
            get { return _urunId; }
            set { _urunId = value; }
        }

        public string Insert()
        {
            Type tip=this.GetType();
            TabloAttribute tblAtr = ( (TabloAttribute[]) tip.GetCustomAttributes(typeof(TabloAttribute), false) )[0];
            string tabloAdi=tblAtr.TabloAdi;
            string schemaAdi=tblAtr.SchemaAdi;

            StringBuilder insertBuilder = new StringBuilder();
            insertBuilder.Append("INSERT INTO ");
            insertBuilder.Append(schemaAdi);
            insertBuilder.Append(".");
            insertBuilder.Append(tabloAdi);
            insertBuilder.Append(" (");

            // insert sorgusunun alan adlarını tespit edip sorguya ekliyorum

            foreach (PropertyInfo prp in tip.GetProperties())
            {
                AlanAttribute atr= ((AlanAttribute[])prp.GetCustomAttributes(typeof(AlanAttribute), false))[0];
                if (!atr.Identity)
                {
                    string alanAdi = atr.AlanAdi;
                    insertBuilder.Append(alanAdi);
                    insertBuilder.Append(",");
                }
            }

            insertBuilder.Remove(insertBuilder.Length - 1, 1);
            insertBuilder.Append(") VALUES (");

            foreach (PropertyInfo prp in tip.GetProperties())
            {
                AlanAttribute atr = ((AlanAttribute[])prp.GetCustomAttributes(typeof(AlanAttribute), false))[0];
                if (!atr.Identity)
                {
                    object alanDegeri=prp.GetValue(this, null);
                    if ((prp.PropertyType.Name == "String") || (prp.PropertyType.Name == "DateTime"))
                        insertBuilder.Append("'" + prp.GetValue(this, null).ToString() + "',");
                    else
                        insertBuilder.Append(prp.GetValue(this, null).ToString() + ",");
                }
            }
            insertBuilder.Remove(insertBuilder.Length - 1, 1);
            insertBuilder.Append(")");

            return insertBuilder.ToString();

        }
    }
}
