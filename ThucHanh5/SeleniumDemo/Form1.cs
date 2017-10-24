using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumDemo
{
    public partial class Form1 : Form
    {
        string info;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txtUsername = txtEmail.Text.Trim();
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://dichvu.ou.edu.vn/v2/login.php?ref=aHR0cDovL2RpY2h2dS5vdS5lZHUudm4vdjIvaW5kZXgucGhwP209ZGljaHZ1JmE9eGVtdGti";
            driver.FindElement(By.Id("txtUsername")).SendKeys(txtUsername);
            driver.FindElement(By.Id("cmdLogin")).Click();

            info = driver.FindElement(By.CssSelector("#stdinfo > .list-arrow")).Text;
            driver.Close();

            string[] tachInfo = info.Split('\r', '\n');
            int viTriDauKhoangTrang = tachInfo[2].IndexOf(':') + 1;
            string hoTen = tachInfo[2].Substring(viTriDauKhoangTrang + 1);

            MessageBox.Show(hoTen);
        }
    }
}
