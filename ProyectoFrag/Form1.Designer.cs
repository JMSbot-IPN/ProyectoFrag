namespace ProyectoFrag
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
<<<<<<< HEAD
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
=======
>>>>>>> 21ed72e51736e431e4a59f04b876e91d981d3cdc
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
<<<<<<< HEAD
            this.dataGridView1.Size = new System.Drawing.Size(1240, 599);
=======
            this.dataGridView1.Size = new System.Drawing.Size(776, 368);
>>>>>>> 21ed72e51736e431e4a59f04b876e91d981d3cdc
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
<<<<<<< HEAD
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(1121, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 25);
=======
            this.button1.Location = new System.Drawing.Point(657, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 23);
>>>>>>> 21ed72e51736e431e4a59f04b876e91d981d3cdc
            this.button1.TabIndex = 1;
            this.button1.Text = "Ejecutar consulta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
<<<<<<< HEAD
            this.comboBox1.Items.AddRange(new object[] {
            "a)",
            "b)",
            "c)",
            "d)",
            "e)",
            "f)",
            "g)",
            "h)",
            "i)",
            "j)"});
            this.comboBox1.Location = new System.Drawing.Point(12, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(571, 23);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Text = "Seleccione una consulta a ejecutar";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(589, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "No introduzca ningun parametro";
            this.textBox1.Size = new System.Drawing.Size(260, 23);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(855, 27);
            this.textBox2.Name = "textBox2";
            this.textBox2.PlaceholderText = "No introduzca ningun parametro";
            this.textBox2.Size = new System.Drawing.Size(260, 23);
            this.textBox2.TabIndex = 5;
            // 
=======
            this.comboBox1.Location = new System.Drawing.Point(12, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(639, 23);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
>>>>>>> 21ed72e51736e431e4a59f04b876e91d981d3cdc
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< HEAD
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
=======
            this.ClientSize = new System.Drawing.Size(800, 450);
>>>>>>> 21ed72e51736e431e4a59f04b876e91d981d3cdc
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
<<<<<<< HEAD
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
=======
>>>>>>> 21ed72e51736e431e4a59f04b876e91d981d3cdc
            this.Text = "Proyecto Fragmentación";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
<<<<<<< HEAD
            this.PerformLayout();
=======
>>>>>>> 21ed72e51736e431e4a59f04b876e91d981d3cdc

        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private ComboBox comboBox1;

        private TextBox textBox1;
        private TextBox textBox2;

    }
}