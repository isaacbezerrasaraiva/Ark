// SysControlMainHomeQuickLauncher.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, June 19

using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Lazy;
using Lazy.Forms.Win;

using Ark.Lib;
using Ark.Lib.Client;
using Ark.Fwk;
using Ark.Fwk.Data;
using Ark.Fwk.Client;
using Ark.Fwk.IServer;
using Ark.Sys;
using Ark.Sys.Data;
using Ark.Sys.IServer;

namespace Ark.Sys.Client
{
    public class SysControlMainHomeQuickLauncher : Control
    {
        #region Events

        public event EventHandler RemoveItemRequested;

        #endregion Events

        #region Variables

        private Size itemSize;

        private PictureBox pictureBoxLeft;
        private PictureBox pictureBoxRight;
        private Panel panelContent;

        #endregion Variables

        #region Constructors

        public SysControlMainHomeQuickLauncher()
        {
            this.itemSize = new Size(175, 175);

            this.pictureBoxLeft = new PictureBox();
            this.pictureBoxLeft.Dock = DockStyle.Left;
            this.pictureBoxLeft.Size = new Size(17, this.itemSize.Height);
            this.pictureBoxLeft.SizeMode = PictureBoxSizeMode.CenterImage;
            this.pictureBoxLeft.Image = Properties.SysResourcesClient.ArrowLeft_01_Black_Light_x016;
            this.pictureBoxLeft.Click += OnPictureBoxLeftClick;
            this.pictureBoxLeft.MouseEnter += OnPictureBoxLeftMouseEnter;
            this.pictureBoxLeft.MouseLeave += OnPictureBoxLeftMouseLeave;

            this.pictureBoxRight = new PictureBox();
            this.pictureBoxRight.Dock = DockStyle.Right;
            this.pictureBoxRight.Size = new Size(17, this.itemSize.Height);
            this.pictureBoxRight.SizeMode = PictureBoxSizeMode.CenterImage;
            this.pictureBoxRight.Image = Properties.SysResourcesClient.ArrowRight_01_Black_Light_x016;
            this.pictureBoxRight.Click += OnPictureBoxRightClick;
            this.pictureBoxRight.MouseEnter += OnPictureBoxRightMouseEnter;
            this.pictureBoxRight.MouseLeave += OnPictureBoxRightMouseLeave;

            this.panelContent = new Panel();
            this.panelContent.Dock = DockStyle.Fill;

            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.pictureBoxLeft);
            this.Controls.Add(this.pictureBoxRight);

            base.Size = new Size(this.pictureBoxLeft.Width + this.pictureBoxRight.Width, this.itemSize.Height);
        }

        #endregion Constructors

        #region Methods

        public void AddItem(Control control)
        {
            control.Size = new Size(this.itemSize.Width, this.itemSize.Height);
            control.MouseWheel += OnQuickLauncherItemMouseWheel;
            control.MouseClick += OnQuickLauncherItemMouseClick;

            if (this.panelContent.Controls.Count == 0)
            {
                control.Location = new Point(0, 0);

                base.Size = new Size(base.Size.Width + this.itemSize.Width, base.Size.Height);
                this.Location = new Point(this.Location.X - this.itemSize.Width, this.Location.Y);
            }
            else
            {
                if (this.Parent != null)
                {
                    if ((this.Size.Width + this.itemSize.Width) < this.Parent.Width)
                    {
                        control.Location = new Point(this.panelContent.Controls[this.panelContent.Controls.Count - 1].Location.X + this.itemSize.Width, this.panelContent.Controls[this.panelContent.Controls.Count - 1].Location.Y);

                        base.Size = new Size(base.Size.Width + this.itemSize.Width, base.Size.Height);
                        this.Location = new Point(this.Location.X - this.itemSize.Width, this.Location.Y);
                    }
                    else
                    {
                        foreach (Control existingControl in this.panelContent.Controls)
                            existingControl.Location = new Point(existingControl.Location.X - this.itemSize.Width, existingControl.Location.Y);

                        control.Location = new Point(this.panelContent.Controls[this.panelContent.Controls.Count - 1].Location.X + this.itemSize.Width, this.panelContent.Controls[this.panelContent.Controls.Count - 1].Location.Y);
                    }
                }
            }

            this.panelContent.Controls.Add(control);
        }

        public void RemoveItem(Control control)
        {
            if (this.panelContent.Controls.Count > 0)
            {
                Int32 controlToRemoveIndex = 0;
                foreach (Control controlToRemove in this.panelContent.Controls)
                {
                    if (controlToRemove != control)
                    {
                        controlToRemoveIndex++;
                        continue;
                    }

                    this.panelContent.Controls.Remove(controlToRemove);

                    // if total itens count lower than available space for itens
                    if (this.panelContent.Controls.Count < (this.panelContent.Width / this.itemSize.Width))
                    {
                        base.Size = new Size(base.Size.Width - this.itemSize.Width, base.Size.Height);
                        this.Location = new Point(this.Location.X + this.itemSize.Width, this.Location.Y);

                        for (int i = controlToRemoveIndex; i < this.panelContent.Controls.Count; i++)
                            this.panelContent.Controls[i].Location = new Point(this.panelContent.Controls[i].Location.X - this.itemSize.Width, this.panelContent.Controls[i].Location.Y);
                    }
                    else // if total itens count higher or equals than available space for itens
                    {
                        if (this.panelContent.Controls[0].Location.X >= 0)
                        {
                            for (int i = controlToRemoveIndex; i < this.panelContent.Controls.Count; i++)
                                this.panelContent.Controls[i].Location = new Point(this.panelContent.Controls[i].Location.X - this.itemSize.Width, this.panelContent.Controls[i].Location.Y);
                        }
                        else
                        {
                            for (int i = 0; i < controlToRemoveIndex; i++)
                                this.panelContent.Controls[i].Location = new Point(this.panelContent.Controls[i].Location.X + this.itemSize.Width, this.panelContent.Controls[i].Location.Y);
                        }
                    }
                }
            }
        }

        private void OnQuickLauncherItemMouseWheel(Object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                OnPictureBoxLeftClick(sender, null);
            }
            else
            {
                OnPictureBoxRightClick(sender, null);
            }
        }

        private void OnQuickLauncherItemMouseClick(Object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ToolStripMenuItem toolStripMenuItemRemove = new ToolStripMenuItem();
                toolStripMenuItemRemove.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                toolStripMenuItemRemove.Text = LibGlobalization.GetTranslation(Properties.SysResourcesClient.SysCaptionRemove);
                toolStripMenuItemRemove.Image = Properties.SysResourcesClient.Remove_01_Black_x016;
                toolStripMenuItemRemove.Tag = sender;
                toolStripMenuItemRemove.MouseEnter += OnToolStripMenuItemRemoveMouseEnter;
                toolStripMenuItemRemove.MouseLeave += OnToolStripMenuItemRemoveMouseLeave;
                toolStripMenuItemRemove.Click += OnToolStripMenuItemRemoveClick;

                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                contextMenuStrip.Items.Add(toolStripMenuItemRemove);
                contextMenuStrip.Show((Control)sender, e.Location);
            }
        }

        private void OnToolStripMenuItemRemoveMouseEnter(Object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Image = Properties.SysResourcesClient.Remove_01_Red_x016;
        }

        private void OnToolStripMenuItemRemoveMouseLeave(Object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Image = Properties.SysResourcesClient.Remove_01_Black_x016;
        }

        private void OnToolStripMenuItemRemoveClick(Object sender, EventArgs e)
        {
            RemoveItem((Control)((ToolStripMenuItem)sender).Tag);

            this.RemoveItemRequested?.Invoke((Control)((ToolStripMenuItem)sender).Tag, e);
        }

        private void OnPictureBoxLeftMouseEnter(Object sender, EventArgs e)
        {
            this.pictureBoxLeft.Image = Properties.SysResourcesClient.ArrowLeft_01_Black_x016;
        }

        private void OnPictureBoxLeftMouseLeave(Object sender, EventArgs e)
        {
            this.pictureBoxLeft.Image = Properties.SysResourcesClient.ArrowLeft_01_Black_Light_x016;
        }

        private void OnPictureBoxLeftClick(Object sender, EventArgs e)
        {
            if (this.panelContent.Controls.Count > 0)
            {
                if (this.panelContent.Controls[0].Location.X < 0)
                {
                    foreach (Control control in this.panelContent.Controls)
                        control.Location = new Point(control.Location.X + this.itemSize.Width, control.Location.Y);
                }
            }
        }

        private void OnPictureBoxRightMouseEnter(Object sender, EventArgs e)
        {
            this.pictureBoxRight.Image = Properties.SysResourcesClient.ArrowRight_01_Black_x016;
        }

        private void OnPictureBoxRightMouseLeave(Object sender, EventArgs e)
        {
            this.pictureBoxRight.Image = Properties.SysResourcesClient.ArrowRight_01_Black_Light_x016;
        }

        private void OnPictureBoxRightClick(Object sender, EventArgs e)
        {
            if (this.panelContent.Controls.Count > 0)
            {
                if (this.panelContent.Controls[this.panelContent.Controls.Count - 1].Location.X >= this.panelContent.Width)
                {
                    foreach (Control control in this.panelContent.Controls)
                        control.Location = new Point(control.Location.X - this.itemSize.Width, control.Location.Y);
                }
            }
        }

        #endregion Methods

        #region Properties

        public new Size Size
        {
            get { return base.Size; }
            set { base.Size = new Size(base.Width, value.Height); }
        }

        public Size ItemSize
        {
            get { return this.itemSize; }
            set
            {
                this.itemSize = value;
                base.Size = new Size(base.Width, value.Height);
            }
        }

        #endregion Properties
    }
}
