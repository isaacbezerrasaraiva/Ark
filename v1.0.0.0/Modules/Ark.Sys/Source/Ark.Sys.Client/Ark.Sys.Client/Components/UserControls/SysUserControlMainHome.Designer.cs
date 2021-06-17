
namespace Ark.Sys.Client
{
    partial class SysUserControlMainHome
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
            this.panelTop = new Lazy.Forms.Win.LazyPanel();
            this.panelContent = new Lazy.Forms.Win.LazyPanel();
            this.panelMenu = new Lazy.Forms.Win.LazyPanel();
            this.panelBottom = new Lazy.Forms.Win.LazyPanel();
            this.buttonLock = new Lazy.Forms.Win.LazyButton();
            this.buttonLogout = new Lazy.Forms.Win.LazyButton();
            this.panelSearch = new Lazy.Forms.Win.LazyPanel();
            this.textBoxSearch = new Lazy.Forms.Win.LazyTextBox();
            this.panelContent.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 175);
            this.panelTop.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.panelMenu);
            this.panelContent.Controls.Add(this.panelBottom);
            this.panelContent.Controls.Add(this.panelSearch);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 175);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(800, 235);
            this.panelContent.TabIndex = 1;
            // 
            // panelMenu
            // 
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Location = new System.Drawing.Point(0, 75);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(800, 110);
            this.panelMenu.TabIndex = 2;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.buttonLock);
            this.panelBottom.Controls.Add(this.buttonLogout);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 185);
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
            this.buttonLock.TabIndex = 3;
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
            this.buttonLogout.TabIndex = 2;
            this.buttonLogout.Text = "EX";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.OnButtonLogoutClick);
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.textBoxSearch);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(800, 75);
            this.panelSearch.TabIndex = 0;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.DockOnCenter = true;
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxSearch.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBoxSearch.Location = new System.Drawing.Point(213, 23);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(375, 29);
            this.textBoxSearch.TabIndex = 1;
            this.textBoxSearch.Text = "Search for resource";
            this.textBoxSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SysUserControlMainHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTop);
            this.Name = "SysUserControlMainHome";
            this.Size = new System.Drawing.Size(800, 410);
            this.panelContent.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Lazy.Forms.Win.LazyPanel panelTop;
        private Lazy.Forms.Win.LazyPanel panelContent;
        private Lazy.Forms.Win.LazyPanel panelSearch;
        private Lazy.Forms.Win.LazyTextBox textBoxSearch;
        private Lazy.Forms.Win.LazyPanel panelMenu;
        private Lazy.Forms.Win.LazyPanel panelBottom;
        private Lazy.Forms.Win.LazyButton buttonLock;
        private Lazy.Forms.Win.LazyButton buttonLogout;
    }
}
