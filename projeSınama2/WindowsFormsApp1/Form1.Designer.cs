
namespace WindowsFormsApp1
{
    partial class Form1
    {
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;

            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            #region Windows Form Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.btnDosyaGonder = new System.Windows.Forms.Button();
                this.btnDosyaSec = new System.Windows.Forms.Button();
                this.tbDosya = new System.Windows.Forms.TextBox();
                this.tbHedef = new System.Windows.Forms.TextBox();
                this.label1 = new System.Windows.Forms.Label();
                this.label2 = new System.Windows.Forms.Label();
                this.gonderilecekMesaj = new System.Windows.Forms.RichTextBox();
                this.label3 = new System.Windows.Forms.Label();
                this.btnGonder = new System.Windows.Forms.Button();
                this.rbSha = new System.Windows.Forms.RadioButton();
                this.lbDurum = new System.Windows.Forms.ListBox();
                this.label4 = new System.Windows.Forms.Label();
                this.label5 = new System.Windows.Forms.Label();
                this.cbPort = new System.Windows.Forms.ComboBox();
                this.label6 = new System.Windows.Forms.Label();
                this.lblKayit = new System.Windows.Forms.Label();
                this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
                this.rbAes = new System.Windows.Forms.RadioButton();
                this.label7 = new System.Windows.Forms.Label();
                this.label8 = new System.Windows.Forms.Label();
                this.alinanMesaj = new System.Windows.Forms.RichTextBox();
                this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
                this.btnKayitKonumu = new System.Windows.Forms.Button();
                this.SuspendLayout();
                // 
                // btnDosyaGonder
                // 
                this.btnDosyaGonder.Location = new System.Drawing.Point(135, 126);
                this.btnDosyaGonder.Name = "btnDosyaGonder";
                this.btnDosyaGonder.Size = new System.Drawing.Size(181, 23);
                this.btnDosyaGonder.TabIndex = 0;
                this.btnDosyaGonder.Text = "Gönder";
                this.btnDosyaGonder.UseVisualStyleBackColor = true;
                this.btnDosyaGonder.Click += new System.EventHandler(this.button1_Click);
                // 
                // btnDosyaSec
                // 
                this.btnDosyaSec.Location = new System.Drawing.Point(241, 100);
                this.btnDosyaSec.Name = "btnDosyaSec";
                this.btnDosyaSec.Size = new System.Drawing.Size(75, 23);
                this.btnDosyaSec.TabIndex = 1;
                this.btnDosyaSec.Text = "Dosya Seç";
                this.btnDosyaSec.UseVisualStyleBackColor = true;
                this.btnDosyaSec.Click += new System.EventHandler(this.button2_Click);
                // 
                // tbDosya
                // 
                this.tbDosya.Location = new System.Drawing.Point(135, 100);
                this.tbDosya.Name = "tbDosya";
                this.tbDosya.ReadOnly = true;
                this.tbDosya.Size = new System.Drawing.Size(100, 20);
                this.tbDosya.TabIndex = 2;
                // 
                // tbHedef
                // 
                this.tbHedef.Location = new System.Drawing.Point(102, 32);
                this.tbHedef.Name = "tbHedef";
                this.tbHedef.Size = new System.Drawing.Size(92, 20);
                this.tbHedef.TabIndex = 3;
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                this.label1.Location = new System.Drawing.Point(9, 100);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(125, 13);
                this.label1.TabIndex = 4;
                this.label1.Text = "Gönderilecek Dosya:";
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                this.label2.Location = new System.Drawing.Point(13, 35);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(61, 13);
                this.label2.TabIndex = 5;
                this.label2.Text = "Hedef IP:";
                // 
                // gonderilecekMesaj
                // 
                this.gonderilecekMesaj.Location = new System.Drawing.Point(19, 172);
                this.gonderilecekMesaj.Name = "gonderilecekMesaj";
                this.gonderilecekMesaj.Size = new System.Drawing.Size(223, 155);
                this.gonderilecekMesaj.TabIndex = 6;
                this.gonderilecekMesaj.Text = "";
                // 
                // label3
                // 
                this.label3.AutoSize = true;
                this.label3.Location = new System.Drawing.Point(16, 156);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(50, 13);
                this.label3.TabIndex = 7;
                this.label3.Text = "Mesajınız";
                // 
                // btnGonder
                // 
                this.btnGonder.Location = new System.Drawing.Point(16, 333);
                this.btnGonder.Name = "btnGonder";
                this.btnGonder.Size = new System.Drawing.Size(226, 23);
                this.btnGonder.TabIndex = 8;
                this.btnGonder.Text = "Gönder";
                this.btnGonder.UseVisualStyleBackColor = true;
                this.btnGonder.Click += new System.EventHandler(this.button3_Click);
                // 
                // rbSha
                // 
                this.rbSha.AutoSize = true;
                this.rbSha.Checked = true;
                this.rbSha.Location = new System.Drawing.Point(12, 63);
                this.rbSha.Name = "rbSha";
                this.rbSha.Size = new System.Drawing.Size(68, 17);
                this.rbSha.TabIndex = 9;
                this.rbSha.TabStop = true;
                this.rbSha.Text = "SHA-256";
                this.rbSha.UseVisualStyleBackColor = true;
                // 
                // lbDurum
                // 
                this.lbDurum.FormattingEnabled = true;
                this.lbDurum.Location = new System.Drawing.Point(334, 100);
                this.lbDurum.Name = "lbDurum";
                this.lbDurum.Size = new System.Drawing.Size(150, 121);
                this.lbDurum.TabIndex = 10;
                // 
                // label4
                // 
                this.label4.AutoSize = true;
                this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                this.label4.Location = new System.Drawing.Point(12, 9);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(78, 13);
                this.label4.TabIndex = 4;
                this.label4.Text = "IP Adresiniz:";
                // 
                // label5
                // 
                this.label5.AutoSize = true;
                this.label5.Location = new System.Drawing.Point(305, 9);
                this.label5.Name = "label5";
                this.label5.Size = new System.Drawing.Size(40, 13);
                this.label5.TabIndex = 11;
                this.label5.Text = "PORT:";
                // 
                // cbPort
                // 
                this.cbPort.Enabled = false;
                this.cbPort.FormattingEnabled = true;
                this.cbPort.Items.AddRange(new object[] {
            "5000",
            "5001"});
                this.cbPort.Location = new System.Drawing.Point(364, 6);
                this.cbPort.Name = "cbPort";
                this.cbPort.Size = new System.Drawing.Size(121, 21);
                this.cbPort.TabIndex = 12;
                // 
                // label6
                // 
                this.label6.AutoSize = true;
                this.label6.Location = new System.Drawing.Point(305, 35);
                this.label6.Name = "label6";
                this.label6.Size = new System.Drawing.Size(54, 13);
                this.label6.TabIndex = 13;
                this.label6.Text = "Kayıt Yeri:";
                // 
                // lblKayit
                // 
                this.lblKayit.AutoSize = true;
                this.lblKayit.Location = new System.Drawing.Point(361, 35);
                this.lblKayit.Name = "lblKayit";
                this.lblKayit.Size = new System.Drawing.Size(49, 13);
                this.lblKayit.TabIndex = 13;
                this.lblKayit.Text = "dosya.txt";
                // 
                // openFileDialog1
                // 
                this.openFileDialog1.FileName = "openFileDialog1";
                // 
                // rbAes
                // 
                this.rbAes.AutoSize = true;
                this.rbAes.Location = new System.Drawing.Point(102, 63);
                this.rbAes.Name = "rbAes";
                this.rbAes.Size = new System.Drawing.Size(46, 17);
                this.rbAes.TabIndex = 9;
                this.rbAes.Text = "AES";
                this.rbAes.UseVisualStyleBackColor = true;
                // 
                // label7
                // 
                this.label7.AutoSize = true;
                this.label7.Location = new System.Drawing.Point(381, 84);
                this.label7.Name = "label7";
                this.label7.Size = new System.Drawing.Size(29, 13);
                this.label7.TabIndex = 14;
                this.label7.Text = "LOG";
                // 
                // label8
                // 
                this.label8.AutoSize = true;
                this.label8.Location = new System.Drawing.Point(261, 212);
                this.label8.Name = "label8";
                this.label8.Size = new System.Drawing.Size(67, 13);
                this.label8.TabIndex = 16;
                this.label8.Text = "Alınan Mesaj";
                // 
                // alinanMesaj
                // 
                this.alinanMesaj.Location = new System.Drawing.Point(261, 231);
                this.alinanMesaj.Name = "alinanMesaj";
                this.alinanMesaj.ReadOnly = true;
                this.alinanMesaj.Size = new System.Drawing.Size(223, 125);
                this.alinanMesaj.TabIndex = 15;
                this.alinanMesaj.Text = "";
                // 
                // btnKayitKonumu
                // 
                this.btnKayitKonumu.Location = new System.Drawing.Point(364, 57);
                this.btnKayitKonumu.Name = "btnKayitKonumu";
                this.btnKayitKonumu.Size = new System.Drawing.Size(121, 23);
                this.btnKayitKonumu.TabIndex = 0;
                this.btnKayitKonumu.Text = "Kayıt Konumu Seç";
                this.btnKayitKonumu.UseVisualStyleBackColor = true;
                this.btnKayitKonumu.Click += new System.EventHandler(this.button4_Click);
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(497, 375);
                this.Controls.Add(this.label8);
                this.Controls.Add(this.alinanMesaj);
                this.Controls.Add(this.label7);
                this.Controls.Add(this.lblKayit);
                this.Controls.Add(this.label6);
                this.Controls.Add(this.cbPort);
                this.Controls.Add(this.label5);
                this.Controls.Add(this.lbDurum);
                this.Controls.Add(this.rbAes);
                this.Controls.Add(this.rbSha);
                this.Controls.Add(this.btnGonder);
                this.Controls.Add(this.label3);
                this.Controls.Add(this.gonderilecekMesaj);
                this.Controls.Add(this.label2);
                this.Controls.Add(this.label4);
                this.Controls.Add(this.label1);
                this.Controls.Add(this.tbHedef);
                this.Controls.Add(this.tbDosya);
                this.Controls.Add(this.btnDosyaSec);
                this.Controls.Add(this.btnKayitKonumu);
                this.Controls.Add(this.btnDosyaGonder);
                this.Name = "Form1";
                this.Text = "Sender/Receiver";
                this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
                this.Load += new System.EventHandler(this.Form1_Load);
                this.ResumeLayout(false);
                this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.Button btnDosyaGonder;
            private System.Windows.Forms.Button btnDosyaSec;
            private System.Windows.Forms.TextBox tbDosya;
            private System.Windows.Forms.TextBox tbHedef;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.RichTextBox gonderilecekMesaj;
            private System.Windows.Forms.Label label3;
            private System.Windows.Forms.Button btnGonder;
            private System.Windows.Forms.RadioButton rbSha;
            private System.Windows.Forms.ListBox lbDurum;
            private System.Windows.Forms.Label label4;
            private System.Windows.Forms.Label label5;
            private System.Windows.Forms.ComboBox cbPort;
            private System.Windows.Forms.Label label6;
            private System.Windows.Forms.Label lblKayit;
            private System.Windows.Forms.OpenFileDialog openFileDialog1;
            private System.Windows.Forms.RadioButton rbAes;
            private System.Windows.Forms.Label label7;
            private System.Windows.Forms.Label label8;
            private System.Windows.Forms.RichTextBox alinanMesaj;
            private System.Windows.Forms.SaveFileDialog saveFileDialog1;
            private System.Windows.Forms.Button btnKayitKonumu;
        }
    }

