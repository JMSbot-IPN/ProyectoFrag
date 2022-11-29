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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1240, 599);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(1121, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ejecutar consulta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "a) Determinarel total de las ventas de los productos de la categoría deseada.",
            "b)",
            "c) Actualizar el stock disponible en un 5% de los productos de la categoría desea" +
                "da.",
            "d) Determinar si hay clientes de un territorio deseado que realizan ordenes en te" +
                "rritorios diferentes al que se encuentran.",
            "e) Actualizar  la  cantidad  de  productos  de  una  orden deseada.",
            "f) Actualizar el método de envío de una orden deseada.",
            "g) Actualizar el correo electrónico de una cliente deseado.",
            "h) Determinar el empleado que atendió más ordenes por territorio/región.",
            "i) Determinar paraun rango de fechas desadas, cual es el total de las ventasen ca" +
                "da una de las regiones.",
            "j) "});
            this.comboBox1.Location = new System.Drawing.Point(12, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(571, 23);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Text = "Seleccione una consulta a ejecutar";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(589, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "No introduzca ningun parametro";
            this.textBox1.Size = new System.Drawing.Size(260, 23);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(855, 25);
            this.textBox2.Name = "textBox2";
            this.textBox2.PlaceholderText = "No introduzca ningun parametro";
            this.textBox2.Size = new System.Drawing.Size(260, 23);
            this.textBox2.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proyecto Fragmentación";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private ComboBox comboBox1;

        private TextBox textBox1;
        private TextBox textBox2;

    }
}