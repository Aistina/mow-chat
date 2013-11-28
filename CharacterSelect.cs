using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MowChat.Data;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace MowChat
{
	public partial class CharacterSelect : MetroForm
	{
		private readonly List<Character> _characters;
		private readonly Action<Character> _onSelected;

		public CharacterSelect(List<Character> characters, Action<Character> onSelected)
		{
			InitializeComponent();

			_characters = characters;
			_onSelected = onSelected;
		}

		private void CharacterSelect_Load(object sender, EventArgs e)
		{
			var paddingTop = characterButton.Top;
			var y = paddingTop;
			var height = characterButton.Height;

			foreach (var c in _characters)
			{
				AddButton(c, y);
				y += height + paddingTop;
			}

			characterButton.Hide();
		}

		private void AddButton(Character character, int y)
		{
			var button = new MetroButton
				{
					Height = characterButton.Height,
					Text = character.Name,
					Top = y,
					Left = characterButton.Left,
					Width = characterButton.Width
				};

			button.Click += delegate {
				_onSelected(character);
				Invoke((MethodInvoker) Close);
			};

			scrollPanel.Controls.Add(button);
		}
	}
}
