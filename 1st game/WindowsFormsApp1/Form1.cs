using EZInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void Player_Tick(object sender, EventArgs e)
        {
            if(Keyboard.IsKeyPressed(Key.RightArrow))
            {
             
                playerbox.Left += 10;
             
            }


            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                playerbox.Left -=   10;
            }

            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                playerbox.Top -= 10;
            }

            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                playerbox.Top += 10;
            }
        }
    }
}
