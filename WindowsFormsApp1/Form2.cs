using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void showInfoByElements(IEnumerable<XElement> elements)
        {
            List<InfoModel> modelList = new List<InfoModel>();
            foreach (var ele in elements)
            {
                InfoModel model = new InfoModel();
                model.Id = ele.Attribute("id").Value;
                model.Jylsh = ele.Element("jylsh").Value;
                //model.Hphm = Convert.ToDouble(ele.Element("price").Value);
                model.Hphm = ele.Element("hphm").Value;
                model.Jyjgbh = ele.Element("jyjgbh").Value;
                modelList.Add(model);

                Console.WriteLine(model.Hphm+"----");
            }
            dataGridView1.DataSource = modelList;
            Console.WriteLine(modelList.Count);
        }     

        private void button1_Click_1(object sender, EventArgs e)
        {
            //XElement xe = XElement.Load(@"..\..\返回结果串.txt");
            //IEnumerable<XElement> elements = from ele in xe.Elements("vehispara") select ele;
            //showInfoByElements(elements);
            //Console.WriteLine(elements.Count());
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            string stra = System.IO.File.ReadAllText("C:\\Users\\东子篱\\Desktop\\返回结果串（备用）.txt", Encoding.Default);
            stra = String.Concat(stra.Split(new char[] { '\\' }, StringSplitOptions.None));

            string strtempa = "<body>";
            string strtempb = "</body>";
            int IndexofA = stra.IndexOf(strtempa);
            int IndexofB = stra.IndexOf(strtempb);
            string Ru = stra.Substring(IndexofA, IndexofB - IndexofA - 1);
            //string result = System.Text.RegularExpressions.Regex.Replace(Ru, "[\n]", "");
            
            System.IO.StreamWriter sw = new System.IO.StreamWriter("..\\Info.xml", false, Encoding.Default);
            sw.Write("<?xml version=\"1.0\" encoding=\"GBK\" ?> " + Ru + " </body>");
            sw.Close();

            XElement xe = XElement.Load("..\\Info.xml");
            IEnumerable<XElement> elements = from ele in xe.Elements("vehispara") select ele;
            showInfoByElements(elements);
        }
    }
}
