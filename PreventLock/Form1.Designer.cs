using System.Drawing;
namespace PreventLock
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.preventLockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentPossitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preventLockToolStripMenuItem,
            this.currentPossitionToolStripMenuItem,
            this.saveScreenToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 120);
            // 
            // preventLockToolStripMenuItem
            // 
            this.preventLockToolStripMenuItem.CheckOnClick = true;
            this.preventLockToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("preventLockToolStripMenuItem.Image")));
            this.preventLockToolStripMenuItem.Name = "preventLockToolStripMenuItem";
            this.preventLockToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.preventLockToolStripMenuItem.Text = "Prevent Lock";
            this.preventLockToolStripMenuItem.Click += new System.EventHandler(this.preventLockToolStripMenuItem_Click);
            // 
            // currentPossitionToolStripMenuItem
            // 
            this.currentPossitionToolStripMenuItem.CheckOnClick = true;
            this.currentPossitionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("currentPossitionToolStripMenuItem.Image")));
            this.currentPossitionToolStripMenuItem.Name = "currentPossitionToolStripMenuItem";
            this.currentPossitionToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.currentPossitionToolStripMenuItem.Text = "Current Possition";
            this.currentPossitionToolStripMenuItem.Click += new System.EventHandler(this.currentPossitionToolStripMenuItem_Click);
            // 
            // saveScreenToolStripMenuItem
            // 
            this.saveScreenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveScreenToolStripMenuItem.Image")));
            this.saveScreenToolStripMenuItem.Name = "saveScreenToolStripMenuItem";
            this.saveScreenToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.saveScreenToolStripMenuItem.Text = "Save Screen";
            this.saveScreenToolStripMenuItem.Click += new System.EventHandler(this.saveScreenToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 99);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.ClientSize = new System.Drawing.Size(87, 100);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.LimeGreen;
            this.LocationChanged += new System.EventHandler(this.Form1_LocationChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preventLockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentPossitionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

