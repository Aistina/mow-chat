using System.Drawing;
using System.Windows.Forms;

namespace MowChat
{
	sealed partial class ChatControl
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
            this.chatText = new MetroFramework.Controls.MetroTextBox();
            this.sendButton = new MetroFramework.Controls.MetroButton();
            this.messagesContainer = new RichTextBox();
            this.SuspendLayout();
            // 
            // chatText
            // 
            this.chatText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatText.Location = new System.Drawing.Point(3, 306);
            this.chatText.Name = "chatText";
            this.chatText.Size = new System.Drawing.Size(380, 23);
            this.chatText.Style = MetroFramework.MetroColorStyle.Blue;
            this.chatText.TabIndex = 1;
            this.chatText.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.Location = new System.Drawing.Point(389, 306);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(126, 23);
            this.sendButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send";
            this.sendButton.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // messagesContainer
            // 
            this.messagesContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messagesContainer.Location = new System.Drawing.Point(3, 3);
            this.messagesContainer.Multiline = true;
            this.messagesContainer.Name = "messagesContainer";
            this.messagesContainer.ReadOnly = true;
            this.messagesContainer.ScrollBars = RichTextBoxScrollBars.Vertical;
            this.messagesContainer.Size = new System.Drawing.Size(512, 297);
			this.messagesContainer.Font = new Font("Calibri", 11f);
            //this.messagesContainer.Style = MetroFramework.MetroColorStyle.Blue;
            this.messagesContainer.TabIndex = 3;
            //this.messagesContainer.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // ChatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.messagesContainer);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.chatText);
            this.Name = "ChatControl";
            this.Size = new System.Drawing.Size(518, 332);
            this.ResumeLayout(false);

		}

		#endregion

        private MetroFramework.Controls.MetroTextBox chatText;
		private MetroFramework.Controls.MetroButton sendButton;
		//private MetroFramework.Controls.MetroTextBox messagesContainer;
        private RichTextBox messagesContainer;
	}
}
