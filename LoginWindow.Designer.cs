namespace MowChat
{
	partial class LoginWindow
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
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.loginStatus = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(12, 101);
			this.progressBar.MarqueeAnimationSpeed = 30;
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(360, 49);
			this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.progressBar.TabIndex = 0;
			this.progressBar.UseWaitCursor = true;
			// 
			// loginStatus
			// 
			this.loginStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.loginStatus.Location = new System.Drawing.Point(12, 9);
			this.loginStatus.Name = "loginStatus";
			this.loginStatus.Size = new System.Drawing.Size(360, 89);
			this.loginStatus.TabIndex = 1;
			this.loginStatus.Text = "Status";
			this.loginStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.loginStatus.UseWaitCursor = true;
			// 
			// LoginWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 162);
			this.Controls.Add(this.loginStatus);
			this.Controls.Add(this.progressBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "LoginWindow";
			this.Text = "Chat - Logging in... - March of War";
			this.UseWaitCursor = true;
			this.Load += new System.EventHandler(this.LoginWindow_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label loginStatus;
	}
}

