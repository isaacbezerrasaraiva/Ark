
namespace Ark.Sys.Client
{
    partial class SysUserControlMainExplorer
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
            this.panelLeft = new Lazy.Forms.Win.LazyPanel();
            this.panelMenu = new Lazy.Forms.Win.LazyPanel();
            this.panelMenuBottom = new Lazy.Forms.Win.LazyPanel();
            this.panelTop = new Lazy.Forms.Win.LazyPanel();
            this.labelMenuName = new Lazy.Forms.Win.LazyLabel();
            this.buttonHome = new Ark.Sys.Client.SysControlMainExplorerButton();
            this.buttonBack = new Ark.Sys.Client.SysControlMainExplorerButton();
            this.textBoxSearch = new Lazy.Forms.Win.LazyTextBox();
            this.panelContentBottom = new Lazy.Forms.Win.LazyPanel();
            this.buttonLock = new Lazy.Forms.Win.LazyButton();
            this.buttonLogout = new Lazy.Forms.Win.LazyButton();
            this.panelContent = new Lazy.Forms.Win.LazyPanel();
            this.panelLeft.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelContentBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelLeft.Controls.Add(this.panelMenu);
            this.panelLeft.Controls.Add(this.panelMenuBottom);
            this.panelLeft.Controls.Add(this.panelTop);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(320, 410);
            this.panelLeft.TabIndex = 0;
            // 
            // panelMenu
            // 
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Location = new System.Drawing.Point(0, 175);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(320, 185);
            this.panelMenu.TabIndex = 2;
            // 
            // panelMenuBottom
            // 
            this.panelMenuBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMenuBottom.Location = new System.Drawing.Point(0, 360);
            this.panelMenuBottom.Name = "panelMenuBottom";
            this.panelMenuBottom.Size = new System.Drawing.Size(320, 50);
            this.panelMenuBottom.TabIndex = 1;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.labelMenuName);
            this.panelTop.Controls.Add(this.buttonHome);
            this.panelTop.Controls.Add(this.buttonBack);
            this.panelTop.Controls.Add(this.textBoxSearch);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(320, 175);
            this.panelTop.TabIndex = 0;
            // 
            // labelMenuName
            // 
            this.labelMenuName.AutoSize = true;
            this.labelMenuName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMenuName.Location = new System.Drawing.Point(14, 139);
            this.labelMenuName.Name = "labelMenuName";
            this.labelMenuName.Size = new System.Drawing.Size(86, 19);
            this.labelMenuName.TabIndex = 6;
            this.labelMenuName.Text = "MenuName";
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(18, 17);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(285, 32);
            this.buttonHome.TabIndex = 5;
            this.buttonHome.Text = "Home";
            this.buttonHome.Thumbnail = null;
            this.buttonHome.Click += new System.EventHandler(this.OnButtonHomeClick);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(18, 55);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(285, 32);
            this.buttonBack.TabIndex = 4;
            this.buttonBack.Text = "Back";
            this.buttonBack.Thumbnail = null;
            this.buttonBack.Click += new System.EventHandler(this.OnButtonBackClick);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.DockOnCenter = false;
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxSearch.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBoxSearch.Location = new System.Drawing.Point(18, 93);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(285, 29);
            this.textBoxSearch.TabIndex = 1;
            this.textBoxSearch.Text = "Search for resource";
            this.textBoxSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelContentBottom
            // 
            this.panelContentBottom.Controls.Add(this.buttonLock);
            this.panelContentBottom.Controls.Add(this.buttonLogout);
            this.panelContentBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelContentBottom.Location = new System.Drawing.Point(320, 360);
            this.panelContentBottom.Name = "panelContentBottom";
            this.panelContentBottom.Size = new System.Drawing.Size(480, 50);
            this.panelContentBottom.TabIndex = 1;
            // 
            // buttonLock
            // 
            this.buttonLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLock.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLock.Location = new System.Drawing.Point(396, 8);
            this.buttonLock.Name = "buttonLock";
            this.buttonLock.Size = new System.Drawing.Size(35, 35);
            this.buttonLock.TabIndex = 5;
            this.buttonLock.Text = "LK";
            this.buttonLock.UseVisualStyleBackColor = true;
            this.buttonLock.Click += new System.EventHandler(this.OnButtonLockClick);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLogout.Location = new System.Drawing.Point(437, 8);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(35, 35);
            this.buttonLogout.TabIndex = 4;
            this.buttonLogout.Text = "EX";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.OnButtonLogoutClick);
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(320, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(480, 360);
            this.panelContent.TabIndex = 2;
            // 
            // SysUserControlMainExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelContentBottom);
            this.Controls.Add(this.panelLeft);
            this.Name = "SysUserControlMainExplorer";
            this.Size = new System.Drawing.Size(800, 410);
            this.panelLeft.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelContentBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Lazy.Forms.Win.LazyPanel panelLeft;
        private Lazy.Forms.Win.LazyPanel panelContentBottom;
        private Lazy.Forms.Win.LazyPanel panelContent;
        private Lazy.Forms.Win.LazyPanel panelTop;
        private Lazy.Forms.Win.LazyPanel panelMenuBottom;
        private Lazy.Forms.Win.LazyPanel panelMenu;
        private Lazy.Forms.Win.LazyTextBox textBoxSearch;
        private SysControlMainExplorerButton buttonBack;
        private SysControlMainExplorerButton buttonHome;
        private Lazy.Forms.Win.LazyLabel labelMenuName;
        private Lazy.Forms.Win.LazyButton buttonLock;
        private Lazy.Forms.Win.LazyButton buttonLogout;
    }
}
