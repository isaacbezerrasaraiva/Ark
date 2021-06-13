
namespace Ark.Sys.Client
{
    partial class SysLoginClient
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelUsername = new Lazy.Forms.Win.LazyLabel();
            this.textBoxUsername = new Lazy.Forms.Win.LazyTextBox();
            this.comboBoxEnvironments = new Lazy.Forms.Win.LazyComboBox();
            this.labelPassword = new Lazy.Forms.Win.LazyLabel();
            this.textBoxPassword = new Lazy.Forms.Win.LazyTextBox();
            this.buttonAccess = new Lazy.Forms.Win.LazyButton();
            this.labelEnvironment = new Lazy.Forms.Win.LazyLabel();
            this.SuspendLayout();
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelUsername.Location = new System.Drawing.Point(103, 81);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(71, 19);
            this.labelUsername.TabIndex = 2;
            this.labelUsername.Text = "Username";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxUsername.Location = new System.Drawing.Point(103, 103);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(275, 29);
            this.textBoxUsername.TabIndex = 3;
            // 
            // comboBoxEnvironments
            // 
            this.comboBoxEnvironments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEnvironments.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxEnvironments.FormattingEnabled = true;
            this.comboBoxEnvironments.Location = new System.Drawing.Point(103, 49);
            this.comboBoxEnvironments.Name = "comboBoxEnvironments";
            this.comboBoxEnvironments.Size = new System.Drawing.Size(275, 29);
            this.comboBoxEnvironments.TabIndex = 1;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPassword.Location = new System.Drawing.Point(103, 135);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(67, 19);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPassword.Location = new System.Drawing.Point(103, 157);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(275, 29);
            this.textBoxPassword.TabIndex = 5;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // buttonAccess
            // 
            this.buttonAccess.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAccess.Location = new System.Drawing.Point(193, 207);
            this.buttonAccess.Name = "buttonAccess";
            this.buttonAccess.Size = new System.Drawing.Size(95, 32);
            this.buttonAccess.TabIndex = 6;
            this.buttonAccess.Text = "Access";
            this.buttonAccess.UseVisualStyleBackColor = true;
            this.buttonAccess.Click += new System.EventHandler(this.OnButtonAccessClick);
            // 
            // labelEnvironment
            // 
            this.labelEnvironment.AutoSize = true;
            this.labelEnvironment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelEnvironment.Location = new System.Drawing.Point(103, 27);
            this.labelEnvironment.Name = "labelEnvironment";
            this.labelEnvironment.Size = new System.Drawing.Size(87, 19);
            this.labelEnvironment.TabIndex = 0;
            this.labelEnvironment.Text = "Environment";
            // 
            // SysLoginClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelEnvironment);
            this.Controls.Add(this.buttonAccess);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.comboBoxEnvironments);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.labelUsername);
            this.KeepCenteredToParent = true;
            this.Name = "SysLoginClient";
            this.Size = new System.Drawing.Size(480, 270);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Lazy.Forms.Win.LazyLabel labelUsername;
        private Lazy.Forms.Win.LazyTextBox textBoxUsername;
        private Lazy.Forms.Win.LazyComboBox comboBoxEnvironments;
        private Lazy.Forms.Win.LazyLabel labelPassword;
        private Lazy.Forms.Win.LazyTextBox textBoxPassword;
        private Lazy.Forms.Win.LazyButton buttonAccess;
        private Lazy.Forms.Win.LazyLabel labelEnvironment;
    }
}
