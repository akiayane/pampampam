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

        private void num_1_Click(object sender, EventArgs e)
        {
            if (result) 
            {
                label1.Text ="1";
                result = false;
                return;
            }
            label1.Text = label1.Text + "1";
        }

        private void num_2_Click(object sender, EventArgs e)
        {
            if (result)
            {
                label1.Text = "2";
                result = false;
                return;
            }
            label1.Text = label1.Text + "2";
        }

        private void num_3_Click(object sender, EventArgs e)
        {
            if (result)
            {
                label1.Text = "3";
                result = false;
                return;
            }
            label1.Text = label1.Text + "3";
        }

        private void num_4_Click(object sender, EventArgs e)
        {
            if (result)
            {
                label1.Text = "4";
                result = false;
                return;
            }
            label1.Text = label1.Text + "4";
        }

        private void num_5_Click(object sender, EventArgs e)
        {
            if (result)
            {
                label1.Text = "5";
                result = false;
                return;
            }
            label1.Text = label1.Text + "5";
        }

        private void num_6_Click(object sender, EventArgs e)
        {
            if (result)
            {
                label1.Text = "6";
                result = false;
                return;
            }
            label1.Text = label1.Text + "6";
        }

        private void num_7_Click(object sender, EventArgs e)
        {
            if (result)
            {
                label1.Text = "7";
                result = false;
                return;
            }
            label1.Text = label1.Text + "7";
        }

        private void num_8_Click(object sender, EventArgs e)
        {
            if (result)
            {
                label1.Text = "8";
                result = false;
                return;
            }
            label1.Text = label1.Text + "8";
        }

        private void num_9_Click(object sender, EventArgs e)
        {
            if (result)
            {
                label1.Text = "9";
                result = false;
                return;
            }
            label1.Text = label1.Text + "9";
        }

        private void num_0_Click(object sender, EventArgs e)
        {
            if (result)
            {
                label1.Text = "0";
                result = false;
                return;
            }
            label1.Text = label1.Text + "0";
        }

        private void clear_Click(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (!label1.Equals("")) 
            {
                first = float.Parse(label1.Text);
                label1.Text = "";
                operand = "add";
            }
        }

        private void sub_Click(object sender, EventArgs e)
        {
            if (!label1.Equals(""))
            {
                first = float.Parse(label1.Text);
                label1.Text = "";
                operand = "sub";
            }
        }

        private void mult_Click(object sender, EventArgs e)
        {
            if (!label1.Equals(""))
            {
                first = float.Parse(label1.Text);
                label1.Text = "";
                operand = "mult";
            }
        }

        private void div_Click(object sender, EventArgs e)
        {
            if (!label1.Equals(""))
            {
                first = float.Parse(label1.Text);
                label1.Text = "";
                operand = "div";
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
                    case "add":
                        res = first + last;
                        label1.Text = res.ToString();
                        break;
                    case "sub":
                        res = first - last;
                        label1.Text = res.ToString();
                        break;
                    case "mult":
                        res = first * last;
                        label1.Text = res.ToString();
                        break;
                    case "div":
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
