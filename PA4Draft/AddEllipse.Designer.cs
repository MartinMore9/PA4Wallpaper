using System;
using System.Drawing;

namespace PA4Draft
{
    partial class AddEllipse
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.mouseLocation = new System.Windows.Forms.ToolStripStatusLabel();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.chooseAPenButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.height = new System.Windows.Forms.NumericUpDown();
            this.width = new System.Windows.Forms.NumericUpDown();
            this.yLoc = new System.Windows.Forms.NumericUpDown();
            this.xLoc = new System.Windows.Forms.NumericUpDown();
            this.selectedRectangle = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedRectangle)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mouseLocation});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(659, 22);
            this.statusStrip1.TabIndex = 39;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // mouseLocation
            // 
            this.mouseLocation.Name = "mouseLocation";
            this.mouseLocation.Size = new System.Drawing.Size(86, 17);
            this.mouseLocation.Text = "Draw an ellipse";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Enabled = false;
            this.okButton.Location = new System.Drawing.Point(557, 382);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 38;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(557, 430);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 37;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // chooseAPenButton
            // 
            this.chooseAPenButton.Location = new System.Drawing.Point(535, 136);
            this.chooseAPenButton.Name = "chooseAPenButton";
            this.chooseAPenButton.Size = new System.Drawing.Size(113, 23);
            this.chooseAPenButton.TabIndex = 36;
            this.chooseAPenButton.Text = "Choose a Pen";
            this.chooseAPenButton.UseVisualStyleBackColor = true;
            this.chooseAPenButton.Click += new System.EventHandler(this.ChooseAPenClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(531, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Y-Location";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(529, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "H-Diameter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(530, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "V-Diameter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(531, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "X-Location";
            // 
            // height
            // 
            this.height.Location = new System.Drawing.Point(595, 254);
            this.height.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(53, 20);
            this.height.TabIndex = 31;
            this.height.ValueChanged += new System.EventHandler(this.Height_ValuedChanged);
            // 
            // width
            // 
            this.width.Location = new System.Drawing.Point(595, 228);
            this.width.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(53, 20);
            this.width.TabIndex = 30;
            this.width.ValueChanged += new System.EventHandler(this.Width_ValueChanged);
            // 
            // yLoc
            // 
            this.yLoc.Location = new System.Drawing.Point(595, 202);
            this.yLoc.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.yLoc.Name = "yLoc";
            this.yLoc.Size = new System.Drawing.Size(53, 20);
            this.yLoc.TabIndex = 29;
            this.yLoc.ValueChanged += new System.EventHandler(this.YLoc_ValueChanged);
            // 
            // xLoc
            // 
            this.xLoc.Location = new System.Drawing.Point(595, 176);
            this.xLoc.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.xLoc.Name = "xLoc";
            this.xLoc.Size = new System.Drawing.Size(53, 20);
            this.xLoc.TabIndex = 28;
            this.xLoc.ValueChanged += new System.EventHandler(this.XLoc_ValueChanged);
            // 
            // selectedRectangle
            // 
            this.selectedRectangle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.selectedRectangle.Location = new System.Drawing.Point(11, 11);
            this.selectedRectangle.Name = "selectedRectangle";
            this.selectedRectangle.Size = new System.Drawing.Size(512, 512);
            this.selectedRectangle.TabIndex = 27;
            this.selectedRectangle.TabStop = false;
            this.selectedRectangle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SelectedRectangle_MouseDown);
            this.selectedRectangle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SelectedRectangle_MouseMove);
            this.selectedRectangle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SelectedRectangle_MouseUp);
            // 
            // AddEllipse
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(659, 561);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.chooseAPenButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.height);
            this.Controls.Add(this.width);
            this.Controls.Add(this.yLoc);
            this.Controls.Add(this.xLoc);
            this.Controls.Add(this.selectedRectangle);
            this.MaximumSize = new System.Drawing.Size(675, 600);
            this.MinimumSize = new System.Drawing.Size(675, 600);
            this.Name = "AddEllipse";
            this.Text = "Add Ellipse";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedRectangle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel mouseLocation;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button chooseAPenButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown height;
        private System.Windows.Forms.NumericUpDown width;
        private System.Windows.Forms.NumericUpDown yLoc;
        private System.Windows.Forms.NumericUpDown xLoc;
        internal System.Windows.Forms.PictureBox selectedRectangle;
        Point rectangleLocation = Point.Empty;//Point.Empty represents null for a Point object
        bool isMouseDown = new Boolean();//this is used to evaluate whether our mousebutton is down or not
        internal Color drawingPenColor;
        internal int drawingPenWidth;
        internal Rectangle returnedRectangle;
    }
}