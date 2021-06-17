// SysControlMainExplorerButton.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, June 16

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
    public class SysControlMainExplorerButton : Control
    {
        #region Variables

        private PictureBox pictureBoxThumbnail;
        private Label labelTitle;

        #endregion Variables

        #region Constructors

        public SysControlMainExplorerButton()
        {
            this.Size = new Size(100, 32);
            this.MouseEnter += OnMouseEnter;
            this.MouseLeave += OnMouseLeave;
            this.MouseDown += OnMouseDown;
            this.MouseUp += OnMouseUp;

            this.pictureBoxThumbnail = new PictureBox();
            this.pictureBoxThumbnail.Size = new Size(16, 16);
            this.pictureBoxThumbnail.Location = new Point(5, (this.Height / 2) - (this.pictureBoxThumbnail.Height / 2));
            this.pictureBoxThumbnail.MouseEnter += OnMouseEnter;
            this.pictureBoxThumbnail.MouseLeave += OnMouseLeave;
            this.pictureBoxThumbnail.MouseDown += OnMouseDown;
            this.pictureBoxThumbnail.MouseUp += OnMouseUp;
            this.pictureBoxThumbnail.Click += OnPictureBoxThumbnailClick;

            this.labelTitle = new Label();
            this.labelTitle.Text = "Button";
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.Location = new Point(5 + this.pictureBoxThumbnail.Width + 5, (this.Height / 2) - (this.labelTitle.Height / 2));
            this.labelTitle.MouseEnter += OnMouseEnter;
            this.labelTitle.MouseLeave += OnMouseLeave;
            this.labelTitle.MouseDown += OnMouseDown;
            this.labelTitle.MouseUp += OnMouseUp;
            this.labelTitle.Click += OnLabelTitleClick;

            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.pictureBoxThumbnail);
        }

        #endregion Constructors

        #region Methods

        private void OnPictureBoxThumbnailClick(Object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void OnLabelTitleClick(Object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void OnMouseEnter(Object sender, EventArgs e)
        {
            this.BackColor = SystemColors.ControlDark;
        }

        private void OnMouseLeave(Object sender, EventArgs e)
        {
            this.BackColor = this.Parent.BackColor;
        }

        private void OnMouseDown(Object sender, MouseEventArgs e)
        {
            this.BackColor = SystemColors.ControlDarkDark;
        }

        private void OnMouseUp(Object sender, MouseEventArgs e)
        {
            this.BackColor = SystemColors.ControlDark;
        }

        #endregion Methods

        #region Properties

        public Image Thumbnail
        {
            get { return this.pictureBoxThumbnail.Image; }
            set { this.pictureBoxThumbnail.Image = value; }
        }

        public override string Text
        {
            get { return this.labelTitle.Text; }
            set { this.labelTitle.Text = value; }
        }

        public new Size Size
        {
            get { return base.Size; }
            set { base.Size = new Size(value.Width, 32); }
        }

        #endregion Properties
    }
}