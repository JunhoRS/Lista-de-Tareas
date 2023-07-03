namespace Lista_de_Tareas
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
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.btnMarcarCompletada = new System.Windows.Forms.Button();
            this.btnEliminarTarea = new System.Windows.Forms.Button();
            this.lstTareasCompletadas = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkCompletada = new System.Windows.Forms.CheckBox();
            this.dataGridViewTareas = new System.Windows.Forms.DataGridView();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog3 = new System.Windows.Forms.ColorDialog();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTareas)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(134, 47);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(117, 20);
            this.txtDescripcion.TabIndex = 0;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(134, 19);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(117, 20);
            this.txtTitulo.TabIndex = 1;
            // 
            // btnMarcarCompletada
            // 
            this.btnMarcarCompletada.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnMarcarCompletada.Location = new System.Drawing.Point(443, 374);
            this.btnMarcarCompletada.Name = "btnMarcarCompletada";
            this.btnMarcarCompletada.Size = new System.Drawing.Size(75, 23);
            this.btnMarcarCompletada.TabIndex = 3;
            this.btnMarcarCompletada.Text = "Completada";
            this.btnMarcarCompletada.UseVisualStyleBackColor = true;
            this.btnMarcarCompletada.Click += new System.EventHandler(this.btnMarcarCompletada_Click);
            // 
            // btnEliminarTarea
            // 
            this.btnEliminarTarea.Location = new System.Drawing.Point(538, 374);
            this.btnEliminarTarea.Name = "btnEliminarTarea";
            this.btnEliminarTarea.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarTarea.TabIndex = 4;
            this.btnEliminarTarea.Text = "Borrar";
            this.btnEliminarTarea.UseVisualStyleBackColor = true;
            this.btnEliminarTarea.Click += new System.EventHandler(this.btnEliminarTarea_Click);
            // 
            // lstTareasCompletadas
            // 
            this.lstTareasCompletadas.FormattingEnabled = true;
            this.lstTareasCompletadas.Location = new System.Drawing.Point(12, 249);
            this.lstTareasCompletadas.Name = "lstTareasCompletadas";
            this.lstTareasCompletadas.Size = new System.Drawing.Size(239, 160);
            this.lstTareasCompletadas.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tarea por añadir: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Descripción";
            // 
            // chkCompletada
            // 
            this.chkCompletada.AutoSize = true;
            this.chkCompletada.Location = new System.Drawing.Point(27, 79);
            this.chkCompletada.Name = "chkCompletada";
            this.chkCompletada.Size = new System.Drawing.Size(88, 17);
            this.chkCompletada.TabIndex = 9;
            this.chkCompletada.Text = "Completada?";
            this.chkCompletada.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTareas
            // 
            this.dataGridViewTareas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTareas.Location = new System.Drawing.Point(284, 12);
            this.dataGridViewTareas.Name = "dataGridViewTareas";
            this.dataGridViewTareas.Size = new System.Drawing.Size(476, 356);
            this.dataGridViewTareas.TabIndex = 10;
            this.dataGridViewTareas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTareas_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "TAREAS COMPLETADAS";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 504);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewTareas);
            this.Controls.Add(this.chkCompletada);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstTareasCompletadas);
            this.Controls.Add(this.btnEliminarTarea);
            this.Controls.Add(this.btnMarcarCompletada);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.txtDescripcion);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTareas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Button btnMarcarCompletada;
        private System.Windows.Forms.Button btnEliminarTarea;
        private System.Windows.Forms.ListBox lstTareasCompletadas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkCompletada;
        private System.Windows.Forms.DataGridView dataGridViewTareas;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ColorDialog colorDialog3;
        private System.Windows.Forms.Label label3;
    }
}

