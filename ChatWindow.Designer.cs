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
            this.chatTabs = new MetroFramework.Controls.MetroTabControl();
            this.SuspendLayout();
            // 
            // chatTabs
            // 
            this.chatTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatTabs.FontSize = MetroFramework.MetroTabControlSize.Medium;
            this.chatTabs.FontWeight = MetroFramework.MetroTabControlWeight.Light;
            this.chatTabs.Location = new System.Drawing.Point(23, 63);
            this.chatTabs.Name = "chatTabs";
            this.chatTabs.Size = new System.Drawing.Size(597, 380);
            this.chatTabs.Style = MetroFramework.MetroColorStyle.Blue;
            this.chatTabs.TabIndex = 0;
            this.chatTabs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chatTabs.Theme = MetroFramework.MetroThemeStyle.Light;
            this.chatTabs.UseStyleColors = false;
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 466);
            this.Controls.Add(this.chatTabs);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ChatWindow";
            this.Text = "Chat - March of War";
            this.ResumeLayout(false);

		}

		#endregion

        private MetroFramework.Controls.MetroTabControl chatTabs;
	}
}