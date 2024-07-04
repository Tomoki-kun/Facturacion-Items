namespace FacturacionItems.Excepcion
{
    partial class FFactura
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lab1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numCUIT = new System.Windows.Forms.NumericUpDown();
            this.txtNombre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numCUIT)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(49, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(214, 108);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 43);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lab1
            // 
            this.lab1.AutoSize = true;
            this.lab1.Location = new System.Drawing.Point(12, 26);
            this.lab1.Name = "lab1";
            this.lab1.Size = new System.Drawing.Size(56, 16);
            this.lab1.TabIndex = 2;
            this.lab1.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "CUIT";
            // 
            // numCUIT
            // 
            this.numCUIT.Location = new System.Drawing.Point(105, 55);
            this.numCUIT.Maximum = new decimal(new int[] {
            935228927,
            7,
            0,
            0});
            this.numCUIT.Minimum = new decimal(new int[] {
            -1474836480,
            4,
            0,
            0});
            this.numCUIT.Name = "numCUIT";
            this.numCUIT.Size = new System.Drawing.Size(120, 22);
            this.numCUIT.TabIndex = 5;
            this.numCUIT.Value = new decimal(new int[] {
            -1474836480,
            4,
            0,
            0});
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(105, 20);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(195, 22);
            this.txtNombre.TabIndex = 6;
            // 
            // FFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 163);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.numCUIT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lab1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FFactura";
            this.Text = "FFactura";
            ((System.ComponentModel.ISupportInitialize)(this.numCUIT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown numCUIT;
        public System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lab1;
    }
}