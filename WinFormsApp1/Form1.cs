namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Distance distance;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] point1 = Array.ConvertAll(textBox1.Text.Split(','), int.Parse);
            int[] point2 = Array.ConvertAll(textBox2.Text.Split(','), int.Parse);

            if (comboBox1.SelectedIndex == 0)
            {
                distance = new Decartes(point1, point2);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                distance = new Chebishev(point1, point2);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                distance = new Hemming(point1, point2);
            }

            label1.Text = distance.Root().ToString();
        }


        class Distance
        {
            public int[] point1;
            public int[] point2;

            public Distance(int[] point1, int[] point2)
            {
                this.point1 = point1;
                this.point2 = point2;
            }

            public virtual double Root()
            {
                return 0;
            }
        }

        class Decartes : Distance
        {
            public Decartes(int[] point1, int[] point2) : base(point1, point2) { }

            public override double Root()
            {
                double result = 0;
                for (int i = 0; i < point1.Length; i++)
                {
                    result += Math.Pow(point1[i] - point2[i], 2);
                }
                return Math.Sqrt(result);
            }
        }

        class Chebishev : Distance
        {
            public Chebishev(int[] point1, int[] point2) : base(point1, point2) { }

            public override double Root()
            {
                double result = 0;
                for (int i = 0; i < point1.Length; i++)
                {
                    result = Math.Max(result, Math.Abs(point1[i] - point2[i]));
                }
                return result;
            }
        }

        class Hemming : Distance
        {
            public Hemming(int[] point1, int[] point2) : base(point1, point2) { }

            public override double Root()
            {
                int result = 0;
                for (int i = 0; i < point1.Length; i++)
                {
                    if (point1[i] != point2[i])
                    {
                        result++;
                    }
                }
                return result;
            }
        }

    }
}