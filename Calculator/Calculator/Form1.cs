using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public float first;
        public float last;
        public string operand;
        public bool result = false;

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "MeNEvFoZ4DjwphzrtZDvyh3rPLD8wZvbgogB2Qrt",
            BasePath = "https://calculator-32ec4-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        public Form1()
        {
            InitializeComponent();

        }

        private void num_click(object sender, EventArgs e) 
        {
            if (sender is Button) 
            {
                if (result)
                {
                    label1.Text = (sender as Button).Text;
                    result = false;
                    return;
                }
                label1.Text = label1.Text + (sender as Button).Text;
            }
        }


        private void clear_Click(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void operand_Click(object sender, EventArgs e) 
        {
            if (sender is Button) 
            {
                if (!label1.Equals(""))
                {
                    first = float.Parse(label1.Text);
                    label1.Text = "";
                    operand = (sender as Button).Text;
                }
            }
        }


        private void equal_Click(object sender, EventArgs e)
        {
            if (!label1.Equals("") && first != 0) 
            {
                last = float.Parse(label1.Text);
                float res = 0;

                switch (operand) 
                {
                    case "+":
                        res = first + last;
                        label1.Text = res.ToString();
                        break;
                    case "-":
                        res = first - last;
                        label1.Text = res.ToString();
                        break;
                    case "*":
                        res = first * last;
                        label1.Text = res.ToString();
                        break;
                    case "/":
                        res = first / last;
                        label1.Text = res.ToString();
                        break;
                }

                SetResponse set = client.Set(@"Calculation Results/" + res, res);

                last = 0;
                first = 0;
                operand = "";
                result = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client != null) 
            {
                MessageBox.Show("Connection is established");
            }
        }
    }
}
