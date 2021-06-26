// SysControlMainHomeQuickLauncherItem.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, June 25

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
    public class SysControlMainHomeQuickLauncherItem : Control
    {
        #region Events
        #endregion Events

        #region Variables

        private LazyPictureBox pictureBoxIcon;
        private LazyLabel labelCaption;
        private LazyLabel labelDescription;

        #endregion Variables

        #region Constructors

        public SysControlMainHomeQuickLauncherItem()
        {
            this.Size = new Size(175, 175);

            this.pictureBoxIcon = new LazyPictureBox();
            this.pictureBoxIcon.Size = new Size(44, 44);
            this.pictureBoxIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBoxIcon.Location = new Point(10, 10);
            this.pictureBoxIcon.MouseEnter += OnMouseEnter;
            this.pictureBoxIcon.MouseLeave += OnMouseLeave;
            this.pictureBoxIcon.MouseDown += OnMouseDown;
            this.pictureBoxIcon.MouseUp += OnMouseUp;
            this.pictureBoxIcon.MouseWheel += OnMouseWheel;
            this.pictureBoxIcon.MouseClick += OnMouseClick;

            this.labelCaption = new LazyLabel();
            this.labelCaption.AutoSize = false;
            this.labelCaption.Size = new Size(this.Width - 20, 23);
            this.labelCaption.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.labelCaption.Location = new Point(this.pictureBoxIcon.Left, this.pictureBoxIcon.Bottom + 10);
            this.labelCaption.MouseEnter += OnMouseEnter;
            this.labelCaption.MouseLeave += OnMouseLeave;
            this.labelCaption.MouseDown += OnMouseDown;
            this.labelCaption.MouseUp += OnMouseUp;
            this.labelCaption.MouseWheel += OnMouseWheel;
            this.labelCaption.MouseClick += OnMouseClick;

            this.labelDescription = new LazyLabel();
            this.labelDescription.AutoSize = false;
            this.labelDescription.ForeColor = SystemColors.GrayText;
            this.labelDescription.Size = new Size(this.Width - 20, this.Height - this.labelCaption.Bottom - 20);
            this.labelDescription.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.labelDescription.Location = new Point(this.labelCaption.Left, this.labelCaption.Bottom + 10);
            this.labelDescription.MaximumSize = this.Size;
            this.labelDescription.MouseEnter += OnMouseEnter;
            this.labelDescription.MouseLeave += OnMouseLeave;
            this.labelDescription.MouseDown += OnMouseDown;
            this.labelDescription.MouseUp += OnMouseUp;
            this.labelDescription.MouseWheel += OnMouseWheel;
            this.labelDescription.MouseClick += OnMouseClick;

            this.MouseEnter += OnMouseEnter;
            this.MouseLeave += OnMouseLeave;
            this.MouseDown += OnMouseDown;
            this.MouseUp += OnMouseUp;

            this.Controls.Add(this.pictureBoxIcon);
            this.Controls.Add(this.labelCaption);
            this.Controls.Add(this.labelDescription);
        }

        #endregion Constructors

        #region Methods

        private void OnMouseEnter(Object sender, EventArgs e)
        {
            this.BackColor = SystemColors.ScrollBar;
            this.Cursor = Cursors.Hand;
        }

        private void OnMouseLeave(Object sender, EventArgs e)
        {
            this.BackColor = this.Parent.BackColor;
            this.Cursor = Cursors.Default;
        }

        private void OnMouseDown(Object sender, MouseEventArgs e)
        {
            this.BackColor = SystemColors.ControlDark;
        }

        private void OnMouseUp(Object sender, MouseEventArgs e)
        {
            this.BackColor = SystemColors.ScrollBar;
        }

        private void OnMouseWheel(Object sender, MouseEventArgs e)
        {
            base.OnMouseWheel(e);
        }

        private void OnMouseClick(Object sender, MouseEventArgs e)
        {
            base.OnMouseClick(new MouseEventArgs(e.Button, e.Clicks, ((Control)sender).Location.X + e.Location.X, ((Control)sender).Location.Y + e.Location.Y, e.Delta));
        }

        #endregion Methods

        #region Properties

        public Image Icon
        {
            get { return this.pictureBoxIcon.Image; }
            set { this.pictureBoxIcon.Image = value; }
        }

        public String Caption
        {
            get { return this.labelCaption.Text; }
            set { this.labelCaption.Text = value; }
        }

        public String Description
        {
            get { return this.labelDescription.Text; }
            set { this.labelDescription.Text = value; }
        }

        #endregion Properties
    }
}