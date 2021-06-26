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

        public event EventHandler ParentSizeChanged;
        public event EventHandler LaunchItemRequested;
        public event EventHandler RemoveItemRequested;

        #endregion Events

        #region Variables

        private Size itemSize;

        private PictureBox pictureBoxLeft;
        private PictureBox pictureBoxRight;
        private Panel panelContent;

        private Object lastParent;

        #endregion Variables

        #region Constructors

        public SysControlMainHomeQuickLauncher()
        {
            this.itemSize = new Size(175, 175);

            this.pictureBoxLeft = new PictureBox();
            this.pictureBoxLeft.Dock = DockStyle.Left;
            this.pictureBoxLeft.Size = new Size(17, this.itemSize.Height);
            this.pictureBoxLeft.SizeMode = PictureBoxSizeMode.CenterImage;
            this.pictureBoxLeft.Click += OnPictureBoxLeftClick;
            this.pictureBoxLeft.MouseEnter += OnPictureBoxLeftMouseEnter;
            this.pictureBoxLeft.MouseLeave += OnPictureBoxLeftMouseLeave;

            this.pictureBoxRight = new PictureBox();
            this.pictureBoxRight.Dock = DockStyle.Right;
            this.pictureBoxRight.Size = new Size(17, this.itemSize.Height);
            this.pictureBoxRight.SizeMode = PictureBoxSizeMode.CenterImage;
            this.pictureBoxRight.Click += OnPictureBoxRightClick;
            this.pictureBoxRight.MouseEnter += OnPictureBoxRightMouseEnter;
            this.pictureBoxRight.MouseLeave += OnPictureBoxRightMouseLeave;

            this.panelContent = new Panel();
            this.panelContent.Dock = DockStyle.Fill;

            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.pictureBoxLeft);
            this.Controls.Add(this.pictureBoxRight);

            this.ParentChanged += OnParentChanged;
            this.ParentSizeChanged += OnParentSizeChanged;

            base.Size = new Size(this.pictureBoxLeft.Width + this.pictureBoxRight.Width, this.itemSize.Height);
        }

        #endregion Constructors

        #region Methods

        public void AddItem(Control control)
        {
            control.Size = new Size(this.itemSize.Width, this.itemSize.Height);
            control.MouseWheel += OnQuickLauncherItemMouseWheel;
            control.MouseClick += OnQuickLauncherItemMouseClick;

            this.panelContent.Controls.Add(control);

            if (this.Parent != null)
            {
                Int32 parentAvailableWidth = this.Parent.Width - this.pictureBoxLeft.Width - this.pictureBoxRight.Width;

                // if total items width is lower than parent available width
                if ((this.panelContent.Controls.Count * this.itemSize.Width) < parentAvailableWidth)
                {
                    if (this.panelContent.Controls.Count == 1)
                    {
                        control.Location = new Point(0, 0);

                        base.Size = new Size(this.itemSize.Width + this.pictureBoxLeft.Width + this.pictureBoxRight.Width, base.Height);
                        this.Location = new Point(this.Parent.Width - base.Width, this.Location.Y);
                    }
                    else
                    {
                        // The last control on panel is the control that's being added now, so must use as reference the control that was added before this (this.panelContent.Controls.Count - 2)
                        control.Location = new Point(this.panelContent.Controls[this.panelContent.Controls.Count - 2].Location.X + this.itemSize.Width, this.panelContent.Controls[this.panelContent.Controls.Count - 2].Location.Y);

                        base.Size = new Size((this.panelContent.Controls.Count * this.itemSize.Width) + this.pictureBoxLeft.Width + this.pictureBoxRight.Width, base.Height);
                        this.Location = new Point(this.Parent.Width - base.Width, this.Location.Y);
                    }
                }
                else // if total items width is higher or equals than parent available width
                {
                    ShowArrows();

                    // Move all controls to the left, except the control that's being added now
                    for (int i = 0; i < (this.panelContent.Controls.Count - 1); i++)
                        this.panelContent.Controls[i].Location = new Point(this.panelContent.Controls[i].Location.X - this.itemSize.Width + (this.Parent.Width - base.Width), this.panelContent.Controls[i].Location.Y);

                    // The last control on panel is the control that's being added now, so must use as reference the control that was added before this (this.panelContent.Controls.Count - 2)
                    control.Location = new Point(this.panelContent.Controls[this.panelContent.Controls.Count - 2].Location.X + this.itemSize.Width, this.panelContent.Controls[this.panelContent.Controls.Count - 2].Location.Y);

                    base.Size = new Size(this.Parent.Width, base.Height);
                    this.Location = new Point(this.Parent.Width - base.Width, this.Location.Y);
                }
            }
        }

        public void RemoveItem(Control control)
        {
            if (this.panelContent.Controls.Count > 0)
            {
                Int32 controlIndex = this.panelContent.Controls.IndexOf(control);

                if (controlIndex >= 0)
                {
                    this.panelContent.Controls.Remove(control);

                    Int32 parentAvailableWidth = this.Parent.Width - this.pictureBoxLeft.Width - this.pictureBoxRight.Width;

                    // if total items width is lower than parent available width
                    if ((this.panelContent.Controls.Count * this.itemSize.Width) < parentAvailableWidth)
                    {
                        HideArrows();

                        base.Size = new Size((this.panelContent.Controls.Count * this.itemSize.Width) + this.pictureBoxLeft.Width + this.pictureBoxRight.Width, base.Height);
                        this.Location = new Point(this.Parent.Width - base.Width, this.Location.Y);

                        for (int i = 0; i < this.panelContent.Controls.Count; i++)
                            this.panelContent.Controls[i].Location = new Point(this.itemSize.Width * i, this.panelContent.Controls[i].Location.Y);
                    }
                    else
                    {
                        if (this.panelContent.Controls[0].Location.X >= 0)
                        {
                            for (int i = controlIndex; i < this.panelContent.Controls.Count; i++)
                                this.panelContent.Controls[i].Location = new Point(this.panelContent.Controls[i].Location.X - this.itemSize.Width, this.panelContent.Controls[i].Location.Y);
                        }
                        else
                        {
                            for (int i = 0; i < controlIndex; i++)
                                this.panelContent.Controls[i].Location = new Point(this.panelContent.Controls[i].Location.X + this.itemSize.Width, this.panelContent.Controls[i].Location.Y);
                        }
                    }
                }
            }
        }

        private void ShowArrows()
        {
            if (this.pictureBoxLeft.Image == null)
                this.pictureBoxLeft.Image = Properties.SysResourcesClient.ArrowLeft_01_Black_Light_x016;

            if (this.pictureBoxRight.Image == null)
                this.pictureBoxRight.Image = Properties.SysResourcesClient.ArrowRight_01_Black_Light_x016;
        }

        private void HideArrows()
        {
            this.pictureBoxLeft.Image = null;
            this.pictureBoxRight.Image = null;
        }

        private void OnParentChanged(Object sender, EventArgs args)
        {
            if (this.lastParent != null)
            {
                if (this.lastParent != this.Parent)
                {
                    if (this.lastParent is Form)
                        ((Form)this.lastParent).SizeChanged -= this.ParentSizeChanged;
                    else if (this.lastParent is Control)
                        ((Control)this.lastParent).SizeChanged -= this.ParentSizeChanged;
                }
            }

            if (this.Parent != null)
            {
                this.Parent.SizeChanged += this.ParentSizeChanged;
                this.ParentSizeChanged(this, null);
            }

            this.lastParent = this.Parent;
        }

        private void OnParentSizeChanged(Object sender, EventArgs e)
        {
            if (this.panelContent.Controls.Count > 0)
            {
                Int32 parentAvailableWidth = this.Parent.Width - this.pictureBoxLeft.Width - this.pictureBoxRight.Width;

                // if total items width is lower than parent available width
                if ((this.panelContent.Controls.Count * this.itemSize.Width) < parentAvailableWidth)
                {
                    HideArrows();

                    if (this.panelContent.Controls.Count == 1)
                    {
                        base.Size = new Size(this.itemSize.Width + this.pictureBoxLeft.Width + this.pictureBoxRight.Width, base.Height);
                        this.Location = new Point(this.Parent.Width - base.Width, this.Location.Y);
                    }
                    else
                    {
                        base.Size = new Size((this.panelContent.Controls.Count * this.itemSize.Width) + this.pictureBoxLeft.Width + this.pictureBoxRight.Width, base.Height);
                        this.Location = new Point(this.Parent.Width - base.Width, this.Location.Y);

                        if ((this.panelContent.Controls[this.panelContent.Controls.Count - 1].Location.X + this.itemSize.Width) < this.panelContent.Width)
                        {
                            for (int i = 0; i < this.panelContent.Controls.Count; i++)
                                this.panelContent.Controls[i].Location = new Point(this.itemSize.Width * i, this.panelContent.Controls[i].Location.Y);
                        }
                    }
                }
                else // if total items width is higher or equals than parent available width
                {
                    ShowArrows();

                    base.Size = new Size(this.Parent.Width, base.Height);
                    this.Location = new Point(this.Parent.Width - base.Width, this.Location.Y);

                    if ((this.panelContent.Controls[this.panelContent.Controls.Count - 1].Location.X + this.itemSize.Width) < this.panelContent.Width)
                    {
                        for (int i = (this.panelContent.Controls.Count - 1); i >= 0; i--)
                            this.panelContent.Controls[i].Location = new Point(this.panelContent.Width - (this.itemSize.Width * ((this.panelContent.Controls.Count - 1) - i)) - this.itemSize.Width, this.panelContent.Controls[i].Location.Y);
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
            if (e.Button == MouseButtons.Left)
            {
                this.LaunchItemRequested?.Invoke(sender, e);
            }
            else if (e.Button == MouseButtons.Right)
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
            if (this.pictureBoxLeft.Image != null)
                this.pictureBoxLeft.Image = Properties.SysResourcesClient.ArrowLeft_01_Black_x016;
        }

        private void OnPictureBoxLeftMouseLeave(Object sender, EventArgs e)
        {
            if (this.pictureBoxLeft.Image != null)
                this.pictureBoxLeft.Image = Properties.SysResourcesClient.ArrowLeft_01_Black_Light_x016;
        }

        private void OnPictureBoxLeftClick(Object sender, EventArgs e)
        {
            if (this.panelContent.Controls.Count > 0)
            {
                if (this.panelContent.Controls[0].Location.X < 0)
                {
                    Int32 leftSideRemainWidth = this.panelContent.Controls[0].Location.X + this.itemSize.Width;

                    if (leftSideRemainWidth < 0)
                        leftSideRemainWidth = 0;

                    foreach (Control control in this.panelContent.Controls)
                        control.Location = new Point(control.Location.X + this.itemSize.Width - leftSideRemainWidth, control.Location.Y);
                }
            }
        }

        private void OnPictureBoxRightMouseEnter(Object sender, EventArgs e)
        {
            if (this.pictureBoxRight.Image != null)
                this.pictureBoxRight.Image = Properties.SysResourcesClient.ArrowRight_01_Black_x016;
        }

        private void OnPictureBoxRightMouseLeave(Object sender, EventArgs e)
        {
            if (this.pictureBoxRight.Image != null)
                this.pictureBoxRight.Image = Properties.SysResourcesClient.ArrowRight_01_Black_Light_x016;
        }

        private void OnPictureBoxRightClick(Object sender, EventArgs e)
        {
            if (this.panelContent.Controls.Count > 0)
            {
                if ((this.panelContent.Controls[this.panelContent.Controls.Count - 1].Location.X + this.itemSize.Width) > this.panelContent.Width)
                {
                    Int32 rightSideRemainWidth = this.panelContent.Width - this.panelContent.Controls[this.panelContent.Controls.Count - 1].Location.X;

                    if (rightSideRemainWidth < 0)
                        rightSideRemainWidth = 0;

                    foreach (Control control in this.panelContent.Controls)
                        control.Location = new Point(control.Location.X - this.itemSize.Width + rightSideRemainWidth, control.Location.Y);
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
