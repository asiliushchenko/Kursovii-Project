namespace Kursova
{
    partial class SessionListForm
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
            this.dgvSessions = new System.Windows.Forms.DataGridView();
            this.btnHallScheme = new System.Windows.Forms.Button();
            this.btnDeleteSession = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnFilterDate = new System.Windows.Forms.Button();
            this.btnFilterFilm = new System.Windows.Forms.Button();
            this.cmbFilm = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSessions)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSessions
            // 
            this.dgvSessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSessions.Location = new System.Drawing.Point(12, 92);
            this.dgvSessions.Name = "dgvSessions";
            this.dgvSessions.Size = new System.Drawing.Size(775, 346);
            this.dgvSessions.TabIndex = 0;
            // 
            // btnHallScheme
            // 
            this.btnHallScheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnHallScheme.Location = new System.Drawing.Point(13, 12);
            this.btnHallScheme.Name = "btnHallScheme";
            this.btnHallScheme.Size = new System.Drawing.Size(168, 35);
            this.btnHallScheme.TabIndex = 1;
            this.btnHallScheme.Text = "Переглянути зал";
            this.btnHallScheme.UseVisualStyleBackColor = true;
            this.btnHallScheme.Click += new System.EventHandler(this.btnHallScheme_Click);
            // 
            // btnDeleteSession
            // 
            this.btnDeleteSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteSession.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDeleteSession.Location = new System.Drawing.Point(188, 12);
            this.btnDeleteSession.Name = "btnDeleteSession";
            this.btnDeleteSession.Size = new System.Drawing.Size(148, 35);
            this.btnDeleteSession.TabIndex = 2;
            this.btnDeleteSession.Text = "Видалити дані";
            this.btnDeleteSession.UseVisualStyleBackColor = true;
            this.btnDeleteSession.Click += new System.EventHandler(this.btnDeleteSession_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpDate.Location = new System.Drawing.Point(467, 14);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 26);
            this.dtpDate.TabIndex = 3;
            // 
            // btnFilterDate
            // 
            this.btnFilterDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFilterDate.Location = new System.Drawing.Point(673, 12);
            this.btnFilterDate.Name = "btnFilterDate";
            this.btnFilterDate.Size = new System.Drawing.Size(115, 28);
            this.btnFilterDate.TabIndex = 4;
            this.btnFilterDate.Text = "Фільтр";
            this.btnFilterDate.UseVisualStyleBackColor = true;
            this.btnFilterDate.Click += new System.EventHandler(this.btnFilterDate_Click);
            // 
            // btnFilterFilm
            // 
            this.btnFilterFilm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFilterFilm.Location = new System.Drawing.Point(675, 56);
            this.btnFilterFilm.Name = "btnFilterFilm";
            this.btnFilterFilm.Size = new System.Drawing.Size(113, 30);
            this.btnFilterFilm.TabIndex = 6;
            this.btnFilterFilm.Text = "Фільтр";
            this.btnFilterFilm.UseVisualStyleBackColor = true;
            this.btnFilterFilm.Click += new System.EventHandler(this.btnFilterFilm_Click);
            // 
            // cmbFilm
            // 
            this.cmbFilm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbFilm.FormattingEnabled = true;
            this.cmbFilm.Location = new System.Drawing.Point(467, 56);
            this.cmbFilm.Name = "cmbFilm";
            this.cmbFilm.Size = new System.Drawing.Size(200, 28);
            this.cmbFilm.TabIndex = 7;
            // 
            // SessionListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbFilm);
            this.Controls.Add(this.btnFilterFilm);
            this.Controls.Add(this.btnFilterDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btnDeleteSession);
            this.Controls.Add(this.btnHallScheme);
            this.Controls.Add(this.dgvSessions);
            this.Name = "SessionListForm";
            this.Text = "Сеанси";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSessions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSessions;
        private System.Windows.Forms.Button btnHallScheme;
        private System.Windows.Forms.Button btnDeleteSession;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnFilterDate;
        private System.Windows.Forms.Button btnFilterFilm;
        private System.Windows.Forms.ComboBox cmbFilm;
    }
}