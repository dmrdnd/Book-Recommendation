namespace WindowsFormsApp2
{
    partial class KitapArşiv
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.isbn = new System.Windows.Forms.Label();
            this.tisbn = new System.Windows.Forms.TextBox();
            this.tbooktitle = new System.Windows.Forms.TextBox();
            this.booktitle = new System.Windows.Forms.Label();
            this.tbookauther = new System.Windows.Forms.TextBox();
            this.yearpublic = new System.Windows.Forms.Label();
            this.tpublisher = new System.Windows.Forms.TextBox();
            this.publiher = new System.Windows.Forms.Label();
            this.bookauther = new System.Windows.Forms.Label();
            this.tyearpublic = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 281);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(961, 441);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // isbn
            // 
            this.isbn.AutoSize = true;
            this.isbn.Location = new System.Drawing.Point(23, 42);
            this.isbn.Name = "isbn";
            this.isbn.Size = new System.Drawing.Size(39, 17);
            this.isbn.TabIndex = 1;
            this.isbn.Text = "ISBN";
            // 
            // tisbn
            // 
            this.tisbn.Location = new System.Drawing.Point(171, 37);
            this.tisbn.Name = "tisbn";
            this.tisbn.Size = new System.Drawing.Size(205, 22);
            this.tisbn.TabIndex = 2;
            // 
            // tbooktitle
            // 
            this.tbooktitle.Location = new System.Drawing.Point(171, 65);
            this.tbooktitle.Name = "tbooktitle";
            this.tbooktitle.Size = new System.Drawing.Size(205, 22);
            this.tbooktitle.TabIndex = 4;
            // 
            // booktitle
            // 
            this.booktitle.AutoSize = true;
            this.booktitle.Location = new System.Drawing.Point(23, 70);
            this.booktitle.Name = "booktitle";
            this.booktitle.Size = new System.Drawing.Size(71, 17);
            this.booktitle.TabIndex = 3;
            this.booktitle.Text = "Book Title";
            // 
            // tbookauther
            // 
            this.tbookauther.Location = new System.Drawing.Point(171, 93);
            this.tbookauther.Name = "tbookauther";
            this.tbookauther.Size = new System.Drawing.Size(205, 22);
            this.tbookauther.TabIndex = 6;
            // 
            // yearpublic
            // 
            this.yearpublic.AutoSize = true;
            this.yearpublic.Location = new System.Drawing.Point(23, 154);
            this.yearpublic.Name = "yearpublic";
            this.yearpublic.Size = new System.Drawing.Size(130, 17);
            this.yearpublic.TabIndex = 5;
            this.yearpublic.Text = "Year Of Publication";
            // 
            // tpublisher
            // 
            this.tpublisher.Location = new System.Drawing.Point(171, 121);
            this.tpublisher.Name = "tpublisher";
            this.tpublisher.Size = new System.Drawing.Size(205, 22);
            this.tpublisher.TabIndex = 8;
            // 
            // publiher
            // 
            this.publiher.AutoSize = true;
            this.publiher.Location = new System.Drawing.Point(23, 126);
            this.publiher.Name = "publiher";
            this.publiher.Size = new System.Drawing.Size(67, 17);
            this.publiher.TabIndex = 7;
            this.publiher.Text = "Publisher";
            // 
            // bookauther
            // 
            this.bookauther.AutoSize = true;
            this.bookauther.Location = new System.Drawing.Point(23, 98);
            this.bookauther.Name = "bookauther";
            this.bookauther.Size = new System.Drawing.Size(86, 17);
            this.bookauther.TabIndex = 9;
            this.bookauther.Text = "Book Auther";
            // 
            // tyearpublic
            // 
            this.tyearpublic.Location = new System.Drawing.Point(171, 149);
            this.tyearpublic.Name = "tyearpublic";
            this.tyearpublic.Size = new System.Drawing.Size(205, 22);
            this.tyearpublic.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(725, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 42);
            this.button1.TabIndex = 23;
            this.button1.Text = "Puan Ver";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LemonChiffon;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(646, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "1 - 10 Arasında Puan Giriniz";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.OrangeRed;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(646, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 5, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 47);
            this.label2.TabIndex = 26;
            this.label2.Text = "Devam Etmek İçin En Az 10 Kitaba Puan Vermelisiniz";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBox1.Location = new System.Drawing.Point(725, 115);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(92, 24);
            this.comboBox1.TabIndex = 27;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ımageList1
            // 
            this.ımageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ımageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(705, 193);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 42);
            this.button2.TabIndex = 28;
            this.button2.Text = "Ana Sayfa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(380, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(258, 252);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // KitapArşiv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkTurquoise;
            this.ClientSize = new System.Drawing.Size(985, 734);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tyearpublic);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bookauther);
            this.Controls.Add(this.tpublisher);
            this.Controls.Add(this.publiher);
            this.Controls.Add(this.tbookauther);
            this.Controls.Add(this.yearpublic);
            this.Controls.Add(this.tbooktitle);
            this.Controls.Add(this.booktitle);
            this.Controls.Add(this.tisbn);
            this.Controls.Add(this.isbn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "KitapArşiv";
            this.Text = "KitapArşiv";
            this.Load += new System.EventHandler(this.KitapArşiv_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label isbn;
        private System.Windows.Forms.TextBox tisbn;
        private System.Windows.Forms.TextBox tbooktitle;
        private System.Windows.Forms.Label booktitle;
        private System.Windows.Forms.TextBox tbookauther;
        private System.Windows.Forms.Label yearpublic;
        private System.Windows.Forms.TextBox tpublisher;
        private System.Windows.Forms.Label publiher;
        private System.Windows.Forms.Label bookauther;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tyearpublic;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.Button button2;
    }
}