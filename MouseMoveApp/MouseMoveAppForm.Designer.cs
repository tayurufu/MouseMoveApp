namespace MouseMoveApp
{
    partial class MouseMoveApp
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MouseMoveApp));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeButton = new System.Windows.Forms.Button();
            this.kidoJotaiLabel = new System.Windows.Forms.Label();
            this.ToggleButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.intervalTextBox = new System.Windows.Forms.TextBox();
            this.intervalLael = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "MouseMoveApp";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.終了ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 26);
            this.contextMenuStrip1.Tag = "";
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.終了ToolStripMenuItem.Text = "終了";
            this.終了ToolStripMenuItem.Click += new System.EventHandler(this.AppExitToolStripMenuItem_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(93, 181);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 28);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // kidoJotaiLabel
            // 
            this.kidoJotaiLabel.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.kidoJotaiLabel.Location = new System.Drawing.Point(12, 16);
            this.kidoJotaiLabel.Name = "kidoJotaiLabel";
            this.kidoJotaiLabel.Size = new System.Drawing.Size(236, 31);
            this.kidoJotaiLabel.TabIndex = 1;
            this.kidoJotaiLabel.Text = "起動状態";
            this.kidoJotaiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ToggleButton
            // 
            this.ToggleButton.Location = new System.Drawing.Point(78, 146);
            this.ToggleButton.Name = "ToggleButton";
            this.ToggleButton.Size = new System.Drawing.Size(105, 29);
            this.ToggleButton.TabIndex = 2;
            this.ToggleButton.Text = "Toggle";
            this.ToggleButton.UseVisualStyleBackColor = true;
            this.ToggleButton.Click += new System.EventHandler(this.ToggleButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "CTRL + SHIFT + S　開始";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "CTRL + SHIFT + D　停止";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // intervalTextBox
            // 
            this.intervalTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.intervalTextBox.Location = new System.Drawing.Point(138, 110);
            this.intervalTextBox.MaxLength = 4;
            this.intervalTextBox.Name = "intervalTextBox";
            this.intervalTextBox.Size = new System.Drawing.Size(41, 19);
            this.intervalTextBox.TabIndex = 5;
            this.intervalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.intervalTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.intervalTextBox_Validating);
            // 
            // intervalLael
            // 
            this.intervalLael.AutoSize = true;
            this.intervalLael.Location = new System.Drawing.Point(78, 113);
            this.intervalLael.Name = "intervalLael";
            this.intervalLael.Size = new System.Drawing.Size(49, 12);
            this.intervalLael.TabIndex = 6;
            this.intervalLael.Text = "間隔(秒)";
            // 
            // MouseMoveApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 217);
            this.Controls.Add(this.intervalLael);
            this.Controls.Add(this.intervalTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ToggleButton);
            this.Controls.Add(this.kidoJotaiLabel);
            this.Controls.Add(this.closeButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MouseMoveApp";
            this.Text = "MouseMoveApp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
        private System.Windows.Forms.Label kidoJotaiLabel;
        private System.Windows.Forms.Button ToggleButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox intervalTextBox;
        private System.Windows.Forms.Label intervalLael;
    }
}

