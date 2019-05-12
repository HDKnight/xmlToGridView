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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        List<InfoModel> bookModeList = new List<InfoModel>();
        private void Form1_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\东子篱\\Desktop\\大屏显示\\返回结果串.txt");
            XmlNamespaceManager xmlnsManager = new XmlNamespaceManager(doc.NameTable);
            xmlnsManager.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");


            XmlNodeList xnl = doc.SelectNodes("/soap:Envelope/soap:Body/queryObjectOutResponse/queryObjectOutResult/root/body", xmlnsManager);
            //XmlNodeList xnl = xn.ChildNodes;
            foreach (XmlNode xn1 in xnl)
            {
                InfoModel bookClass = new InfoModel();
                XmlElement xe = (XmlElement)xn1;
                bookClass.Id = xe.GetAttribute("id").ToString();
                //bookClass.BookType = xe.GetAttribute("type").ToString();

                XmlNodeList xn10 = xe.ChildNodes;
                bookClass.Hphm = xn10.Item(0).InnerText;
                bookClass.Jyjgbh = xn10.Item(1).InnerText;
                bookClass.Jylsh = xn10.Item(2).InnerText;
                bookModeList.Add(bookClass);
            }
            dataGridView1.DataSource = bookModeList;
        }

        //显示选中XML节点的详细信息
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void BindData()

        {   //绑定控件的数据
            //DataSet ds = XMLFillDataSet("C:\\Users\\东子篱\\Desktop\\大屏显示\\返回结果串.txt");
            //dataGridView1.DataSource = ds;
            //dataGridView1.DataMember = ds.Tables[0].TableName;
            DataSet ds = new DataSet();
            ds.ReadXml("C:\\Users\\东子篱\\Desktop\\返回结果串（备用）.txt");
            dataGridView1.DataSource = ds;
        }


        /// <summary>
        /// 读XML文件，并填入DataSet
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private DataSet XMLFillDataSet(string file)
        {

            //创建DataTable对象dt
            DataTable dt = new DataTable("fcstXML");
            //创建列
            dt.Columns.Add(new DataColumn("jyjgbh", typeof(int)));
            dt.Columns.Add(new DataColumn("jylsh", typeof(string)));
            dt.Columns.Add(new DataColumn("shjg", typeof(string)));
            dt.Columns.Add(new DataColumn("hphm", typeof(string)));
            dt.Columns.Add(new DataColumn("hpzl", typeof(string)));
            //dt.Columns.Add(new DataColumn("description", typeof(string)));
            //dt.Columns.Add(new DataColumn("color", typeof(string)));

            XmlDocument xmldoc = new XmlDocument();
            try
            {   ///导入xml文档
                xmldoc.Load("C:\\Users\\东子篱\\Desktop\\大屏显示\\返回结果串.txt");
                XmlNode node = xmldoc.SelectSingleNode("ctDataset");
                if (node == null)
                {
                    return (DataSet)null;
                }
                ///读取<centerInfo>的结点
                foreach (XmlNode xnode in xmldoc.SelectNodes("ctDataset/centerInfo"))
                {   ///创建一个新行
                    DataRow row = dt.NewRow();
                    ///读取结点数据，并填充数据行
                    foreach (XmlNode xcnode in xnode.ChildNodes)
                    {
                        row[xcnode.Name] = xcnode.InnerText;
                    }
                    ///添加该数据行
                    dt.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            ///创建DataSet对象ds
            DataSet ds = new DataSet("XMLfcstData");
            ds.Tables.Add(dt);
            return (ds);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form3().Show();
        }
    }
}
