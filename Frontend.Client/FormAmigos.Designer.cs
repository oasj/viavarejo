namespace Client
{
    partial class FormAmigos
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
            this.label1 = new System.Windows.Forms.Label();
            this.textId = new System.Windows.Forms.TextBox();
            this.textLocal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textLatitude = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textLongitude = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.listaAmigos = new System.Windows.Forms.ListView();
            this.colunaAmigosNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listaProximos = new System.Windows.Forms.ListView();
            this.colunaProximoNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colunaProximoLocal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colunaProximoLatitude = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colunaProximoLongitude = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // textId
            // 
            this.textId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textId.Location = new System.Drawing.Point(228, 24);
            this.textId.Name = "textId";
            this.textId.ReadOnly = true;
            this.textId.Size = new System.Drawing.Size(406, 20);
            this.textId.TabIndex = 2;
            this.textId.TabStop = false;
            // 
            // textLocal
            // 
            this.textLocal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textLocal.Location = new System.Drawing.Point(228, 76);
            this.textLocal.Name = "textLocal";
            this.textLocal.ReadOnly = true;
            this.textLocal.Size = new System.Drawing.Size(406, 20);
            this.textLocal.TabIndex = 4;
            this.textLocal.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome";
            // 
            // textNome
            // 
            this.textNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textNome.Location = new System.Drawing.Point(228, 50);
            this.textNome.Name = "textNome";
            this.textNome.ReadOnly = true;
            this.textNome.Size = new System.Drawing.Size(406, 20);
            this.textNome.TabIndex = 6;
            this.textNome.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Local";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(168, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Latitude";
            // 
            // textLatitude
            // 
            this.textLatitude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textLatitude.Location = new System.Drawing.Point(228, 102);
            this.textLatitude.Name = "textLatitude";
            this.textLatitude.ReadOnly = true;
            this.textLatitude.Size = new System.Drawing.Size(406, 20);
            this.textLatitude.TabIndex = 7;
            this.textLatitude.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Longitude";
            // 
            // textLongitude
            // 
            this.textLongitude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textLongitude.Location = new System.Drawing.Point(228, 128);
            this.textLongitude.Name = "textLongitude";
            this.textLongitude.ReadOnly = true;
            this.textLongitude.Size = new System.Drawing.Size(406, 20);
            this.textLongitude.TabIndex = 9;
            this.textLongitude.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(168, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Próximos";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Amigos";
            // 
            // listaAmigos
            // 
            this.listaAmigos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listaAmigos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colunaAmigosNome});
            this.listaAmigos.FullRowSelect = true;
            this.listaAmigos.Location = new System.Drawing.Point(12, 26);
            this.listaAmigos.MultiSelect = false;
            this.listaAmigos.Name = "listaAmigos";
            this.listaAmigos.Size = new System.Drawing.Size(142, 301);
            this.listaAmigos.TabIndex = 14;
            this.listaAmigos.UseCompatibleStateImageBehavior = false;
            this.listaAmigos.View = System.Windows.Forms.View.Details;
            this.listaAmigos.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listaAmigos_ItemSelectionChanged);
            // 
            // colunaAmigosNome
            // 
            this.colunaAmigosNome.Text = "Nome";
            this.colunaAmigosNome.Width = 120;
            // 
            // listaProximos
            // 
            this.listaProximos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaProximos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colunaProximoNome,
            this.colunaProximoLocal,
            this.colunaProximoLatitude,
            this.colunaProximoLongitude});
            this.listaProximos.FullRowSelect = true;
            this.listaProximos.Location = new System.Drawing.Point(171, 180);
            this.listaProximos.MultiSelect = false;
            this.listaProximos.Name = "listaProximos";
            this.listaProximos.Size = new System.Drawing.Size(463, 147);
            this.listaProximos.TabIndex = 15;
            this.listaProximos.TabStop = false;
            this.listaProximos.UseCompatibleStateImageBehavior = false;
            this.listaProximos.View = System.Windows.Forms.View.Details;
            // 
            // colunaProximoNome
            // 
            this.colunaProximoNome.Text = "Nome";
            this.colunaProximoNome.Width = 120;
            // 
            // colunaProximoLocal
            // 
            this.colunaProximoLocal.Text = "Local";
            this.colunaProximoLocal.Width = 120;
            // 
            // colunaProximoLatitude
            // 
            this.colunaProximoLatitude.Text = "Latitude";
            this.colunaProximoLatitude.Width = 100;
            // 
            // colunaProximoLongitude
            // 
            this.colunaProximoLongitude.Text = "Longitude";
            this.colunaProximoLongitude.Width = 100;
            // 
            // FormAmigos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 339);
            this.Controls.Add(this.listaProximos);
            this.Controls.Add(this.listaAmigos);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textLongitude);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textLatitude);
            this.Controls.Add(this.textNome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textLocal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormAmigos";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormAmigos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.TextBox textLocal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textLatitude;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textLongitude;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView listaAmigos;
        private System.Windows.Forms.ColumnHeader colunaAmigosNome;
        private System.Windows.Forms.ListView listaProximos;
        private System.Windows.Forms.ColumnHeader colunaProximoNome;
        private System.Windows.Forms.ColumnHeader colunaProximoLocal;
        private System.Windows.Forms.ColumnHeader colunaProximoLatitude;
        private System.Windows.Forms.ColumnHeader colunaProximoLongitude;
    }
}

