namespace MowChat
{
	partial class ChatControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.messagesContainer = new MetroFramework.Controls.MetroPanel();
			this.chatText = new MetroFramework.Controls.MetroTextBox();
			this.sendButton = new MetroFramework.Controls.MetroButton();
			this.SuspendLayout();
			// 
			// messagesContainer
			// 
			this.messagesContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.messagesContainer.AutoScroll = true;
			this.messagesContainer.CustomBackground = false;
			this.messagesContainer.HorizontalScrollbar = false;
			this.messagesContainer.HorizontalScrollbarBarColor = true;
			this.messagesContainer.HorizontalScrollbarHighlightOnWheel = false;
			this.messagesContainer.HorizontalScrollbarSize = 10;
			this.messagesContainer.Location = new System.Drawing.Point(3, 3);
			this.messagesContainer.Name = "messagesContainer";
			this.messagesContainer.Size = new System.Drawing.Size(512, 297);
			this.messagesContainer.Style = MetroFramework.MetroColorStyle.Blue;
			this.messagesContainer.StyleManager = null;
			this.messagesContainer.TabIndex = 0;
			this.messagesContainer.Theme = MetroFramework.MetroThemeStyle.Light;
			this.messagesContainer.VerticalScrollbar = true;
			this.messagesContainer.VerticalScrollbarBarColor = true;
			this.messagesContainer.VerticalScrollbarHighlightOnWheel = false;
			this.messagesContainer.VerticalScrollbarSize = 10;
			// 
			// chatText
			// 
			this.chatText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.chatText.CustomBackground = false;
			this.chatText.CustomForeColor = false;
			this.chatText.FontSize = MetroFramework.MetroTextBoxSize.Small;
			this.chatText.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
			this.chatText.Location = new System.Drawing.Point(3, 306);
			this.chatText.Multiline = false;
			this.chatText.Name = "chatText";
			this.chatText.SelectedText = "";
			this.chatText.Size = new System.Drawing.Size(380, 23);
			this.chatText.Style = MetroFramework.MetroColorStyle.Blue;
			this.chatText.StyleManager = null;
			this.chatText.TabIndex = 1;
			this.chatText.Theme = MetroFramework.MetroThemeStyle.Light;
			this.chatText.UseStyleColors = false;
			// 
			// sendButton
			// 
			this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.sendButton.Highlight = false;
			this.sendButton.Location = new System.Drawing.Point(389, 306);
			this.sendButton.Name = "sendButton";
			this.sendButton.Size = new System.Drawing.Size(126, 23);
			this.sendButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.sendButton.StyleManager = null;
			this.sendButton.TabIndex = 2;
			this.sendButton.Text = "Send";
			this.sendButton.Theme = MetroFramework.MetroThemeStyle.Light;
			// 
			// ChatControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.sendButton);
			this.Controls.Add(this.chatText);
			this.Controls.Add(this.messagesContainer);
			this.Name = "ChatControl";
			this.Size = new System.Drawing.Size(518, 332);
			this.ResumeLayout(false);

		}

		#endregion

		private MetroFramework.Controls.MetroPanel messagesContainer;
		private MetroFramework.Controls.MetroTextBox chatText;
		private MetroFramework.Controls.MetroButton sendButton;
	}
}
