
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

namespace xmlToGridView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //static string strPath = "C:\\Users\\东子篱\\Desktop\\大屏显示\\返回结果串.txt";
        //static string strID = "";

        ////窗体加载时加载XML文件
        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    getXmlInfo();
        //}

        ////显示选中XML节点的详细信息
        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    strID = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();//记录选择的职工编号
        //    XElement xe = XElement.Load(strPath);//加载XML文件
        //    //使用LINT从XML文件中查询信息
        //    IEnumerable<XElement> elements = from PInfo in xe.Elements("vehispara")   select PInfo;//where PInfo.Attribute("hphm").Value == strID 
        //    //foreach (XElement element in elements)//遍历查询结果
        //    //{
        //    //    textBox11.Text = element.Element("Name").Value;//显示职工姓名
        //    //    comboBox1.SelectedItem = element.Element("Sex").Value;//显示职工性别
        //    //    textBox12.Text = element.Element("Salary").Value;//显示职工薪水
        //    //}
        //}
        //#region 将XML文件内容绑定到DataGridView控件
        ///// <summary>
        ///// 将XML文件内容绑定到DataGridView控件
        ///// </summary>
        //private void getXmlInfo()
        //{
        //    DataSet myds = new DataSet();
        //    myds.ReadXml(strPath);
        //    dataGridView1.DataSource = myds.Tables[0];
        //}
        //#endregion
    }
}
/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;
 
namespace xmlToGridView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string strPath = "Employee.xml";
        static string strID = "";

        //窗体加载时加载XML文件
        private void Form1_Load(object sender, EventArgs e)
        {
            getXmlInfo();
        }

        //显示选中XML节点的详细信息
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            strID = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();//记录选择的职工编号
            XElement xe = XElement.Load(strPath);//加载XML文件
            //使用LINT从XML文件中查询信息
            IEnumerable<XElement> elements = from PInfo in xe.Elements("People")
                                             where PInfo.Attribute("ID").Value == strID
                                             select PInfo;
            foreach (XElement element in elements)//遍历查询结果
            {
                textBox11.Text = element.Element("Name").Value;//显示职工姓名
                comboBox1.SelectedItem = element.Element("Sex").Value;//显示职工性别
                textBox12.Text = element.Element("Salary").Value;//显示职工薪水
            }
        }

        #region 将XML文件内容绑定到DataGridView控件
        /// <summary>
        /// 将XML文件内容绑定到DataGridView控件
        /// </summary>
        private void getXmlInfo()
        {
            DataSet myds = new DataSet();
            myds.ReadXml(strPath);
            dataGridView1.DataSource = myds.Tables[0];
        }
        #endregion
    }
}*/
