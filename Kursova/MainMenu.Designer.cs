namespace Kursova
{
    partial class MainMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddFilm = new System.Windows.Forms.Button();
            this.btnViewFilms = new System.Windows.Forms.Button();
            this.btnAddSession = new System.Windows.Forms.Button();
            this.btnViewSessions = new System.Windows.Forms.Button();
            this.btnViewTickets = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStaffLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddFilm
            // 
            this.btnAddFilm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddFilm.Location = new System.Drawing.Point(39, 55);
            this.btnAddFilm.Name = "btnAddFilm";
            this.btnAddFilm.Size = new System.Drawing.Size(232, 44);
            this.btnAddFilm.TabIndex = 0;
            this.btnAddFilm.Text = "Додати фільм";
            this.btnAddFilm.UseVisualStyleBackColor = true;
            this.btnAddFilm.Click += new System.EventHandler(this.btnAddFilm_Click);
            // 
            // btnViewFilms
            // 
            this.btnViewFilms.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnViewFilms.Location = new System.Drawing.Point(39, 106);
            this.btnViewFilms.Name = "btnViewFilms";
            this.btnViewFilms.Size = new System.Drawing.Size(232, 68);
            this.btnViewFilms.TabIndex = 1;
            this.btnViewFilms.Text = "Переглянути доступні фільми";
            this.btnViewFilms.UseVisualStyleBackColor = true;
            this.btnViewFilms.Click += new System.EventHandler(this.btnViewFilms_Click);
            // 
            // btnAddSession
            // 
            this.btnAddSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddSession.Location = new System.Drawing.Point(300, 56);
            this.btnAddSession.Name = "btnAddSession";
            this.btnAddSession.Size = new System.Drawing.Size(172, 44);
            this.btnAddSession.TabIndex = 2;
            this.btnAddSession.Text = "Додати сеанс";
            this.btnAddSession.UseVisualStyleBackColor = true;
            this.btnAddSession.Click += new System.EventHandler(this.btnAddSession_Click);
            // 
            // btnViewSessions
            // 
            this.btnViewSessions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnViewSessions.Location = new System.Drawing.Point(300, 106);
            this.btnViewSessions.Name = "btnViewSessions";
            this.btnViewSessions.Size = new System.Drawing.Size(172, 68);
            this.btnViewSessions.TabIndex = 3;
            this.btnViewSessions.Text = "Доступні сеанси";
            this.btnViewSessions.UseVisualStyleBackColor = true;
            this.btnViewSessions.Click += new System.EventHandler(this.btnViewSessions_Click);
            // 
            // btnViewTickets
            // 
            this.btnViewTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnViewTickets.Location = new System.Drawing.Point(39, 180);
            this.btnViewTickets.Name = "btnViewTickets";
            this.btnViewTickets.Size = new System.Drawing.Size(433, 34);
            this.btnViewTickets.TabIndex = 5;
            this.btnViewTickets.Text = "Квитки";
            this.btnViewTickets.UseVisualStyleBackColor = true;
            this.btnViewTickets.Click += new System.EventHandler(this.btnViewTickets_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(300, 237);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(172, 35);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Вийти з системи";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(239, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Вітаємо!";
            // 
            // btnStaffLogin
            // 
            this.btnStaffLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStaffLogin.Location = new System.Drawing.Point(39, 237);
            this.btnStaffLogin.Name = "btnStaffLogin";
            this.btnStaffLogin.Size = new System.Drawing.Size(232, 35);
            this.btnStaffLogin.TabIndex = 8;
            this.btnStaffLogin.Text = "Війти в систему";
            this.btnStaffLogin.UseVisualStyleBackColor = true;
            this.btnStaffLogin.Click += new System.EventHandler(this.btnStaffLogin_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(520, 284);
            this.Controls.Add(this.btnStaffLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnViewTickets);
            this.Controls.Add(this.btnViewSessions);
            this.Controls.Add(this.btnAddSession);
            this.Controls.Add(this.btnViewFilms);
            this.Controls.Add(this.btnAddFilm);
            this.Name = "MainMenu";
            this.Text = "Головне меню";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddFilm;
        private System.Windows.Forms.Button btnViewFilms;
        private System.Windows.Forms.Button btnAddSession;
        private System.Windows.Forms.Button btnViewSessions;
        private System.Windows.Forms.Button btnViewTickets;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStaffLogin;
    }
}

