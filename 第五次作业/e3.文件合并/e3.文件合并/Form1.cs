
using System.Security;
using System.Text;

namespace e3.文件合并
{
    public partial class Form1 : Form
    {

        StreamReader sr1 = null;
        StreamReader sr2 = null;
        private object file;

        public Form1()
        {
            InitializeComponent();
            Console.WriteLine("hello");
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog1.FileName;

                    sr1 = new StreamReader(filePath, Encoding.UTF8);

                    label1.Text = openFileDialog1.SafeFileName;


                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog1.FileName;

                    sr2 = new StreamReader(filePath, Encoding.UTF8);

                    label2.Text = openFileDialog1.SafeFileName;
                  

                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s1 = sr1.ReadToEnd();
            string s2 = sr2.ReadToEnd();
            //string path = "..//Data";
            //if (!Directory.Exists(path))
            //    Directory.CreateDirectory(path);
            FileStream file2 = new FileStream("D://merge.txt", FileMode.OpenOrCreate, FileAccess.Write);

            StreamWriter writer = new StreamWriter(file2);
            writer.Write(s1);
            writer.Write(s2);
            writer.Close();

        }
    }
 
}