using System;
using System.Drawing;

namespace PA4Draft
{
    partial class Signature
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Signature));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pen = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(584, 192);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // pen
            // 
            this.pen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pen.BackgroundImage")));
            this.pen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pen.Location = new System.Drawing.Point(0, 238);
            this.pen.Name = "pen";
            this.pen.Size = new System.Drawing.Size(584, 23);
            this.pen.TabIndex = 3;
            this.pen.Text = "Use a different pen";
            this.pen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.pen.UseVisualStyleBackColor = true;
            this.pen.Click += new System.EventHandler(this.Pen_Click);
            // 
            // save
            // 
            this.save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.save.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.save.Enabled = false;
            this.save.Location = new System.Drawing.Point(0, 192);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(584, 23);
            this.save.TabIndex = 4;
            this.save.Text = "Use this as my signature";
            this.save.UseVisualStyleBackColor = true;
            // 
            // clear
            // 
            this.clear.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.clear.Location = new System.Drawing.Point(0, 215);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(584, 23);
            this.clear.TabIndex = 5;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Signature
            // 
            this.AcceptButton = this.save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.pen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(600, 300);
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "Signature";
            this.Text = "Signature";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button pen;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button clear;
        Point lastPoint = Point.Empty;//Point.Empty represents null for a Point object
        bool isMouseDown = new Boolean();//this is used to evaluate whether our mousebutton is down or not
        Color signaturePenColor;
        int signaturePenWidth;
    }
}