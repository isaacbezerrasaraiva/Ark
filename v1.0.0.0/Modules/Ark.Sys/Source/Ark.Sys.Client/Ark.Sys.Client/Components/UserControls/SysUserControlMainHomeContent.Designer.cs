
namespace Ark.Sys.Client
{
    partial class SysUserControlMainHomeContent
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
            this.panelBottom = new Lazy.Forms.Win.LazyPanel();
            this.buttonLock = new Lazy.Forms.Win.LazyButton();
            this.buttonLogout = new Lazy.Forms.Win.LazyButton();
            this.panelSearch = new Lazy.Forms.Win.LazyPanel();
            this.lazyTextBox1 = new Lazy.Forms.Win.LazyTextBox();
            this.panelContent = new Lazy.Forms.Win.LazyPanel();
            this.panelBottom.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.buttonLock);
            this.panelBottom.Controls.Add(this.buttonLogout);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 225);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(800, 50);
            this.panelBottom.TabIndex = 1;
            // 
            // buttonLock
            // 
            this.buttonLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLock.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLock.Location = new System.Drawing.Point(716, 8);
            this.buttonLock.Name = "buttonLock";
            this.buttonLock.Size = new System.Drawing.Size(35, 35);
            this.buttonLock.TabIndex = 1;
            this.buttonLock.Text = "LK";
            this.buttonLock.UseVisualStyleBackColor = true;
            this.buttonLock.Click += new System.EventHandler(this.OnButtonLockClick);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLogout.Location = new System.Drawing.Point(757, 8);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(35, 35);
            this.buttonLogout.TabIndex = 0;
            this.buttonLogout.Text = "EX";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.OnButtonLogoutClick);
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.lazyTextBox1);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(800, 75);
            this.panelSearch.TabIndex = 5;
            // 
            // lazyTextBox1
            // 
            this.lazyTextBox1.DockOnCenter = true;
            this.lazyTextBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lazyTextBox1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lazyTextBox1.Location = new System.Drawing.Point(213, 23);
            this.lazyTextBox1.Name = "lazyTextBox1";
            this.lazyTextBox1.Size = new System.Drawing.Size(375, 29);
            this.lazyTextBox1.TabIndex = 0;
            this.lazyTextBox1.Text = "Search for resource";
            this.lazyTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 75);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(800, 150);
            this.panelContent.TabIndex = 6;
            // 
            // SysUserControlMainHomeContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelBottom);
            this.Name = "SysUserControlMainHomeContent";
            this.Size = new System.Drawing.Size(800, 275);
            this.panelBottom.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Lazy.Forms.Win.LazyPanel panelBottom;
        private Lazy.Forms.Win.LazyButton buttonLock;
        private Lazy.Forms.Win.LazyButton buttonLogout;
        private Lazy.Forms.Win.LazyPanel panelSearch;
        private Lazy.Forms.Win.LazyTextBox lazyTextBox1;
        private Lazy.Forms.Win.LazyPanel panelContent;
    }
}
