using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;
using System.Net;
using Newtonsoft.Json.Linq;


namespace WindowsFormsApp1 {

    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

        }
        public String SelectImage;

        //파일오픈
        private void button3_Click(object sender, EventArgs e) {
            string image_file = string.Empty;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"C:\";

            if (dialog.ShowDialog() == DialogResult.OK) {
                image_file = dialog.FileName;
                SelectImage = image_file;
            } else if (dialog.ShowDialog() == DialogResult.Cancel) {
                return;
            }
            try {
                picture1.Image = Bitmap.FromFile(image_file);
                picture1.SizeMode = PictureBoxSizeMode.StretchImage;
            } 
            catch {
                MessageBox.Show("Please Select to image", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button4_Click(object sender, EventArgs e) {

        }
        //텍스트 분석
        private void analysis_Click(object sender, EventArgs e) {

            try {
                 Bitmap img = new Bitmap(picture1.Image);
                 var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.TesseractAndLstm);
                 var texts = engine.Process(img);
                 texts.GetText();
                 textBox3.Text = texts.GetText();
               
            } 
            catch {
                MessageBox.Show("Please Select to image", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                //texts.GetText();

            }
            //ocr 출력상자
            private void textBox3_TextChanged(object sender, EventArgs e) {

            }
        //API POST (Translate)
        private void button5_Click(object sender, EventArgs e) {
            string ko = "ko";
            string en = "en";
            string parse;

            try {
                RestAPI api = new RestAPI();
                parse = api.API(textBox3.Text,en,ko);
                textBox4.Text = parse;
            } 
            catch {
              MessageBox.Show("Wrong Message", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e) {

        }

        
    }
}

