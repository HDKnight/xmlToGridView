using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void showInfoByElements(IEnumerable<XElement> elements)
        {
            List<InfoModel> modelList = new List<InfoModel>();
            foreach (var ele in elements)
            {
                InfoModel model = new InfoModel();
                model.Id = ele.Attribute("ISBN").Value;
                model.Jylsh = ele.Element("author").Value;
                //model.Hphm = Convert.ToDouble(ele.Element("price").Value);
                model.Hphm = ele.Element("title").Value;
                model.Jyjgbh = ele.Attribute("Type").Value;
                modelList.Add(model);

                Console.WriteLine(model.Hphm + "----");
            }
            dataGridView1.DataSource = modelList;
            Console.WriteLine(modelList.Count);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Console.WriteLine("C:\\Users\\东子篱\\Desktop\\Book.xml");
            XElement xe = XElement.Load(@"..\..\Book.xml");
            IEnumerable<XElement> elements = from ele in xe.Elements("book") select ele;
            showInfoByElements(elements);

        }
    }
}
