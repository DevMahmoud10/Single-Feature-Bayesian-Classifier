using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pattern_Task1
{
    public partial class Result : Form
    {
        
        public Result() { }
        public Result(Recognetion img1,Recognetion img2 )
        {
            //this.Width = r.width;
            //this.Height = r.height;
            try
            {
                InitializeComponent();
                //Bitmap newbitmap = new Bitmap(100,100);
                //newbitmap.SetPixel(50, 50, Color.FromArgb(255, 5, 5));
                Bitmap image1 = new Bitmap(img1.width, img1.height);
                Graphics imageGraphics1 = Graphics.FromImage(image1);
                img1.generateColoredImage(img1.height, img1.width, image1);
                pictureBox1.Size = new System.Drawing.Size(img1.width, img1.height);
                pictureBox1.Image = image1;
                

                Bitmap image2 = new Bitmap(img2.width, img2.height);
                Graphics imageGraphics2 = Graphics.FromImage(image2);
                img2.generateBayesianColoredImage(img2.height, img2.width, image1,image2);
                pictureBox1.Size = new System.Drawing.Size(img2.width, img2.height);
                pictureBox2.Image = image2;
                
                this.Size = new Size(Convert.ToInt32(img1.width + img1.width * 1.5), Convert.ToInt32(img1.height + img1.height * 0.25));
                
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());

            }
        }

        public Result(Image image)
        {
            InitializeComponent();

            pictureBox1.Image = image;
            pictureBox1.Height = image.Height;
            pictureBox1.Width = image.Width;
            pictureBox1.Size = new Size(image.Width, image.Height);

            this.Size = new Size(Convert.ToInt32(image.Width + image.Width * 0.25), Convert.ToInt32(image.Height + image.Height * 0.25));

        }

           
    }
}
