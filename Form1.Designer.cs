using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using Newtonsoft.Json;


namespace ToDo
{
    partial class Form1
    {
        
        private string archivePath = @"D:\Projetos\C#\ToDo\assets\todolist.txt";

        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


        private void InitializeComponent()
        {
            panel1 = new Panel();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            ViewContainer = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.BackColor = SystemColors.InactiveCaption;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(209, 637);
            panel1.TabIndex = 0;
            // 
            // button4
            // 
            button4.Location = new Point(3, 243);
            button4.Name = "button4";
            button4.Size = new Size(199, 41);
            button4.TabIndex = 0;
            button4.Text = "button1";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(3, 169);
            button3.Name = "button3";
            button3.Size = new Size(199, 41);
            button3.TabIndex = 0;
            button3.Text = "button1";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(3, 95);
            button2.Name = "button2";
            button2.Size = new Size(199, 41);
            button2.TabIndex = 0;
            button2.Text = "button1";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(3, 21);
            button1.Name = "button1";
            button1.Size = new Size(199, 41);
            button1.TabIndex = 0;
            button1.Text = "Pomodoro";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // ViewContainer
            // 
            ViewContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ViewContainer.BackColor = SystemColors.InactiveCaption;
            ViewContainer.BorderStyle = BorderStyle.FixedSingle;
            ViewContainer.Location = new Point(251, 26);
            ViewContainer.Name = "ViewContainer";
            ViewContainer.Size = new Size(1106, 612);
            ViewContainer.TabIndex = 1;
            ViewContainer.Paint += panel2_Paint;
            // 
            // Form1
            // 
            ClientSize = new Size(1384, 661);
            Controls.Add(ViewContainer);
            Controls.Add(panel1);
            MinimumSize = new Size(1400, 700);
            Name = "Form1";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Panel panel1;
        private Button button4;
        private Button button3;
        private Button button2;
        private Panel ViewContainer;
    }






    public class CriptografiaJson
    {
        private static readonly string chave = "1234567890123456"; // 16, 24 ou 32 chars para AES
        private static readonly string iv = "1234567890123456"; // 16 chars

        public static string Criptografar(object objeto)
        {
            // Serializa objeto para JSON
            string json = JsonConvert.SerializeObject(objeto);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(chave);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(json);
                    }

                    return Convert.ToBase64String(ms.ToArray());
                }
                
            }
        }

        public static T Descriptografar<T>(string textoCriptografado)
        {
            byte[] buffer = Convert.FromBase64String(textoCriptografado);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(chave);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream(buffer))
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (StreamReader sr = new StreamReader(cs))
                {
                    string json = sr.ReadToEnd();
                    return JsonConvert.DeserializeObject<T>(json);
                }
            }
        }
    }
}
