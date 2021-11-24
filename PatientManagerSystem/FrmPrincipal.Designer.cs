
namespace PatientManagerSystem
{
    partial class FrmPrincipal
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.restaurar_v2 = new System.Windows.Forms.PictureBox();
            this.pminizar_v2 = new System.Windows.Forms.PictureBox();
            this.maximizar_v2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnMantCitas = new System.Windows.Forms.Button();
            this.BtnMantPruebaLab = new System.Windows.Forms.Button();
            this.BtnMantMedico = new System.Windows.Forms.Button();
            this.BtnMantUsuario = new System.Windows.Forms.Button();
            this.Wrapper = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblCambiarTema = new System.Windows.Forms.Label();
            this.BtnClaroOscuro = new System.Windows.Forms.Button();
            this.BtnMantPacientes = new System.Windows.Forms.Button();
            this.BtnMantResultadoLab = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.tmHora = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.restaurar_v2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pminizar_v2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximizar_v2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.Wrapper.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.restaurar_v2);
            this.panel1.Controls.Add(this.pminizar_v2);
            this.panel1.Controls.Add(this.maximizar_v2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 39);
            this.panel1.TabIndex = 0;
            // 
            // restaurar_v2
            // 
            this.restaurar_v2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.restaurar_v2.Image = global::PatientManagerSystem.Properties.Resources.minimizar__6_;
            this.restaurar_v2.Location = new System.Drawing.Point(1252, 0);
            this.restaurar_v2.Name = "restaurar_v2";
            this.restaurar_v2.Size = new System.Drawing.Size(25, 25);
            this.restaurar_v2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.restaurar_v2.TabIndex = 3;
            this.restaurar_v2.TabStop = false;
            this.restaurar_v2.Visible = false;
            this.restaurar_v2.Click += new System.EventHandler(this.Restaurar_v2_Click);
            // 
            // pminizar_v2
            // 
            this.pminizar_v2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pminizar_v2.Image = global::PatientManagerSystem.Properties.Resources.signo_menos;
            this.pminizar_v2.Location = new System.Drawing.Point(1283, 3);
            this.pminizar_v2.Name = "pminizar_v2";
            this.pminizar_v2.Size = new System.Drawing.Size(25, 25);
            this.pminizar_v2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pminizar_v2.TabIndex = 2;
            this.pminizar_v2.TabStop = false;
            this.pminizar_v2.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // maximizar_v2
            // 
            this.maximizar_v2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximizar_v2.Image = global::PatientManagerSystem.Properties.Resources.maximizar__1_;
            this.maximizar_v2.Location = new System.Drawing.Point(1311, 3);
            this.maximizar_v2.Name = "maximizar_v2";
            this.maximizar_v2.Size = new System.Drawing.Size(25, 25);
            this.maximizar_v2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.maximizar_v2.TabIndex = 1;
            this.maximizar_v2.TabStop = false;
            this.maximizar_v2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::PatientManagerSystem.Properties.Resources.x;
            this.pictureBox1.Location = new System.Drawing.Point(1342, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.71821F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.28179F));
            this.tableLayoutPanel1.Controls.Add(this.BtnMantCitas, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.BtnMantPruebaLab, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.BtnMantMedico, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.BtnMantUsuario, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Wrapper, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnMantPacientes, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.BtnMantResultadoLab, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 39);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.90343F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.87227F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.99377F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.90343F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.90343F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.90343F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.05919F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.3053F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1370, 550);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // BtnMantCitas
            // 
            this.BtnMantCitas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnMantCitas.FlatAppearance.BorderSize = 0;
            this.BtnMantCitas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(80)))));
            this.BtnMantCitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMantCitas.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnMantCitas.ForeColor = System.Drawing.Color.White;
            this.BtnMantCitas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMantCitas.Location = new System.Drawing.Point(3, 483);
            this.BtnMantCitas.Name = "BtnMantCitas";
            this.BtnMantCitas.Size = new System.Drawing.Size(209, 64);
            this.BtnMantCitas.TabIndex = 9;
            this.BtnMantCitas.Text = "Citas";
            this.BtnMantCitas.UseVisualStyleBackColor = true;
            // 
            // BtnMantPruebaLab
            // 
            this.BtnMantPruebaLab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnMantPruebaLab.FlatAppearance.BorderSize = 0;
            this.BtnMantPruebaLab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(80)))));
            this.BtnMantPruebaLab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMantPruebaLab.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnMantPruebaLab.ForeColor = System.Drawing.Color.White;
            this.BtnMantPruebaLab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMantPruebaLab.Location = new System.Drawing.Point(3, 303);
            this.BtnMantPruebaLab.Name = "BtnMantPruebaLab";
            this.BtnMantPruebaLab.Size = new System.Drawing.Size(209, 54);
            this.BtnMantPruebaLab.TabIndex = 5;
            this.BtnMantPruebaLab.Text = "Pruebas de Laboratorios";
            this.BtnMantPruebaLab.UseVisualStyleBackColor = true;
            // 
            // BtnMantMedico
            // 
            this.BtnMantMedico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnMantMedico.FlatAppearance.BorderSize = 0;
            this.BtnMantMedico.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(80)))));
            this.BtnMantMedico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMantMedico.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnMantMedico.ForeColor = System.Drawing.Color.White;
            this.BtnMantMedico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMantMedico.Location = new System.Drawing.Point(3, 243);
            this.BtnMantMedico.Name = "BtnMantMedico";
            this.BtnMantMedico.Size = new System.Drawing.Size(209, 54);
            this.BtnMantMedico.TabIndex = 4;
            this.BtnMantMedico.Text = "Medicos";
            this.BtnMantMedico.UseVisualStyleBackColor = true;
            // 
            // BtnMantUsuario
            // 
            this.BtnMantUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnMantUsuario.FlatAppearance.BorderSize = 0;
            this.BtnMantUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(80)))));
            this.BtnMantUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMantUsuario.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnMantUsuario.ForeColor = System.Drawing.Color.White;
            this.BtnMantUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMantUsuario.Location = new System.Drawing.Point(3, 177);
            this.BtnMantUsuario.Name = "BtnMantUsuario";
            this.BtnMantUsuario.Size = new System.Drawing.Size(209, 60);
            this.BtnMantUsuario.TabIndex = 3;
            this.BtnMantUsuario.Text = "Usuarios";
            this.BtnMantUsuario.UseVisualStyleBackColor = true;
            this.BtnMantUsuario.Click += new System.EventHandler(this.button3_Click);
            // 
            // Wrapper
            // 
            this.Wrapper.BackColor = System.Drawing.Color.White;
            this.Wrapper.Controls.Add(this.panel5);
            this.Wrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Wrapper.Location = new System.Drawing.Point(218, 3);
            this.Wrapper.Name = "Wrapper";
            this.tableLayoutPanel1.SetRowSpan(this.Wrapper, 8);
            this.Wrapper.Size = new System.Drawing.Size(1149, 544);
            this.Wrapper.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(80)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 534);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1149, 10);
            this.panel5.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.LblCambiarTema);
            this.panel3.Controls.Add(this.BtnClaroOscuro);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(209, 54);
            this.panel3.TabIndex = 8;
            // 
            // LblCambiarTema
            // 
            this.LblCambiarTema.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblCambiarTema.ForeColor = System.Drawing.Color.White;
            this.LblCambiarTema.Location = new System.Drawing.Point(3, 8);
            this.LblCambiarTema.Name = "LblCambiarTema";
            this.LblCambiarTema.Size = new System.Drawing.Size(71, 65);
            this.LblCambiarTema.TabIndex = 3;
            this.LblCambiarTema.Text = "Cambiar Tema:";
            // 
            // BtnClaroOscuro
            // 
            this.BtnClaroOscuro.FlatAppearance.BorderSize = 0;
            this.BtnClaroOscuro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(80)))));
            this.BtnClaroOscuro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClaroOscuro.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnClaroOscuro.ForeColor = System.Drawing.Color.White;
            this.BtnClaroOscuro.Location = new System.Drawing.Point(75, 7);
            this.BtnClaroOscuro.Name = "BtnClaroOscuro";
            this.BtnClaroOscuro.Size = new System.Drawing.Size(113, 52);
            this.BtnClaroOscuro.TabIndex = 2;
            this.BtnClaroOscuro.Text = "OSCURO 🌙";
            this.BtnClaroOscuro.UseVisualStyleBackColor = true;
            // 
            // BtnMantPacientes
            // 
            this.BtnMantPacientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnMantPacientes.FlatAppearance.BorderSize = 0;
            this.BtnMantPacientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(80)))));
            this.BtnMantPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMantPacientes.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnMantPacientes.ForeColor = System.Drawing.Color.White;
            this.BtnMantPacientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMantPacientes.Location = new System.Drawing.Point(3, 363);
            this.BtnMantPacientes.Name = "BtnMantPacientes";
            this.BtnMantPacientes.Size = new System.Drawing.Size(209, 54);
            this.BtnMantPacientes.TabIndex = 6;
            this.BtnMantPacientes.Text = "Pacientes";
            this.BtnMantPacientes.UseVisualStyleBackColor = true;
            this.BtnMantPacientes.Click += new System.EventHandler(this.button6_Click);
            // 
            // BtnMantResultadoLab
            // 
            this.BtnMantResultadoLab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnMantResultadoLab.FlatAppearance.BorderSize = 0;
            this.BtnMantResultadoLab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(80)))));
            this.BtnMantResultadoLab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMantResultadoLab.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnMantResultadoLab.ForeColor = System.Drawing.Color.White;
            this.BtnMantResultadoLab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMantResultadoLab.Location = new System.Drawing.Point(3, 423);
            this.BtnMantResultadoLab.Name = "BtnMantResultadoLab";
            this.BtnMantResultadoLab.Size = new System.Drawing.Size(209, 54);
            this.BtnMantResultadoLab.TabIndex = 7;
            this.BtnMantResultadoLab.Text = "Resultados de Laboratorios";
            this.BtnMantResultadoLab.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.LblName);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.ForeColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(3, 63);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(209, 108);
            this.panel4.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(86, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hora";
            // 
            // LblName
            // 
            this.LblName.Font = new System.Drawing.Font("Dubai", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblName.ForeColor = System.Drawing.Color.White;
            this.LblName.Location = new System.Drawing.Point(9, 15);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(197, 84);
            this.LblName.TabIndex = 0;
            this.LblName.Text = "UserName";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 589);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPrincipal";
            this.Text = "FrmPrincipal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.restaurar_v2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pminizar_v2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximizar_v2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.Wrapper.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BtnMantResultadoLab;
        private System.Windows.Forms.Button BtnMantPacientes;
        private System.Windows.Forms.Button BtnMantPruebaLab;
        private System.Windows.Forms.Button BtnMantMedico;
        private System.Windows.Forms.Button BtnMantUsuario;
        private System.Windows.Forms.Panel Wrapper;
        private System.Windows.Forms.Button BtnMantCitas;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblCambiarTema;
        private System.Windows.Forms.Button BtnClaroOscuro;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Timer tmHora;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox restaurar_v2;
        private System.Windows.Forms.PictureBox pminizar_v2;
        private System.Windows.Forms.PictureBox maximizar_v2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}