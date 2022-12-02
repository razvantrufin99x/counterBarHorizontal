using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace counterBarHorizontal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


       
        public int [] valoribarcontrol = new int [10];
        int kc;
        int len = 1;
        int leng = 1;
        public void loadControls()
        {
            int k = Controls.Count - 1;
           
                for (int j = 0; j < 10; j++)
                {
                    k++;
                    Controls.Add(new vBarControl());
                    Controls[k].Left = (10) + 50;    // j = (((j*12)+50) - 50)/12
                    Controls[k].Top = (j * 26) + 50;     // i = (((i*12)+50) - 50)/12 
                    Controls[k].Show();
                }
   
        }

        public void loadlabelsControls()
        {
            int k = Controls.Count - 1;

            for (int j = 0; j < 10; j++)
            {
                k++;
                Controls.Add(new Label());
                Controls[k].Left = (10) ;    // j = (((j*12)+50) - 50)/12
                Controls[k].Top = (j * 26) + 50;     // i = (((i*12)+50) - 50)/12 
                Controls[k].Show();
            }

        }
        public void addinvectordevalor()
        {
            Random rnd1 = new Random(9);
            Random rnd2 = new Random(7);
            for (int j = 0; j < 10; j++)
            {

                valoribarcontrol[j] += (rnd1.Next(5) + rnd2.Next(4));
               
                len++;
               
            
            if (len > 300) { 
                leng++;
                for (int jj = 0; jj < 10; jj++)
                {
                    valoribarcontrol[jj] /=leng;
                    Text = leng.ToString();
                }
                len = 0;
                Text += " " + len.ToString();
                button4.Left -= 1 ;
                button4.Text = leng.ToString();
                if (button4.Left < 20) { timer1.Stop(); }
               }
            } 
        }

        public void seteazavalorivector2controlvbar()
        {
            for (int j = 0; j < 10; j++)
            {
                //set control vbar width
                Controls[kc + j].Width = valoribarcontrol[j];
                //set label value
                Controls[kc + j + 10].Text = (valoribarcontrol[j]*leng).ToString();
                Refresh();
            }
        }
        public void ordoneazavectoruldevalori()
        {
            int min = 0;
            for (int i = 0; i < 10-1; i++)
            {
                min = valoribarcontrol[i];
                for (int j = i+1; j < 10; j++)
                {
                    if (min < valoribarcontrol[j])
                    {
                        int tmp = valoribarcontrol[j];
                        valoribarcontrol[j] = valoribarcontrol[i];
                        valoribarcontrol[i] = tmp;

                        Controls[kc + i].Width = valoribarcontrol[i];
                        Controls[kc + j].Width = valoribarcontrol[j];

                        try
                        {
                            // freq , dura
                           // Console.Beep(valoribarcontrol[j]/100 , valoribarcontrol[j]);
                        }
                        catch { }
                        Refresh();
                    }
                }
            }
        }
        public void schimbapozitiecontrol()
        { 
        
        }

        public void afiseazavalorareinlabel()
        { 
        
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadControls();
            loadlabelsControls();
            addinvectordevalor();
            seteazavalorivector2controlvbar();
            button1.Enabled = false;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            kc = Controls.Count;
        }

        public void animatefunctions()
        {
            ordoneazavectoruldevalori();
            addinvectordevalor();
            seteazavalorivector2controlvbar();
            ordoneazavectoruldevalori();
        }
        
        
        private void button2_Click(object sender, EventArgs e)
        {
            
           
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            animatefunctions();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
