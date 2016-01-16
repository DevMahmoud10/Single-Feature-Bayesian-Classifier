using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Task1
{
    public class Recognetion
    {
        public int width;
        public int height;
        Random r = new Random();
        public section[] classes = new section[4];

        public Recognetion() { }



        public Recognetion(int w, int h,
            string c1rm, string c1gm, string c1bm, string c1rs, string c1gs, string c1bs,
            string c2rm, string c2gm, string c2bm, string c2rs, string c2gs, string c2bs,
            string c3rm, string c3gm, string c3bm, string c3rs, string c3gs, string c3bs,
            string c4rm, string c4gm, string c4bm, string c4rs, string c4gs, string c4bs,
            string c1p, string c2p, string c3p, string c4p
            ) //c1rm --> class1 red mu  
        {
            this.width = w;
            this.height = h;


            //initialization of sections 
            for (int i = 0; i < classes.Length; i++)
            {
                classes[i] = new section();
            }

            classes[0].start = 0;
            classes[0].end = (0.25 * width) - 1;
            classes[0].r.mu = Convert.ToDouble(c1rm);
            classes[0].r.sigma = Convert.ToDouble(c1rs);
            classes[0].g.mu = Convert.ToDouble(c1gm);
            classes[0].g.sigma = Convert.ToDouble(c1gs);
            classes[0].b.mu = Convert.ToDouble(c1bm);
            classes[0].b.sigma = Convert.ToDouble(c1bs);
            classes[0].prior = Convert.ToDouble(c1p);

            classes[1].start = (0.25 * width);
            classes[1].end = (0.5 * width) - 1;
            classes[1].r.mu = Convert.ToDouble(c2rm);
            classes[1].r.sigma = Convert.ToDouble(c2rs);
            classes[1].g.mu = Convert.ToDouble(c2gm);
            classes[1].g.sigma = Convert.ToDouble(c2gs);
            classes[1].b.mu = Convert.ToDouble(c2bm);
            classes[1].b.sigma = Convert.ToDouble(c2bs);
            classes[1].prior = Convert.ToDouble(c2p);

            classes[2].start = (0.5 * width);
            classes[2].end = (0.75 * width) - 1;
            classes[2].r.mu = Convert.ToDouble(c3rm);
            classes[2].r.sigma = Convert.ToDouble(c3rs);
            classes[2].g.mu = Convert.ToDouble(c3gm);
            classes[2].g.sigma = Convert.ToDouble(c3gs);
            classes[2].b.mu = Convert.ToDouble(c3bm);
            classes[2].b.sigma = Convert.ToDouble(c3bs);
            classes[2].prior = Convert.ToDouble(c3p);

            classes[3].start = (0.75 * width);
            classes[3].end = width - 1;
            classes[3].r.mu = Convert.ToDouble(c4rm);
            classes[3].r.sigma = Convert.ToDouble(c4rs);
            classes[3].g.mu = Convert.ToDouble(c4gm);
            classes[3].g.sigma = Convert.ToDouble(c4gs);
            classes[3].b.mu = Convert.ToDouble(c4bm);
            classes[3].b.sigma = Convert.ToDouble(c4bs);
            classes[3].prior = Convert.ToDouble(c3p);


        }

        public double calculateNormalDistributedLiklehood(double x, double mu, double sigma)
        {
            double d = sigma * Math.Sqrt(2 * Math.PI);
            double en = -(Math.Pow((x - mu), 2));
            double ed = 2 * Math.Pow(sigma, 2);
            return (1/d)*Math.Exp(en/ed);
            //return ((1/(sigma*(Math.Sqrt(2*Math.PI)))))*Math.Exp(-Math.Pow((x-mu),2)/(2*Math.Pow(sigma,2)));
        }
        public double generateNDnumber()// generate normal distributed number 
        {
            double r1, r2, z; //  normal distributed number 

            r1 = r.NextDouble(); // l7d dlw2ty uniform 
            r2 = r.NextDouble();


            z = Math.Sqrt((-2 * (Math.Log(r1, Math.E)))) * Math.Cos(2 * Math.PI * r2);            //3ayzeen n3mlo normal 
            
            return z;
        }

        public void colorPixel(section s, int x, int y, Bitmap img)
        {
            //apply el color elly t7t 3la el pixel 
            var avg = (s.p.R + s.p.G + s.p.B) / 3;  // 3shan el grey scale
            img.SetPixel(x, y, Color.FromArgb(Convert.ToInt32(s.p.R), Convert.ToInt32(s.p.G), Convert.ToInt32(s.p.B)));
        }

        public void colorPixel(Color c, int x, int y, Bitmap img)
        {
            img.SetPixel(x, y, c);

        }

       
        public void generateColoredImage(double height, double width, Bitmap img)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i >= classes[0].start && i <= classes[0].end)
                    {
                        classes[0].p.R = classes[0].r.mu + (classes[0].r.sigma * generateNDnumber());
                        classes[0].p.G = classes[0].g.mu + (classes[0].g.sigma * generateNDnumber());
                        classes[0].p.B = classes[0].b.mu + (classes[0].b.sigma * generateNDnumber());

                        colorPixel(classes[0], i, j, img);


                    }

                    else if (i >= classes[1].start && i <= classes[1].end)
                    {
                        classes[1].p.R = classes[1].r.mu + (classes[1].r.sigma * generateNDnumber());
                        classes[1].p.G = classes[1].g.mu + (classes[1].g.sigma * generateNDnumber());
                        classes[1].p.B = classes[1].b.mu + (classes[1].b.sigma * generateNDnumber());

                        colorPixel(classes[1], i, j, img);

                    }

                    else if (i >= classes[2].start && i <= classes[2].end)
                    {
                        classes[2].p.R = classes[2].r.mu + (classes[2].r.sigma * generateNDnumber());
                        classes[2].p.G = classes[2].g.mu + (classes[2].g.sigma * generateNDnumber());
                        classes[2].p.B = classes[2].b.mu + (classes[2].b.sigma * generateNDnumber());

                        colorPixel(classes[2], i, j, img);

                    }
                    else if (i >= classes[3].start && i <= classes[3].end)
                    {
                        classes[3].p.R = classes[3].r.mu + (classes[3].r.sigma * generateNDnumber());
                        classes[3].p.G = classes[3].g.mu + (classes[3].g.sigma * generateNDnumber());
                        classes[3].p.B = classes[3].b.mu + (classes[3].b.sigma * generateNDnumber());

                        colorPixel(classes[3], i, j, img);
                    }


                }
            }
        }

        public int getPixelColor(int x, int y, Bitmap img)
        {
            // 3shan el grey scale
            Color c = img.GetPixel(x, y);
            return c.R;
        }


        public void generateBayesianColoredImage(double height, double width, Bitmap img1 ,Bitmap img2)
        {
            int pixelClass;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    pixelClass = BayesClassifier(i,j,getPixelColor(i,j,img1));
                    if (pixelClass == 0)
                    {
                        colorPixel(Color.Red, i, j, img2);
                    }
                    else if (pixelClass == 1)
                    {
                        colorPixel(Color.Green, i, j, img2);
                    }
                    else if (pixelClass == 2)
                    {
                        colorPixel(Color.Blue, i, j, img2);
                    }
                    else if (pixelClass == 3)
                    {
                        colorPixel(Color.Yellow, i, j, img2);
                    }

                }
            }
        }

        public int 
            BayesClassifier(int m,int n,int pixelColor)
        {
            double[] likelihood = new double[4];
            double[] NDnumber = new double[3];
            double[] posteriors = new double[4];
            double evidance;


            //NDnumber[0] = generateNDnumber();
            //NDnumber[1] = generateNDnumber();
            //NDnumber[2] = generateNDnumber();

            evidance = 0.0;
            //Compute the likelihood value
            //likelihood[0] = Convert.ToDouble(Math.Max((Math.Max(Convert.ToDecimal(classes[0].r.mu + (classes[0].r.sigma * NDnumber[0])),
            //                (Convert.ToDecimal(classes[0].g.mu + (classes[0].g.sigma * NDnumber[1]))))),
            //                (Convert.ToDecimal(classes[0].b.mu + (classes[0].b.sigma * NDnumber[2])))));
            //likelihood[1] = Convert.ToDouble(Math.Max((Math.Max(Convert.ToDecimal(classes[1].r.mu + (classes[1].r.sigma * NDnumber[0])), 
            //                (Convert.ToDecimal(classes[1].g.mu + (classes[1].g.sigma * NDnumber[1]))))), 
            //                (Convert.ToDecimal(classes[1].b.mu + (classes[1].b.sigma * NDnumber[2])))));
            //likelihood[2] = Convert.ToDouble(Math.Max((Math.Max(Convert.ToDecimal(classes[2].r.mu + (classes[2].r.sigma * NDnumber[0])),
            //                (Convert.ToDecimal(classes[2].g.mu + (classes[2].g.sigma * NDnumber[1]))))),
            //                (Convert.ToDecimal(classes[2].b.mu + (classes[2].b.sigma * NDnumber[2])))));
            //likelihood[3] = Convert.ToDouble(Math.Max((Math.Max(Convert.ToDecimal(classes[3].r.mu + (classes[3].r.sigma * NDnumber[0])), 
            //                (Convert.ToDecimal(classes[3].g.mu + (classes[3].g.sigma * NDnumber[1]))))), 
            //                (Convert.ToDecimal(classes[3].b.mu + (classes[3].b.sigma * NDnumber[2])))));

            //classes[0].b.mu = 100;
            //classes[0].b.sigma = 1;

            //classes[1].b.mu = 120;
            //classes[1].b.sigma = 1;

            //classes[1].b.mu = 150;
            //classes[1].b.sigma = 1;

            //classes[1].b.mu = 180;
            //classes[1].b.sigma = 1;

                     for (int i = 0; i < 4; i++)
                    {


                        likelihood[i] = calculateNormalDistributedLiklehood(pixelColor, classes[i].r.mu, classes[i].r.sigma);
                    }
                
           



            //Compute evidence
            //evidance = (likelihood[0] * classes[0].prior) + (likelihood[1] * classes[1].prior) + (likelihood[2] * classes[2].prior) + (likelihood[3] * classes[3].prior);

            for (int i = 0; i < 4; i++)
            {
                evidance += (likelihood[i] * classes[i].prior);
            }
            //Compute the posteriors

            for (int i = 0; i < 4; i++)
            {
                posteriors[i] = (likelihood[i] * classes[i].prior) / evidance;
            }

            //make a decision using the posteriors;
            return posteriors.ToList().IndexOf(posteriors.Max());

        }
    }
}
