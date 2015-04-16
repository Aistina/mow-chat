namespace MowChat
{
	partial class ChatWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatWindow));
            this.chatTabs = new MetroFramework.Controls.MetroTabControl();
            this.SuspendLayout();
            // 
            // chatTabs
            // 
            this.chatTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatTabs.Location = new System.Drawing.Point(46, 121);
            this.chatTabs.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chatTabs.Name = "chatTabs";
            this.chatTabs.Padding = new System.Drawing.Point(6, 8);
            this.chatTabs.Size = new System.Drawing.Size(1194, 731);
            this.chatTabs.Style = MetroFramework.MetroColorStyle.Blue;
            this.chatTabs.TabIndex = 0;
            this.chatTabs.Theme = MetroFramework.MetroThemeStyle.Light;
            this.chatTabs.UseSelectable = true;
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 896);
            this.Controls.Add(this.chatTabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "ChatWindow";
            this.Padding = new System.Windows.Forms.Padding(40, 115, 40, 38);
            this.Text = "Chat - Face Off";
            this.ResumeLayout(false);

		}

		#endregion

        private MetroFramework.Controls.MetroTabControl chatTabs;
	}
}