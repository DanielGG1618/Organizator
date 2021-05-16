using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizer
{
    public partial class AdminPanel : UserControlGG
    {
        public AdminPanel()
        {
            InitializeComponent();

            Theme.GrayControls[2].AddRange(new Control[] { updateDictionary, reference, addTranslationKeyGridView });
            Theme.GrayControls[3].Add(this);
        }


        private void Reference_Click(object sender, EventArgs e)
        {
            Utils.InDevelop();
        }

        private void AddTranslationKeyGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex != -1)
            {
                var cells = addTranslationKeyGridView.Rows[e.RowIndex].Cells;

                if(cells[0].Value == null)
                {
                    MessageBox.Show("Бан за пустой ключ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string key = cells[0].Value.ToString();
                string russian = cells[1].Value == null ? "" : cells[1].Value.ToString();
                string whoAmI = cells[2].Value == null ? "" : cells[2].Value.ToString(); 
                string english = cells[3].Value == null ? "" : cells[3].Value.ToString();

                if (SQL.Select($"SELECT TransValue FROM Translations WHERE TransKey = '{key}'").Count > 0)
                {
                    DialogResult result = MessageBox.Show("Такой ключ уже есть в словаре. Заменить?", "Ошибка",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        if(!string.IsNullOrEmpty(russian))
                            SQL.Insert($"UPDATE Translations SET TransValue = '{russian}' " +
                            $"WHERE TransKey = '{key}' AND Language = 'Русский'");
                        if (!string.IsNullOrEmpty(whoAmI))
                            SQL.Insert($"UPDATE Translations SET TransValue = '{whoAmI}' " +
                            $"WHERE TransKey = '{key}' AND Language = 'Кто am я'");
                        if (!string.IsNullOrEmpty(english))
                            SQL.Insert($"UPDATE Translations SET TransValue = '{english}' " +
                            $"WHERE TransKey = '{key}' AND Language = 'English'");

                        MessageBox.Show("Успешно добавлено");
                        addTranslationKeyGridView.Rows.Remove(addTranslationKeyGridView.Rows[e.RowIndex]);
                    }
                }

                else
                {
                    SQL.Insert($"INSERT INTO Translations (Language, TransKey, TransValue) VALUES " +
                        $"('Русский', '{key}', '{russian}'), " +
                        $"('Кто am я', '{key}', '{whoAmI}'), " +
                        $"('English', '{key}', '{english}')");

                    MessageBox.Show("Успешно добавлено");
                    addTranslationKeyGridView.Rows.Remove(addTranslationKeyGridView.Rows[e.RowIndex]);
                }
            }
        }

        private void UpdateDictionary_Click(object sender, EventArgs e)
        {
            Localization.Load();
            Main.Instance.ApplyLocalization();
        }

        private void RunBot_Click(object sender, EventArgs e)
        {
            Bot.Initialize(textBox1.Text);
        }
    }
}
