namespace AttributesAndReflectionEx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UrunEntity urunEntity = new UrunEntity()
            {
                UrunId = 1,
                Fiyat = 135,
                UrunAdi = "Erik",
                SonSatisTarihi = DateTime.Now,
            };
            richTextBox1.Text=urunEntity.Insert();
        }
    }
}